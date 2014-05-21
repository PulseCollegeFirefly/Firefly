using UnityEngine;
using System.Collections;

public class GameInventory : MonoBehaviour {

	private GameObject gameController;

	void Start () {

		// Don't Destroy on Load.
		DontDestroyOnLoad(this.gameObject);	
	}

	public void AddItem (GameObject itemPickup, string name) {

		// Make Child off the inventory
		itemPickup.transform.parent = this.gameObject.transform;

		// Move to position of the Inventory (Out of the way)
		itemPickup.transform.position = this.transform.position;

		//changes name to passed string
		itemPickup.transform.name = name;

		// Turn Renderer Off and rigidbody physics off
		itemPickup.renderer.enabled = false;
		itemPickup.rigidbody.useGravity = false;
		itemPickup.rigidbody.isKinematic = true;
	}

	public bool findItem (string item) {

		// Foreach child item in the Inventory
		foreach (Transform child in this.gameObject.transform)
		{
			// If it equals the the string search return true
			if(child.name == item)
			{
				return true;
			}
		}
		// Else return false
		return false;
	}
}
