using UnityEngine;
using System.Collections;

public class LiftDoor : MonoBehaviour {

	public string keyRequired;

	void OnTriggerStay ()
	{
		if(Input.GetButtonDown("Interact"))
		{
			Debug.Log ("Interacted");
			if(GameObject.Find("Inventory").GetComponent<PlayerInventory>().findItem(keyRequired))
			{
				this.gameObject.transform.position = Vector3.Lerp(new Vector3(0,0,0), new Vector3(0,14,0), 1f);
			}
		}
	}
}
