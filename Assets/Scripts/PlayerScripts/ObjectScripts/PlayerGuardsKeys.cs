using UnityEngine;
using System.Collections;

public class PlayerGuardsKeys : MonoBehaviour {
	
	// Key Parts
	private GameObject key;
	
	private GameObject player;
	private GameObject activeItem;
	
	void Awake () {

		// Reference the player
		player = GameObject.FindGameObjectWithTag("Player");
		
		// Reference Torch Model and turn render off
		key = this.gameObject;
		key.renderer.enabled = false;
		key.GetComponent<BoxCollider> ().enabled = false;
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
			key.renderer.enabled = true;
			key.GetComponent<BoxCollider> ().enabled = true;
		}
		else
		{
			key.renderer.enabled = false;
			key.GetComponent<BoxCollider> ().enabled = false;
		}
	}
}
