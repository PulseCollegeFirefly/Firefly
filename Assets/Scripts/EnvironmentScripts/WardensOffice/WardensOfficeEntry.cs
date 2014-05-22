using UnityEngine;
using System.Collections;

public class WardensOfficeEntry : MonoBehaviour {

	public GameObject[] rubbles;
	public GameObject fire;
	public GameObject fireDamage;

	// Use this for initialization
	void Awake ()
	{
		foreach(GameObject rubble in rubbles)
		{
			// Set Box Collider Off
			this.gameObject.GetComponent<BoxCollider> ().enabled = false;

			// Set up rubble objects
			rubble.rigidbody.useGravity = false;
			rubble.rigidbody.isKinematic = true;
			rubble.collider.enabled = false;

			// Render
			Switch(rubble);
		}

		// turn off fire damage
		fireDamage.SetActive (false);

	}
	
	void OnTriggerExit (Collider p) 
	{

		if(p.tag == "Player")
		{
			foreach(GameObject rubble in rubbles)
			{
				rubble.collider.enabled = true;
				rubble.rigidbody.useGravity = true;
				rubble.rigidbody.isKinematic = false;

				Switch (rubble);
			}
			setFire (true);
			fireDamage.SetActive (true);
		}

		// Destory the Sphere Collider and enable the Box Collider
		this.gameObject.GetComponent<BoxCollider> ().enabled = true;
		Destroy (this.gameObject.GetComponent<SphereCollider> ());
	}

	private void Switch(GameObject a)
	{
		Renderer[] renderers = a.GetComponentsInChildren<Renderer>();
		
		foreach (Renderer r in renderers)
		{
			r.enabled = !r.enabled;
		}
	}

	public void setFire(bool b)
	{
		fire.SetActive(b);
	}
}
