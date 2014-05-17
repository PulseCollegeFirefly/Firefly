using UnityEngine;
using System.Collections;

public class WardensOfficeEntry : MonoBehaviour {

	public GameObject[] rubbles;
	public GameObject fire;

	// Use this for initialization
	void Awake () {

		foreach(GameObject rubble in rubbles)
		{
			rubble.rigidbody.useGravity = false;
			rubble.rigidbody.isKinematic = true;
			rubble.collider.enabled = false;

			// Render
			Switch(rubble);
		}

	}
	
	void OnTriggerExit (Collider p) {

		if(p.tag == "Player")
		{
			foreach(GameObject rubble in rubbles)
			{
				rubble.collider.enabled = true;
				rubble.rigidbody.useGravity = true;
				rubble.rigidbody.isKinematic = false;

				Switch (rubble);
			}
			fire.SetActive (true);
		}

		this.gameObject.GetComponent<BoxCollider> ().isTrigger = false;
	}

	private void Switch(GameObject a)
	{
		Renderer[] renderers = a.GetComponentsInChildren<Renderer>();
		
		foreach (Renderer r in renderers)
		{
			r.enabled = !r.enabled;
		}
	}
}
