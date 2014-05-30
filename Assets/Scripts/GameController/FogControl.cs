using UnityEngine;
using System.Collections;

public class FogControl : MonoBehaviour {

	private float offset;
	private float currentFogLevel;
	private float playerHealth;

	void Start () {
		offset = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController> ().fogOffset;
		RenderSettings.fog = true;
	}
	
	// Update is called once per frame
	void Update () {
		// Update the Variables
		playerHealth = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController> ().getHealth();
		//currentFogLevel = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController> ().getFogLevel();

		// Check the Fog Level
		checkFogLevel (playerHealth);
	}

	void checkFogLevel (float pH)
	{
		float fogLvl = (100 - pH)/offset;
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController> ().setFoglevel(fogLvl);
	}
}
