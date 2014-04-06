using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public Texture healthBarTexture;
	public float timer; // The amount of time taken
	public int healthTakeOffset = 5; // The amount of time between health time damage hits.

	public float fadeSpeed = 2f;
	public float highIntensity = 1f;
	public float lowIntensity = 0.05f;
	public float targetIntensity;
	public float changeMargin = 0.01f;
	public float healthBarOn;


	private float playerHealth;
	private Color guiColor;



	// Temparary Variables
	private float timeDamage;
	private float timeTemp; // Temparary time variable

	private float screenWidth;
	private float screenHeight;

	void Start() {
		// On Start set player health to 100
		playerHealth = 100;

		// Calculate Damage
		timeDamage = playerHealth / (300 / healthTakeOffset);

		// Set guiColor
		guiColor = Color.white;
		guiColor.a = 0;

		// Cache screen width and height. 
		screenWidth = Screen.width;
		screenHeight = Screen.height;

		// Set temp to 0
		timeTemp = 0;
		timer = 0;
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


		HealthBarTextureDraw();
	}

	// Update is called once per frame
	void Update() {

		timer += Time.deltaTime;
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

	void HealthBarTextureDraw(){
		GUI.DrawTexture(new Rect(0, 0, screenWidth, screenHeight), healthBarTexture, ScaleMode.StretchToFill, true);
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
		return;
	}
}
