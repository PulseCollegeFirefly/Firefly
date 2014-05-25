using UnityEngine;
using System.Collections;

public class MovementTutorial : MonoBehaviour {

	public string levelToLoad;
	public float fadeSpeed = 0.2f;
	public float waitTime = 5f;

	private bool sceneStarting = true;
	private bool sceneEnding = false;

	private Color guiColor;
	private float startTime;

	void Start ()
	{
		transform.position = Vector3.zero;
		transform.localScale = Vector3.zero;

		guiColor = Color.white;
		guiColor.a = 0;
		startTime = Time.deltaTime;

		guiTexture.color = guiColor;
		guiTexture.pixelInset = new Rect (0,0, Screen.width, Screen.height);
	}

	void OnGUI ()
	{
		//GUI.depth = -1;
		//GUI.DrawTexture( new Rect(0,0, screenWidth, screenHeight), guiTexture, ScaleMode.StretchToFill, true);
	}

	void Update ()
	{

		if(sceneStarting)
			StartScene();

		if(sceneEnding && !sceneStarting)
			EndScene ();

		if(Time.deltaTime - startTime <= waitTime)
			sceneEnding = true;

		guiTexture.color = guiColor;
	}

	void FadeToClear ()
	{
		// Lerp the colour of the texture to transparent
		guiColor.a = Mathf.Lerp (guiColor.a, 0, fadeSpeed * Time.deltaTime);
	}
	
	void FadeToBlack ()
	{
		// Lerp the colour of the texture to black
		guiColor.a = Mathf.Lerp (guiColor.a, 1, fadeSpeed * Time.deltaTime);
	}
	
	void StartScene ()
	{
		// Fade to clear
		FadeToBlack();
		
		// If Almost clear
		if(guiColor.a >= 0.95f)
		{
			// set to clear
			guiTexture.color = Color.white;
			
			// no longer starting;
			sceneStarting = false;
		}
	}
	
	public void EndScene()
	{
		// FadeToBlack :)
		FadeToClear();
		
		// if almost black
		if(guiColor.a <= 0.05f)
		{
			guiTexture.color = Color.black;
			Application.LoadLevel(levelToLoad);
		}
	}
}