using UnityEngine;
using System.Collections;

public class CellOpening : MonoBehaviour 
{
	public float upForce;
	public float sideForce;
	public GameObject explode;

	// Use this for initialization

	void Start () 
	{
		explode.SetActive (false);
		StartCoroutine(DoorCoroutine ());
	}
	
	// Update is called once per frame
	void Update () 
	{

	}	

	public IEnumerator DoorCoroutine()		
	{	
		yield return new WaitForSeconds(2.0f);
		explode.SetActive (true);
		yield return new WaitForSeconds(1.0f);
		rigidbody.AddForce(transform.forward * 1400);
		rigidbody.AddForce(transform.up * 1400);
		rigidbody.useGravity = true;
	}
}
