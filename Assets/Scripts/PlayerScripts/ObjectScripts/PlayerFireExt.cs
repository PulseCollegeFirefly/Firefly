﻿using UnityEngine;
using System.Collections;

public class PlayerFireExt : MonoBehaviour {

	// Key Parts
	private GameObject fireExt;
	private GameObject activeItem;
	private ParticleSystem steam;
	
	void Awake () {
		
		// Reference Torch Model and turn render off
		fireExt = this.gameObject;
		fireExt.renderer.enabled = false;

		// Reference Steam
		steam = GameObject.FindGameObjectWithTag("Steam").GetComponent<ParticleSystem> ();
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
			fireExt.renderer.enabled = true;

			if(Input.GetButton("Interact"))
			{
				if (steam != null)
					steam.Play ();

				// If object player is interacting with something
				if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerObjectPickUp> ().interact)
				{
					GameObject enterWardinsOffice = GameObject.Find ("EnterWardinsOffice");

					// If it's not already destried destroy :-)
					if(enterWardinsOffice != null)
					{
						enterWardinsOffice.GetComponent<WardensOfficeEntry> ().setFire(false);

						Destroy (GameObject.Find ("FireTriggerExit"));
						//Destroy (steam);
						Destroy (enterWardinsOffice);
					}
				}	
			}
			else
				if(steam != null)
					steam.Stop ();
		}
		else
		{
			fireExt.renderer.enabled = false;

			if(steam != null)
				steam.Stop ();
		}
	}
}
