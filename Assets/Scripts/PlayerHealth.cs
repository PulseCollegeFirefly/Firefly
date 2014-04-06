using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public Texture healthBarTexture;
	public float timer; // The amount of time taken
	public int healthTakeOffset = 5; // The amount of time between health time damage hits.

	private float playerHealth;
	private float timeDamage;
	private float timeTemp; // Temparary time variable

	private float screenWidth;
	private float screenHeight;

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
	}

	// Health Display // Needs to be overhalled with the art department. JOSH
	void OnGUI ()
	{
		if(!healthBarTexture)
		{
			Debug.LogError("Assign a Texture in the inspector.");
			return;
		}


		GUI.DrawTexture(new Rect(0, 0, screenWidth, screenHeight), healthBarTexture, ScaleMode.StretchToFill, true);
	}

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		timeTemp += Time.deltaTime;

		if(playerHealth <= 0)
		{
			dead();
		}

		if(timeTemp >= healthTakeOffset)
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
