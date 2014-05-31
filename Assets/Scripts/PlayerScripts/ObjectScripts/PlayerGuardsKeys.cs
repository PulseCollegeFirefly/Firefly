using UnityEngine;
using System.Collections;

public class PlayerGuardsKeys : MonoBehaviour {
	
	// Key Parts
	private GameObject key;

	private GameObject activeItem;
	
	void Awake () {
		
		// Reference Torch Model and turn render off
		key = this.gameObject;
		key.renderer.enabled = false;
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
			key.renderer.enabled = true;

		else
			key.renderer.enabled = false;
		
	}
}
