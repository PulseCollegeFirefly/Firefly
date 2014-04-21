using UnityEngine;
using System.Collections;

public class FirstFireTrigger : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Player")
		{
			other.GetComponent<PlayerFeelForce>().shakeHead();
		}
	}
}
