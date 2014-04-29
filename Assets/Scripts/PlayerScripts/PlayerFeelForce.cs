using UnityEngine;
using System.Collections;

public class PlayerFeelForce : MonoBehaviour {

	public Transform headJoint;
	public float shakeStrength = 5;

	private float shake;
	private Vector3 originalPosition;

	void Awake ()
	{
		// Set Orginal Position and start shake value
		originalPosition = headJoint.localPosition;
		shake = 0;
	}
	
	void LateUpdate()
	{
		// Set head joint to the orginal Position + some random unit * shake in the unit shere
		headJoint.localPosition = originalPosition + (Random.insideUnitSphere * shake);

		// Set shake to tend towards zero over time * shake strenght
		shake = Mathf.MoveTowards(shake, 0, Time.deltaTime * shakeStrength);

		// Set head joint to orginal position when shake == 0
		if(shake == 0)
		{
			headJoint.localPosition = originalPosition;
		}
	}

	// Public method to access
	public void shakeHead()
	{
		shake = shakeStrength;
	}
}
