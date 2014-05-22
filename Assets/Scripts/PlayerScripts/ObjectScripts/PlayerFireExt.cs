using UnityEngine;
using System.Collections;

public class PlayerFireExt : MonoBehaviour {

	// Key Parts
	private GameObject fireExt;
	private GameObject activeItem;
	private ParticleSystem steam;
	
	void Awake () {
		
		// Reference Torch Model and turn render off
		fireExt = this.gameObject;
		fireExt.renderer.enabled = false;
		fireExt.GetComponent<BoxCollider> ().enabled = false;

		// Reference Steam
		steam = GameObject.FindGameObjectWithTag("Steam").GetComponent<ParticleSystem> ();
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
			fireExt.renderer.enabled = true;
			fireExt.GetComponent<BoxCollider> ().enabled = true;

			if(Input.GetButton("Interact"))
			{
				Debug.Log("Pressed");
				if (steam != null)
					steam.Play ();

				if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerObjectPickUp> ().interact)
				{
					GameObject enterWardinsOffice = GameObject.Find ("EnterWardinsOffice");

					if(enterWardinsOffice != null)
					{
						enterWardinsOffice.GetComponent<WardensOfficeEntry> ().setFire(false);

						Destroy (GameObject.Find ("FireTriggerExit"));
						Destroy (steam);
						Destroy (enterWardinsOffice);
					}
				}	
			}
			else
				if(steam != null)
					steam.Stop ();
		}
		else
		{
			fireExt.renderer.enabled = false;
			fireExt.GetComponent<BoxCollider> ().enabled = false;

			if(steam != null)
				steam.Stop ();
		}
	}
}
