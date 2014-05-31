using UnityEngine;
using System.Collections;

public class SwitchBehaviour : MonoBehaviour {

	public string Switch;

	private GameObject[] ds;
	private bool opened = false;

	void Awake ()
	{
		ds = GameObject.FindGameObjectsWithTag(Switch);
	}

	void OnTriggerStay(Collider c)
	{
		if(c.tag == "Player" && !opened)
		{
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGUI>().activeTex = true;

			// If interact
			if (Input.GetButtonUp("Interact")) {
				foreach(GameObject d in ds)
				{
					d.GetComponent<OpenDoor> ().MoveDoor();
					GameObject.Find ("GameController").GetComponent<LevelState>().PrisonDoor = true;
					opened = true;
				}
			}
		}
	}
}
