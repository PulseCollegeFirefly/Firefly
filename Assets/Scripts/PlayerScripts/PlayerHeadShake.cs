using UnityEngine;
using System.Collections;

public class PlayerHeadShake: MonoBehaviour {

	public GameObject head;
	public float shakeStrength = 3;

	private float shake;
	private Vector3 originalPosition;

	void Awake ()
	{
		// Set Orginal Position and start shake value
		originalPosition = head.transform.localPosition;
		shake = 0;
	}
	
	void LateUpdate()
	{
		// Set head joint to the orginal Position + some random unit * shake in the unit shere
		head.transform.localPosition = originalPosition + (Random.insideUnitSphere * shake);

		// Set shake to tend towards zero over time * shake strenght
		shake = Mathf.MoveTowards(shake, 0, Time.deltaTime * shakeStrength);

		// Set head joint to orginal position when shake == 0
		if(shake == 0)
		{
			head.transform.localPosition = originalPosition;
		}
	}

	// Public method to access
	public void shakeHead()
	{
		shake = shakeStrength;
	}
}
