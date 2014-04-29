using UnityEngine;
using System.Collections;

public class PlayerHealthGUI : MonoBehaviour {

	public Texture healthBarTexture; // Health Bar Texture
	public float fadeSpeed = 2f; // The Speed of the lerp.

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

		// Change intensity of Lerp
		if(playerHealth < 90)
			guiColor.a = Mathf.Lerp(guiColor.a, targetIntensity, fadeSpeed * Time.deltaTime);
		
		// Check Target Intensity
		CheckTargetIntensity();
		
		// Check Target Speed
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
