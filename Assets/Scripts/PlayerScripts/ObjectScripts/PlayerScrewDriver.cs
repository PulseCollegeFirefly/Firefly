﻿using UnityEngine;
using System.Collections;

public class PlayerScrewDriver : MonoBehaviour {

	// Screw Driver Parts
	private GameObject screwDriver;
	private GameObject activeItem;
	
	void Awake () {
		
		// Reference Torch Model and turn render off
		screwDriver = this.gameObject;
		screwDriver.renderer.enabled = false;
		screwDriver.GetComponent<BoxCollider> ().enabled = false;
	}
	
	void CheckActiveItem ()
	{
		activeItem = GameObject.FindGameObjectWithTag("ActiveItem").GetComponent<PlayerItemControl> ().activeItem;
	}
	
	// Update is called once per frame
	void Update () {
		
		CheckActiveItem ();
		
		// Check if the player has the torch in their hand
		if(activeItem != null && this.gameObject.name == activeItem.name)
		{
			screwDriver.renderer.enabled = true;
			screwDriver.GetComponent<BoxCollider> ().enabled = true;
		}
		else
		{
			screwDriver.renderer.enabled = false;
			screwDriver.GetComponent<BoxCollider> ().enabled = false;
		}
	}
}
