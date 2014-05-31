using UnityEngine;
using System.Collections;

public class KeyOpenLock : MonoBehaviour {

	// Key Required
	public string keyRequired;
	public float speed = 1f;
	public float degrees = 90f;

	public bool tutorialCanBePlayed {get; private set;}

	public bool moveDoor = false;
	private float startTime;

	private Quaternion initialRot;
	private Quaternion targetRot;

	void Start ()
	{
		targetRot = transform.parent.localRotation * Quaternion.Euler(new Vector3(0,degrees,0));
	}

	void Update ()
	{
		if (moveDoor)
		{
			Quaternion currentRot = transform.parent.localRotation;
			float step = speed * Time.deltaTime;
			transform.parent.localRotation = Quaternion.RotateTowards(currentRot, targetRot, step);
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
					{
						GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGUI>().activeTex = true;
						tutorialCanBePlayed = true;
					}

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
}
