using UnityEngine;
using System.Collections;

public class FirstFireTrigger : MonoBehaviour {

	public float radius = 5.0F;
	public float power = 1000.0F;
	public Transform relPos;

	void OnTriggerEnter ()
	{
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		foreach (Collider hit in colliders) {
			if (hit && hit.rigidbody)
			{
				hit.rigidbody.AddExplosionForce(power, explosionPos, radius, 3.0F);
				Debug.Log ("Force Added");
			}	
		}
	}
}
