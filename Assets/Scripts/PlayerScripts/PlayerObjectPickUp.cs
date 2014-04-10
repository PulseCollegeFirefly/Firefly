using UnityEngine;
using System.Collections;

public class PlayerObjectPickUp : MonoBehaviour {

	public GameObject handLocation;

	private Vector3 rayLocation;
	private float pickupDistance;
	private bool holding = false;
	private RaycastHit hit;
	private GameObject hitObject;
	private GameObject cachedObject;

	void Start () {
		pickupDistance = handLocation.transform.localPosition.z;
		rayLocation = new Vector3(Screen.width/2, Screen.height/2, handLocation.transform.localPosition.z);
	}

	// Update is called once per frame
	void Update () {

		//Raycast to the centre mouse position
		Ray ray = Camera.main.ScreenPointToRay(rayLocation);

		if(Physics.Raycast(ray, out hit) && holding == false)
		{
			//
			// Pick Up
			//
			if(Input.GetButtonDown("Interact"))
			{
				if(hit.distance <= pickupDistance && hit.collider.tag == "Interactable")
				{
					hitObject = hit.collider.gameObject;
					cachedObject = hitObject;

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
		else
		{
			//
			// Put Down
			//
			if(Input.GetButtonDown("Interact") && holding == true)
			{
				// Turn Gravity and kinematic back
				cachedObject.rigidbody.useGravity = true;
				cachedObject.rigidbody.isKinematic = false;
			
				// Release the object
				cachedObject.transform.parent = null;
				cachedObject = null;
			
				holding = false;
				Debug.Log ("Put Down");
			}

			// Show Raycast in Debug.
			Debug.DrawLine (ray.origin, hit.point);
		}
	}
}