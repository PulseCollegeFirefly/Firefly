using UnityEngine;
using System.Collections;

public class RotateTap : MonoBehaviour {

	public GameObject tunnelBlock;
	public float fogLvl = 0.85f;
	public GameObject[] fans;

	// Key Required
	public string keyRequired;
	public float speed = 0.1f;
	
	private bool moveTap = false;
	private float startTime;	 

	void Update ()
	{
		if (moveTap)
		{
			Rotate(new Vector3(0, 240, 0), speed);
			turnOffFans();

			// Set new fog lvl after fans are turned Off.
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController> ().setFoglevel(fogLvl);
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
						
						moveTap = true;
						Destroy (this.gameObject.GetComponent<SphereCollider>());
						Destroy (tunnelBlock);
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
	
	private void Rotate(Vector3 rotate, float time)
	{
		Quaternion initialRot = transform.parent.localRotation;
		Quaternion targetRot = transform.parent.localRotation * Quaternion.Euler(rotate);
		float t = 0f;
		while (t < 1.0)
		{
			transform.parent.localRotation = Quaternion.Slerp(initialRot, targetRot, t);
			t += Time.deltaTime / time;
		}
		moveTap = false;
	}

	private void turnOffFans ()
	{
		foreach(GameObject fan in fans)
		{
			fan.GetComponent<FanRotator> ().enabled = false;
		}
	}
}
