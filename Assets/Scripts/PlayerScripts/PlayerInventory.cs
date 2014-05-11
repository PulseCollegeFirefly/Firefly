using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	private GameObject[] inventorys;
	private bool[] hasItem;

	private int screenHeight;
	private int screenWidth;

	public GUIStyle largeFont;
	public GUIStyle smallFont;

	void Awake () {

		// Make a List of all objects tagged Pick Up
		inventorys = GameObject.FindGameObjectsWithTag("PickUp");

		// Make a list of the same exact size as above to reference having Item
		hasItem = new bool[inventorys.Length];

		// Cache screen size
		screenHeight = Screen.height;
		screenWidth = Screen.width;
	}

	public void AddItem (GameObject itemPickup) {

		// Make Child off the player
		itemPickup.transform.parent = this.gameObject.transform;

		// Move to position of the Inventory (Out of the way)
		itemPickup.transform.position = GameObject.FindGameObjectWithTag("Inventory").transform.position;

		// Turn Renderer Off and rigidbody physics off
		itemPickup.renderer.enabled = false;
		itemPickup.rigidbody.useGravity = false;
		itemPickup.rigidbody.isKinematic = true;

		// Set hasItem to true
		for(int i = 0; i < hasItem.Length; i++)
		{
			if(inventorys[i].name == itemPickup.name)
			{
				hasItem[i] = true;
			}
		}
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

	void OnGUI () {

		if(Input.GetButton ("Inventory"))
		{
			// Begin Inventory Display
			GUI.BeginGroup(new Rect(10, 10, screenWidth-20, screenHeight-20));
			GUI.Box(new Rect(0, 0, screenWidth-20, screenHeight-20), "Inventory", largeFont);

			// Display Enclosing Box
			GUI.BeginGroup(new Rect(0, 100, screenWidth, screenHeight-120));
			int j = 0;
			int k = 0;

			for(int i = 0; i < inventorys.Length; i++)
			{
				if(hasItem[i])
				{
					// Display Item
					GUI.BeginGroup(new Rect( (((screenWidth-20)/4)*j), (((screenHeight-20)/3)*k), (screenWidth-20)/4, ((screenHeight)/4)+10 ));
					GUI.DrawTexture(new Rect( 0, 0, (screenWidth-20)/4, (screenHeight-20)/4 ), inventorys[i].transform.GetComponentInChildren<GUILoader>().ObjectGUITexture, ScaleMode.StretchToFill, true);
					GUI.Box(new Rect( 0, ((screenHeight-20)/5)+20, (screenWidth)/4, 30 ), inventorys[i].name, smallFont);
					GUI.EndGroup();
					// End Item Display

					j++;
					if(j == 4)
					{
						k++;
						j = 0;
					}
				}
			}
			GUI.EndGroup();
			GUI.EndGroup();
			// End Inventory Display
		}
	}
}
