using UnityEngine;
using System.Collections;

public class FirstFireTrigger : MonoBehaviour {

	//Declares GameObject, I dragged the Explosion1 GameObject onto this instead of declaring it

	public GameObject explode;
	public GameObject npc;
	public GameObject[] rubbles;

	void Start()
	{
		//Ensures Explosion is set of off on launch
		explode.SetActive (false);
		npc.SetActive (false);

		foreach(GameObject rubble in rubbles)
		{
			rubble.rigidbody.useGravity = false;
			rubble.rigidbody.isKinematic = true;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Player")
		{
			//Causes stumble
			other.GetComponent<PlayerHeadShake>().shakeHead();

			//Turns on Explosion Particle Effect and then Destroys the Trigger so it can't be re-used
			explode.SetActive (true);
			npc.SetActive (true);

			foreach(GameObject rubble in rubbles)
			{
				rubble.rigidbody.useGravity = true;
				rubble.rigidbody.isKinematic = false;
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player") {
			Destroy(this.gameObject);
		}
	}
}
