using UnityEngine;
using System.Collections;

public class PlayerItemControl : MonoBehaviour {

	public GameObject activeItem;
	public GameObject[] heldItems;

	private GameObject gameInventory;
	private int numObjects;
	private int currentObject;
	
	void Start () {
		activeItem = null;
		numObjects = 0;
		gameInventory = GameObject.FindGameObjectWithTag("Inventory");

		UpdateObjects();
	}
	
	// Update is called once per frame
	void Update () {

		// Iterate through the Selection
		if(Input.GetButtonUp("SwitchItem"))
		{
			// Set current Object number, reset when over max.
			currentObject++;
			if(currentObject > numObjects)
				currentObject = 0;

			// Find current Object inside the heldItems array, else set it to null
			if(currentObject != 0)
				activeItem = heldItems[currentObject-1];
			else
				activeItem = null;
		}
	}

	public void UpdateObjects()
	{
		// Check the num of Pick Up items
		CheckNumObjects ();

		// Regenerate the held Item list
		heldItems = GenerateItemArray ();
	}

	void CheckNumObjects ()
	{
		Transform[] items = gameInventory.GetComponentsInChildren<Transform> ();

		numObjects = 1;
		foreach(Transform item in items)
		{
			if(item.tag == "PickUp")
			{
				numObjects++;
			}
		}
	}

	GameObject[] GenerateItemArray ()
	{
		Transform[] items = gameInventory.GetComponentsInChildren<Transform> ();
		GameObject[] tempHeldItems = new GameObject[numObjects];
		int i = 0;
		foreach(Transform item in items)
		{
			if(item.tag == "PickUp")
			{
				tempHeldItems[i] = item.gameObject;
				i++;
			}
		}
		return tempHeldItems;
	}
}
