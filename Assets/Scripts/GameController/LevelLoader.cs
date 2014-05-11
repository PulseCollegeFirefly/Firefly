using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	public string levelToLoad;

	private GameObject player;
	private GameObject fader;
	
	private bool sceneEnding = false;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		fader = GameObject.FindGameObjectWithTag("Fader");
	}

	void OnTriggerEnter (Collider other) {
		if(other.tag == "Player")
		{
			fader.guiTexture.enabled = true;
			fader.GetComponent<SceneFadeInOut> ().levelToLoad = levelToLoad;
			player.GetComponent<FirstPersonCharacter> ().enabled = false;
			sceneEnding = true;
		}
	}

	void Update ()
	{
		if(sceneEnding)
			EndScene ();
	}

	void EndScene ()
	{
		fader.GetComponent<SceneFadeInOut> ().EndScene();
	}
}
