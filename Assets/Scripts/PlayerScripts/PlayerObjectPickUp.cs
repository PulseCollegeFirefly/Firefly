using UnityEngine;
using System.Collections;

public class PlayerObjectPickUp : MonoBehaviour {

	public float pickupDistance;
	public GameObject handLocation;

	private bool holding = false;
	private RaycastHit hit;
	private GameObject hitObject;

	// Update is called once per frame
	void Update () {

		//Raycast to the centre mouse position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

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

		if(Physics.Raycast(ray, out hit))
		{
			// Distance is less then the pickupDistance
			// The Tag is Interactable
			// The Interact button is pressed
			if(Input.GetButtonDown("Interact") && holding == false)
			{
				if(hit.distance < pickupDistance && hit.collider.tag == "Interactable")
				{
					hitObject = hit.collider.gameObject;

					// Turn Off Gravity
					hitObject.rigidbody.useGravity = false;
					hitObject.rigidbody.isKinematic = true;

					// Make object a child object of player
					hitObject.transform.parent = gameObject.transform;

					//
					// (Optional)
					hitObject.transform.position = handLocation.transform.position;

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
