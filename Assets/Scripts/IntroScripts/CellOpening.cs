using UnityEngine;
using System.Collections;

public class CellOpening : MonoBehaviour 
{
	public float upForce;
	public float sideForce;

	// Use this for initialization

	void Start () 
	{
		StartCoroutine(DoorCoroutine ());
	}
	
	// Update is called once per frame
	void Update () 
	{

	}	

	public IEnumerator DoorCoroutine()		
	{	
		yield return new WaitForSeconds(3.0f);
		rigidbody.AddForce(transform.forward * 1400);
		rigidbody.AddForce(transform.up * 1400);
		rigidbody.useGravity = true;
		Debug.Log ("Wait Confirmed");
	}
}
