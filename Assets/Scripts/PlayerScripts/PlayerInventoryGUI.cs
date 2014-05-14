using UnityEngine;
using System.Collections;

public class PlayerInventoryGUI : MonoBehaviour {

	public GUIStyle largeFont;
	public GUIStyle smallFont;

	private GameObject gameInventory;
	private float screenHeight;
	private float screenWidth;

	void Awake () {

		// Reference Game Inventory
		gameInventory = GameObject.FindGameObjectWithTag("Inventory");

		// Cache screen size
		screenHeight = Screen.height;
		screenWidth = Screen.width;
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

			Transform[] items = gameInventory.GetComponentsInChildren<Transform> ();
			foreach (Transform item in items)
			{
				if(item.tag == "PickUp")
				{
					GUI.BeginGroup(new Rect( (((screenWidth-20)/4)*j), (((screenHeight-20)/3)*k), (screenWidth-20)/4, ((screenHeight)/4)+25 ));
					GUI.DrawTexture(new Rect( 0, 0, (screenWidth-20)/4, (screenHeight-20)/4 ), item.gameObject.GetComponentInChildren<GUILoader>().ObjectGUITexture, ScaleMode.StretchToFill, true);
					GUI.Box(new Rect( 0, ((screenHeight-20)/5)+50, (screenWidth)/4, 30 ), item.name, smallFont);
					GUI.EndGroup();
					// End Item Display
				}
					
				j++;
				if(j == 4)
				{
					k++;
					j = 0;
				}
			}
			GUI.EndGroup();
			GUI.EndGroup();
			// End Inventory Display
		}
	}
}
