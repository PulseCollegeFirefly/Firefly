using UnityEngine;
using System.Collections;

public class PlayerHealthGUI : MonoBehaviour {

	public Texture healthBarTexture; // Health Bar Texture
	public float fadeSpeed = 2f; // The Speed of the lerp.
	public bool flash;

	private float playerHealth;
	private GameObject GameCon;
	private Color guiColor;

	// Private Variable
	private float highIntensity = 1f;
	private float lowIntensity = 0.02f;
	private float targetIntensity;
	private float changeMargin = 0.01f;

	private float screenWidth;
	private float screenHeight;

	void Awake ()
	{
		// Set GUIColor
		guiColor = Color.white;
		guiColor.a = 0;
		
		// Cache screen width and height. 
		screenWidth = Screen.width;
		screenHeight = Screen.height;

		// Cache GameCon
		GameCon = GameObject.FindGameObjectWithTag("GameController");
	}

	void Update ()
	{
		playerHealth = GameCon.GetComponent<GameController>().getHealth();

		// Intense flash
		if(flash || targetIntensity == highIntensity)
		{
			// If player leaves hit collider reduce the fade speed.
			if(!flash)
				fadeSpeed = 2;

			// Change intensity of Lerp
			guiColor.a = Mathf.Lerp(guiColor.a, targetIntensity, fadeSpeed * Time.deltaTime);
		}

		// Change intensity of Lerp after health falls below 90
		if(playerHealth < 90)
			guiColor.a = Mathf.Lerp(guiColor.a, targetIntensity, fadeSpeed * Time.deltaTime);



		// Check Target Intensity
		CheckTargetIntensity();
		
		// Check Target Speed
		if(flash)
			fadeSpeed = 5;
		else
			CheckTargetSpeed();
	}

	void OnGUI ()
	{
		GUI.color = guiColor;
		if(!healthBarTexture)
		{
			Debug.LogError("Assign a Texture in the inspector.");
			return;
		}

		// Draw healthBarTexture
		GUI.DrawTexture(new Rect(0, 0, screenWidth, screenHeight), healthBarTexture, ScaleMode.StretchToFill, true);
	}

	void CheckTargetIntensity()
	{
		if(Mathf.Abs (targetIntensity - guiColor.a) < changeMargin)
		{
			if(flash)
				highIntensity = 0.8f;
			else
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
		// Target Speed Chart
		if(playerHealth <= 100)
			fadeSpeed = 1f;

		if(playerHealth <= 70)
			fadeSpeed = 2f;

		if(playerHealth < 30 )
			fadeSpeed = 3f;
	}
}
