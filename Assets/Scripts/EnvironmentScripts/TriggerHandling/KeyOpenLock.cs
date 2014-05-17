using UnityEngine;
using System.Collections;

public class KeyOpenLock : MonoBehaviour {

	// Key Required
	public string keyRequired;
	public float speed = 1f;

	private bool moveDoor = false;
	private float startTime;
	
	void Update ()
	{
		if (moveDoor)
			Destroy (this.gameObject);
			//RotateDoor(new Vector3(0, 90, 0), speed);
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
				}
			}
		}
	}

	private void RotateDoor(Vector3 rotate, float time)
	{
		Quaternion initialRot = transform.localRotation;
		Quaternion targetRot = transform.localRotation * Quaternion.Euler(rotate);
		float t = 0f;
		while (t < 1.0)
		{
			transform.localRotation = Quaternion.Slerp(initialRot, targetRot, t);
			t += Time.deltaTime / time;
		}
		moveDoor = false;
	}
}
