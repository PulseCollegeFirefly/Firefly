using UnityEngine;
using System.Collections;

public class PlayerObjectPickUp : MonoBehaviour {

	public float pickupDistance;

	private bool holding = false;

	private RaycastHit hit;
	private GameObject hitObject;

	// Update is called once per frame
	void Update () {

		//
		// Put Down
		//
		
		if(Input.GetButtonDown("Interact") && holding == true)
		{
			// Turn Gravity and kinematic back
			hitObject.rigidbody.useGravity = true;
			hitObject.rigidbody.isKinematic = false;
			
			// Release the object
			hitObject.transform.parent = null;
			hitObject = null;
			
			holding = false;
		}

		//
		// Pick Up
		//

		//Raycast to the centre mouse position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(ray, out hit))
		{
			// Distance is less then the pickupDistance
			// The Tag is Interactable
			// The Interact button is pressed
			if(Input.GetButtonDown("Interact") && holding == false)
			{
				if(hit.distance < pickupDistance && hit.collider.tag == "Interactable")
				{
					// Make object a child object of player
					hitObject = hit.collider.gameObject;
					hitObject.transform.parent = gameObject.transform;

					// Turn Off Gravity
					hitObject.rigidbody.useGravity = false;
					hitObject.rigidbody.isKinematic = true;

					// Set Holding to true
					holding = true;
					Debug.Log ("Pick Up.");
				}
			}
		}

		// Show Raycast in Debug.
		Debug.DrawLine (ray.origin, hit.point);
	}
}
