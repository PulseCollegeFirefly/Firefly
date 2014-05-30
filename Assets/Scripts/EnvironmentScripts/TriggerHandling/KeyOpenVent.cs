using UnityEngine;
using System.Collections;

public class KeyOpenVent : MonoBehaviour {

	// Key Required
	public string keyRequired;
	
	private bool moveVent = false;
	
	void Update ()
	{
		if (moveVent)
		{
			turnOnRigidbody();
		}
	}
	
	void OnTriggerStay (Collider other)
	{
		if(other.tag == "Player")
		{
			if((GameObject.FindGameObjectWithTag("Inventory").GetComponent<GameInventory>().findItem(keyRequired) && GameObject.FindGameObjectWithTag("ActiveItem").GetComponent<PlayerItemControl> ().activeItem != null) || keyRequired == "Secret")
			{
				if(keyRequired == "Secret" || GameObject.FindGameObjectWithTag("ActiveItem").GetComponent<PlayerItemControl> ().activeItem.name == keyRequired)
				{	
					// Don't highlight secret doors
					if(keyRequired != "Secret")
						GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGUI>().activeTex = true;
					
					if(Input.GetButtonDown("Interact"))
					{
						
						moveVent = true;
						Destroy (this.gameObject.GetComponent<SphereCollider>());
						GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGUI>().activeTex = false;
					}
				}
				else 
				{
					GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGUI> ().activeTex = false;
				}
			}
			else 
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGUI> ().activeTex = false;
			}
		}
	}
	
	void OnTriggerExit (Collider p)
	{
		if(p.tag == "Player")
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGUI> ().activeTex = false;
	}

	private void turnOnRigidbody()
	{
		rigidbody.useGravity = true;
		rigidbody.isKinematic = false;
		moveVent = false;
	}
}
