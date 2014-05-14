using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	// Key Required
	public string keyRequired;
	
	public float offset;
	public float speed = 1f;

	private Vector3 newPosition;
	private bool moveDoor;
	private float startTime;
	private float journeyLength;

	void Awake ()
	{
		newPosition = new Vector3(transform.position.x-offset, transform.position.y, transform.position.z);
		journeyLength = Vector3.Distance(transform.position, newPosition);
		moveDoor = false;
	}

	void OnTriggerStay (Collider other)
	{
		if(other.tag == "Player")
		{
			if(Input.GetButtonDown("Interact"))
			{
				if(GameObject.FindGameObjectWithTag("Inventory").GetComponent<GameInventory>().findItem(keyRequired))
				{
					moveDoor = true;
					startTime = Time.time;
				}
			}
		}
	}

	void Update ()
	{
		if(moveDoor)
		{
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp (transform.position, newPosition, fracJourney);
		}
	}
}
