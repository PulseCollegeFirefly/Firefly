using UnityEngine;
using System.Collections;

public class KeyOpenLock : MonoBehaviour {

	// Key Required
	public string keyRequired;
	public float speed = 1f;

	private bool moveDoor = false;
	private float startTime;
	
	void Update ()
	{
		if (moveDoor)
			//Destroy (this.gameObject);
			RotateDoor(new Vector3(0, 240, 0), speed);
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

						moveDoor = true;
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

	private void RotateDoor(Vector3 rotate, float time)
	{
		Quaternion initialRot = transform.parent.localRotation;
		Quaternion targetRot = transform.parent.localRotation * Quaternion.Euler(rotate);
		float t = 0f;
		while (t < 1.0)
		{
			transform.parent.localRotation = Quaternion.Slerp(initialRot, targetRot, t);
			t += Time.deltaTime / time;
		}
		moveDoor = false;
	}
}
