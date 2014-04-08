using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public Texture healthBarTexture; // Health Bar Texture
	public int healthTakeOffset = 5; // The amount of time between health time damage hits.
	public float fadeSpeed = 2f; // The Speed of the lerp.

	// Private Variable
	private float highIntensity = 1f;
	private float lowIntensity = 0.02f;
	private float targetIntensity;
	private float changeMargin = 0.01f;

	private float playerHealth;
	private Color guiColor;

	// Temparary Variables
	private float timeDamage;
	private float timeTemp;

	private float screenWidth;
	private float screenHeight;

	void Start() {
		// On Start set player health to 100
		playerHealth = 100;

		// Calculate Damage
		timeDamage = playerHealth / (300 / healthTakeOffset);

		// Set GUIColor
		guiColor = Color.white;
		guiColor.a = 0;

		// Cache screen width and height. 
		screenWidth = Screen.width;
		screenHeight = Screen.height;

		// Set temp to 0
		timeTemp = 0;
	}

	// Health Display // Needs to be overhalled with the art department. JOSH
	void OnGUI()
	{
		GUI.color = guiColor;
		if(!healthBarTexture)
		{
			Debug.LogError("Assign a Texture in the inspector.");
			return;
		}

		GUI.DrawTexture(new Rect(0, 0, screenWidth, screenHeight), healthBarTexture, ScaleMode.StretchToFill, true);
	}

	// Update is called once per frame
	void Update() {

		timeTemp += Time.deltaTime;

		// Change intensity of Lerp
		if(playerHealth < 90)
			guiColor.a = Mathf.Lerp(guiColor.a, targetIntensity, fadeSpeed * Time.deltaTime);

		// Check Target Intensity
		CheckTargetIntensity();

		// Check Target Speed
		CheckTargetSpeed();

		// If player died
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

	void DamageFromTime() {
		playerHealth -= timeDamage;
		Debug.Log(timeDamage + " Damage has been done.");
	}

	void dead () {
		Debug.Log ("Player has died.");
	}

	void CheckTargetIntensity()
	{
		if(Mathf.Abs (targetIntensity - guiColor.a) < changeMargin)
		{
			highIntensity = 1 - (playerHealth / 100);

			if(targetIntensity == highIntensity)
			{
				targetIntensity = lowIntensity;
			}
			else
			{
				targetIntensity = highIntensity;
			}
		}
	}

	void CheckTargetSpeed()
	{
		if(playerHealth < 30 )
		{
			fadeSpeed = 3f;
		}
	}
}
