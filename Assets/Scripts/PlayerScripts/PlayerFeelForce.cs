using UnityEngine;
using System.Collections;

public class PlayerFeelForce : MonoBehaviour {
	
	private float externalForceAmount;
	private Transform head;
	private FirstPersonCharacter character;

	void Awake ()
	{
		orginalLocalPos = head.localPosition;
		player = GetComponent<FirstPersonCharacter>();
	}

	void FixedUpdate ()
	{
		float xTilt = -springPos*jumpLandTilt;
		float zTilt = bobSwayFactor*headBobSwayAngle*headBobFade;
		head.localRotation = Quaternion.Euler(xTilt,0,zTilt)
	}
	
	// Update is called once per frame
	//void FixedUpdate () {
	//	rigidbody.AddExplosionForce
	//}

	//public addForce (float amount, string where)
	//{

	//}
}
