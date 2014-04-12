using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	public void AddItem (GameObject itemPickup)
	{
		itemPickup.transform.parent = this.gameObject.transform;
		itemPickup.renderer.enabled = false;
	}

	public bool findItem (string item)
	{
		foreach (Transform child in this.gameObject.transform)
		{
			if(child.name == item)
			{
				return true;
			}
		}
		return false;
	}
}
