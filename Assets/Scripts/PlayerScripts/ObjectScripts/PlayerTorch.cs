using UnityEngine;
using System.Collections;

public class PlayerTorch : MonoBehaviour {

	// Torch Parts
	private GameObject torch;
	private Light torchLight;

	private GameObject player;
	private GameObject activeItem;

	void Awake () {

		// Reference the player
		player = GameObject.FindGameObjectWithTag("Player");

		// Reference Torch light and turn it off
		torchLight = player.GetComponentInChildren<Light>();
		torchLight.enabled = false;

		// Reference Torch Model and turn render off
		torch = this.gameObject;
		torch.renderer.enabled = false;
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
			torchLight.enabled = true;
			torch.renderer.enabled = true;
		}
		else
		{
			torchLight.enabled = false;
			torch.renderer.enabled = false;
		}
	}
}
