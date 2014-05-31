using UnityEngine;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour {

	public float fadeSpeed = 0.2f;

	private bool sceneStarting = true;

	void Awake ()
	{
		// Set Texture to size of screen
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}

	void Update ()
	{
		if(sceneStarting)
			StartScene();
	}

	void FadeToClear ()
	{
		// Lerp the colour of the texture to transparent
		guiTexture.color = Color.Lerp (guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}

	void FadeToBlack ()
	{
		// Lerp the colour of the texture to black
		guiTexture.color = Color.Lerp (guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	}

	void StartScene ()
	{
		// Fade to clear
		FadeToClear();

		// If Almost clear
		if(guiTexture.color.a <= 0.03f)
		{
			// set to clear
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;

			// no longer starting;
			sceneStarting = false;
		}
	}

	public void EndScene(string levelToLoad)
	{
		// FadeToBlack :)
		FadeToBlack();

		// if almost black
		if(guiTexture.color.a >= 0.95f)
		{
			guiTexture.color = Color.black;
			Application.LoadLevel(levelToLoad);
		}
	}
}
