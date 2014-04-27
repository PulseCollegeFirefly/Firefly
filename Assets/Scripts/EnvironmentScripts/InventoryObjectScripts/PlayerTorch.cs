using UnityEngine;
using System.Collections;

public class PlayerTorch : MonoBehaviour {

	private Light torch;
	private GameObject player;

	void Awake () {

		// Reference Torch and turn it off
		torch = this.gameObject.GetComponent<Light>();
		torch.enabled = false;

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
				torch.enabled = !torch.enabled;
			}
		}
	}
}
