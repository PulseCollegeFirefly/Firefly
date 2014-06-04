using UnityEngine;
using System.Collections;

public class PlayerWrench : MonoBehaviour {

	// Wrench Parts
	private GameObject wrench;
	private GameObject activeItem;
	
	void Awake () {
		
		// Reference Torch Model and turn render off
		wrench = this.gameObject;
		wrench.renderer.enabled = false;
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
			wrench.renderer.enabled = true;
		
		else
			wrench.renderer.enabled = false;
		
	}
}
