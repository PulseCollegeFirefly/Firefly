using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public bool hasTimer; // Does this particular level have a timer. (NB needs to be moved to the gameController)
	public float timeToDie; // Same as above. Place holder for levels defined timer, in gameController.

	public float timer; // The amount of time taken
	public int healthTakeOffset = 5; // The amount of time between health time damage hits.
	
	private float playerHealth;
	private float timeDamage;

	private float screenWidth;
	private float screenHeight;

	private float timeTemp; // Temparary time variable
	
	void Start () {
		// On Start set player health to 100
		playerHealth = 100;

		// Calculate Damage
		timeDamage = playerHealth / (300 / healthTakeOffset);

		// Cache screen width and height. 
		screenWidth = Screen.width;
		screenHeight = Screen.height;

		// Set temp to 0
		timeTemp = 0;
		timer = 0;

		// hasTimerDefault
		hasTimer = true;


	}

	// Health Display // Needs to be overhalled with the art department. JOSH
	void OnGUI ()
	{
		GUI.Box(new Rect((screenHeight / 2)-(100), 10, 200 , 20), "");
		GUI.Box(new Rect((screenHeight / 2)-(100), 10, (2 * playerHealth), 20), "Health");
	}

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		timeTemp += Time.deltaTime;

		if(playerHealth <= 0)
		{
			dead();
		}

		if(timeTemp >= healthTakeOffset && hasTimer)
		{
			timeTemp = 0;
			DamageFromTime();
		}

	}

	void DamageFromTime () {
		playerHealth -= timeDamage;
		Debug.Log(timeDamage + " Damage has been done.");
	}

	void dead() {
		Debug.Log ("Player has died.");
	}
}
