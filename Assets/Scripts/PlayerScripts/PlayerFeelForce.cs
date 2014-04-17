using UnityEngine;
using System.Collections;

public class PlayerFeelForce : MonoBehaviour {

	public Transform headJoint;
	public float shakeStrength = 5;

	private float shake;
	private Vector3 originalPosition;

	void Awake ()
	{
		originalPosition = headJoint.localPosition;
		shake = 0;
	}
	
	void LateUpdate()
	{
		headJoint.localPosition = originalPosition + (Random.insideUnitSphere * shake);
		
		shake = Mathf.MoveTowards(shake, 0, Time.deltaTime * shakeStrength);
		
		if(shake == 0)
		{
			headJoint.localPosition = originalPosition;
		}
	}

	public void shakeHead()
	{
		shake = shakeStrength;
	}
}
