using UnityEngine;
using System.Collections;

public class PlayerTorch : MonoBehaviour {

	// Torch Parts
	private GameObject torch;
	private Light torchLight;

	// Player
	private GameObject player;

	void Awake () {

		// Reference Torch light and turn it off
		torchLight = this.gameObject.GetComponentInChildren<Light>();
		torchLight.enabled = false;

		// Reference Torch Model and turn render off
		torch = this.gameObject;
		torch.renderer.enabled = false;

		// Reference the player
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		// Check if the player has the torch in the inventory
		if(Input.GetButtonUp("Torch"))
		{
			if(player.GetComponentInChildren<PlayerInventory>().findItem("Torch"))
			{
				// Swap
				torchLight.enabled = !torchLight.enabled;
				torch.renderer.enabled = !torch.renderer.enabled;
			}
		}
	}
}
