using UnityEngine;
using System.Collections;

public class PlayerFireExt : MonoBehaviour {

	// Key Parts
	private GameObject fireExt;
	private GameObject activeItem;
	
	void Awake () {
		
		// Reference Torch Model and turn render off
		fireExt = this.gameObject;
		fireExt.renderer.enabled = false;
		fireExt.GetComponent<BoxCollider> ().enabled = false;
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
			fireExt.GetComponent<BoxCollider> ().enabled = true;

			if(Input.GetButtonDown("Interact") && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerObjectPickUp> ().interact)
			{
				Destroy (GameObject.Find("EnterWardinsOffice"));
			}
		}
		else
		{
			fireExt.renderer.enabled = false;
			fireExt.GetComponent<BoxCollider> ().enabled = false;
		}
	}
}
