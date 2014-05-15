using UnityEngine;
using System.Collections;

public class PlayerInventoryGUI : MonoBehaviour {

	public GUIStyle largeFont;
	public GUIStyle smallFont;
	public GUIStyle activeFont;

	public Texture texture;

	private GameObject gameInventory;
	private float screenHeight;
	private float screenWidth;

	private GUIStyle tempStyle;

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
			GUI.BeginGroup(new Rect(0, 0, screenWidth, screenHeight));
			GUI.Box(new Rect(0, 0, screenWidth, screenHeight/10), "Inventory", largeFont);
			
			// Display Enclosing Box
			GUI.BeginGroup(new Rect(0, screenHeight/10, screenWidth, screenHeight-(screenHeight/10)));
			int j = 0;
			int k = 0;

			Transform[] items = gameInventory.GetComponentsInChildren<Transform> ();
			foreach (Transform item in items)
			{
				if(item.tag == "PickUp")
				{
					GUI.BeginGroup(new Rect((screenWidth/4)*j, ((screenHeight-(screenHeight/10))/2)*k, screenWidth/4, screenHeight/2), texture);
					GUI.DrawTexture(new Rect( 0, 0, screenWidth/4, ((screenHeight-(screenHeight/10))/2)-(screenHeight/10)), item.gameObject.GetComponentInChildren<GUILoader>().ObjectGUITexture, ScaleMode.StretchToFill, true);

					// If an active object highlight in active font
					if(GameObject.FindGameObjectWithTag("ActiveItem").GetComponent<PlayerItemControl> ().activeItem != null && item.name == GameObject.FindGameObjectWithTag("ActiveItem").GetComponent<PlayerItemControl> ().activeItem.name)
						tempStyle = activeFont;
					else
						tempStyle = smallFont; 

					GUI.Box(new Rect( 0, ((screenHeight-(screenHeight/10))/2)-(screenHeight/10), screenWidth/4, screenHeight/10), item.name, tempStyle);
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
