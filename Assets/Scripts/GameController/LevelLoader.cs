using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	public string levelToLoad;

	private GameObject player;
	private GameObject fader;
	private GameObject gameController;
	
	private bool sceneEnding = false;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		fader = GameObject.FindGameObjectWithTag("Fader");
		gameController = GameObject.FindGameObjectWithTag("GameController");
	}

	void OnTriggerEnter (Collider other) {
		if(other.tag == "Player")
		{
			// Enable the fader.
			fader.guiTexture.enabled = true;
			//fader.GetComponent<SceneFadeInOut> ().levelToLoad = levelToLoad;
			player.GetComponent<FirstPersonCharacter> ().enabled = false;

			// Inc the Level count
			gameController.GetComponent<GameController> ().incLvl();

			// Set Scene ending
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
		fader.GetComponent<SceneFadeInOut> ().EndScene(levelToLoad);
	}
}
