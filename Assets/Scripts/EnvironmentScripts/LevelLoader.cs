using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	public string levelToLoad;

	void OnTriggerEnter (Collider other) {
		if(other.tag == "Player")
			Application.LoadLevel("Level02");
	}	
}
