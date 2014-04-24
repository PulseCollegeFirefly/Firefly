﻿using UnityEngine;
using System.Collections;

public class FirstFireTrigger : MonoBehaviour {

	//Declares GameObject, I dragged the Explosion1 GameObject onto this instead of declaring it

	public GameObject explode;

	void Start()
	{
		//Ensures Explosion is set of off on launch
		explode.SetActive (false);
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Player")
		{
			//Causes stumble

			other.GetComponent<PlayerFeelForce>().shakeHead();

			//Turns on Explosion Particle Effect and then Destroys the Trigger so it can't be re-used
			explode.SetActive (true);
			Destroy(this.gameObject);
		}
	}
}
