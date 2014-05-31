using UnityEngine;
using System.Collections;

public class FanHeadShake : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void OnTriggerEnter (Collider p)
	{
		if(p.tag == "Player")
			player.GetComponent<PlayerHeadShake> ().shakeHead();
	}

	void OnTriggerStay (Collider p)
	{
		if(p.tag == "Player")
			player.GetComponent<PlayerHeadShake> ().shakeHead();
	}
}
