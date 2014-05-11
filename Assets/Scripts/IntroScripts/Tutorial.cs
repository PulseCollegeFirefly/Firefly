using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public float offset = 0;
	public float fadeSpeed = 1.5f;
	public GUIStyle font;
	public float timeEnd = 2;

	private GameObject player;
	private float screenWidth;
	private float screenHeight;
	private bool tutorialStart = false;
	private Color guiColor;
	private float timer;

	void Awake () {
		// Find Player
		player = GameObject.FindGameObjectWithTag("Player");

		// Cache Screen
		screenWidth = Screen.width;
		screenHeight = Screen.height;

		// Set GUI Text Color back to the one defined in the inspector
		guiColor = font.normal.textColor;

		// Change its alpha back to zero
		guiColor.a = 0;

		// Set timer to zero
		timer = 0;
	}

	void Update () {
		if(player.GetComponent<PlayerObjectPickUp> ().interact)
			tutorialStart = true;

		if(tutorialStart)
			TutorialRun ();

		if(guiColor.a == 1)
			timer += Time.deltaTime;

		if(timer >= timeEnd)
			Destroy (this.gameObject);
	}

	void OnGUI ()
	{
		GUI.color = guiColor;
		GUI.Box( new Rect((screenWidth/2)+offset, (screenHeight/2)+offset, 195, 55), "When Indicator turns Red, \nObjects can be interacted with \nusing the Left Mouse Click.", font);
	}

	void TutorialRun ()
	{
		guiColor.a = Mathf.Lerp(guiColor.a, 1, fadeSpeed * Time.deltaTime);

		// if almost
		if(guiColor.a >= 0.95f)
		{
			guiColor.a = 1;
		}
	}
}
