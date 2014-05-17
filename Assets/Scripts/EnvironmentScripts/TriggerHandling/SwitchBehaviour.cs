using UnityEngine;
using System.Collections;

public class SwitchBehaviour : MonoBehaviour {

	public string Switch;

	private GameObject[] ds;

	void Awake ()
	{
		ds = GameObject.FindGameObjectsWithTag(Switch);
	}

	void OnTriggerStay(Collider c)
	{
		if (c.tag == "Player" && Input.GetButtonUp("Interact")) {
			foreach(GameObject d in ds)
			{
				d.GetComponent<OpenDoor> ().MoveDoor();
			}	
		}
	}
}
