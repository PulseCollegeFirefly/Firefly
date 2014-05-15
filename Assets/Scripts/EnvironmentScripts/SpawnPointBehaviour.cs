using UnityEngine;
using System.Collections;

public class SpawnPointBehaviour : MonoBehaviour {

	private Transform myTransform;
	private GameObject player;

	void Start () {

		// Check whether to activate
		this.gameObject.GetComponent<SpawnPointBehaviour>().enabled = CheckIfStart();

		// Reference Player and local location
		player = GameObject.FindGameObjectWithTag("Player");
		myTransform = this.gameObject.transform;

		// If active set player to spawn position
		if(this.gameObject.GetComponent<SpawnPointBehaviour> ().enabled == true)
		{
			player.transform.position = myTransform.position;
			player.transform.rotation = myTransform.rotation;
		}
	}

	private bool CheckIfStart()
	{
		if(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController> ().lvl() != 0)
			return true;
		else
			return false;
	}
}
