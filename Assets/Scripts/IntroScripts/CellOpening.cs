﻿using UnityEngine;
using System.Collections;

public class CellOpening : MonoBehaviour 
{
	//Force Upwards of the Explosion attached to the Celldoor
	public float upForce;
	//Force Outwards of the Explosion attached to the celldoor
	public float sideForce;
	//The Explosion Particle Effect prefab, had to be dragged manually into the inspector
	public GameObject explode;
	//A GameObject for the Player, can be Public and dragged or declared as down below
	GameObject thePlayer;

	// Use this for initialization

	void Start () 
	{
		//Sets the Player FPC to the GameObject
		thePlayer = GameObject.FindGameObjectWithTag("Player");
		//Ensures Explosions begins as "off"
		explode.SetActive (false);
		//Call the Coroutine, required due to timings involved
		StartCoroutine(DoorCoroutine ());
	}

	void Update ()
	{
		Screen.lockCursor = true;
	}


	public IEnumerator DoorCoroutine()		
	{	
		//Turns off the FirstPersonCharacter Script, prevents movement using the keys, but the mouse still looks around
		thePlayer.GetComponent<FirstPersonCharacter> ().enabled = false;
		thePlayer.GetComponent<Rigidbody>().detectCollisions = false;
		thePlayer.GetComponent<Rigidbody>().useGravity = false;
		//Wait for two seconds
		yield return new WaitForSeconds(2.0f);
		//Turn on the Explosion particle effect
		explode.SetActive (true);
		//Shake the Camera
		thePlayer.GetComponent<PlayerFeelForce>().shakeHead();
		//Wait another second
		yield return new WaitForSeconds(1.0f);

		//Explode the door, turn on the gravity (the door is a little above the floor).
		rigidbody.AddForce(transform.forward * sideForce);
		rigidbody.AddForce(transform.up * upForce);
		rigidbody.useGravity = true;
		//Wait another two seconds
		yield return new WaitForSeconds (2.0f);
		//Turn back on movement
		thePlayer.GetComponent<FirstPersonCharacter> ().enabled = true;
		thePlayer.GetComponent<Rigidbody>().detectCollisions = true;
		thePlayer.GetComponent<Rigidbody>().useGravity = true;
	}

	// Release mouse lock
	void OnDisable()
	{
		Screen.lockCursor = false;
	}
}
