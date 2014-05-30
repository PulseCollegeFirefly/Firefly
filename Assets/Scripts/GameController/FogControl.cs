using UnityEngine;
using System.Collections;

public class FogControl : MonoBehaviour {

	public float changeMargin;

	private float offset;
	private float currentFogLevel;
	private float playerHealth;
	private GameObject gameController;

	void Start () {
		// Reference Game Controller
		gameController = GameObject.FindGameObjectWithTag("GameController");
		offset = gameController.GetComponent<GameController> ().fogOffset;

		// Turn Off fog.
		RenderSettings.fog = true;
	}
	
	// Update is called once per frame
	void Update () {
		// Update the Variables
		playerHealth = gameController.GetComponent<GameController> ().getHealth();

		// Check the Fog Level
		checkFogLevel (playerHealth);
	}

	void checkFogLevel (float pH)
	{
		float fogLvl = (100 - pH)/offset;

		gameController.GetComponent<GameController> ().setFoglevel(fogLvl);
	}
}
