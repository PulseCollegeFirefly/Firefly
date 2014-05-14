using UnityEngine;
using System.Collections;

public class PlayerTorch : MonoBehaviour {

	// Torch Parts
	private GameObject torch;
	private Light torchLight;


	private GameObject player;
	private GameObject gameInventory;

	void Awake () {

		// Reference the player
		player = GameObject.FindGameObjectWithTag("Player");

		// Reference the Game Controller
		gameInventory = GameObject.FindGameObjectWithTag("GameController");

		// Reference Torch light and turn it off
		torchLight = player.GetComponentInChildren<Light>();
		torchLight.enabled = false;

		// Reference Torch Model and turn render off
		torch = this.gameObject;
		torch.renderer.enabled = false;
		torch.GetComponent<BoxCollider> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		// Check if the player has the torch in the inventory
		if(Input.GetButtonUp("Torch"))
		{
			if(gameInventory.GetComponentInChildren<GameInventory>().findItem("Torch"))
			{
				// Swap
				torchLight.enabled = !torchLight.enabled;
				torch.renderer.enabled = !torch.renderer.enabled;
				torch.GetComponent<BoxCollider> ().enabled = !torch.GetComponent<BoxCollider> ().enabled;
			}
		}
	}
}
