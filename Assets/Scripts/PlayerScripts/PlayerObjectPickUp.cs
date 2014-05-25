using UnityEngine;
using System.Collections;

public class PlayerObjectPickUp : MonoBehaviour {

	public GameObject handLocation;
	public float pickupDistance;

	public bool interact {get; private set;} 

	private Vector3 rayLocation;
	private bool holding = false;
	private RaycastHit hit;
	private GameObject hitObject;
	private GameObject cachedObject;

	void Start () {

		rayLocation = new Vector3(Screen.width/2, Screen.height/2, pickupDistance);
	}

	// Update is called once per frame
	void Update () {

		//Raycast to the centre mouse position
		Ray ray = Camera.main.ScreenPointToRay(rayLocation);

		if(Physics.Raycast(ray, out hit) && holding == false)
		{
			// Set interact
			interact = hit.distance <= pickupDistance && (hit.collider.tag == "Interactable" || hit.collider.tag == "PickUp");

			//
			// Interact
			//
			if(interact)
			{
				// If Item is collectable
				if(hit.collider.tag == "PickUp")
				{
					// Set Active Texture
					GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGUI>().activeTex = true;

					// If interact pick up the object
					if(Input.GetButtonDown("Interact"))
					{
						// Add to Inventory
						if(hit.collider.gameObject.audio)
						{
							hit.collider.gameObject.audio.Play();	
						}
						GameObject.FindGameObjectWithTag("Inventory").GetComponent<GameInventory>().AddItem(hit.collider.gameObject, hit.collider.name+"Inv");
						GameObject.FindGameObjectWithTag("ActiveItem").GetComponent<PlayerItemControl>().UpdateObjects();

					}
				}
			}
			else
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGUI>().activeTex = false;
		}
	}
}