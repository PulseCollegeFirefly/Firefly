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
	private bool tutorialPlay = false;
	private Color guiColor;
	private float timer;

	private string msg = "";

	private bool pickUpPlayed = false;
	private bool interactPlayed = false;

	void Start () {
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

		msg = "";
	}

	void Update () {

		// If Player finds an object to pick up
		if(player.GetComponent<PlayerObjectPickUp> ().pickUp && !pickUpPlayed)
		{
			msg = "When Indicator turns Red, \nObjects can be picked up with \nusing the Left Mouse Click.";
			tutorialPlay = true;
			pickUpPlayed = true;
		}

		if(GameObject.Find ("GuardDoor").GetComponent<KeyOpenLock> ().tutorialCanBePlayed && pickUpPlayed)
		{
			msg = "Items held in your hand, \ncan be used to interact with \nobjects in the world.";
			tutorialPlay = true;
			interactPlayed = true;
		}


		// Play tutorial
		if(tutorialPlay)
			TutorialRun ();

		// When alpha reachs one, start timer
		if(guiColor.a == 1)
			timer += Time.deltaTime;

		// Set alpha to 0 when its reachs end
		if(timer >= timeEnd)
		{
			guiColor.a = 0;
			timer = 0;
			tutorialPlay = false;
			if(interactPlayed)
				Destroy(this.gameObject);
		}
	}

	void OnGUI ()
	{
		GUI.color = guiColor;
		GUI.Box( new Rect((screenWidth/2)+offset, (screenHeight/2)+offset, 195, 55), msg, font);
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
