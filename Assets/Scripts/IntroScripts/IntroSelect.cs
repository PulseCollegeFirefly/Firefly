using UnityEngine;
using System.Collections;

public class IntroSelect : MonoBehaviour {

	public float offset;
	public Texture introTexture;

	private float screenHeight;
	private float screenWidth;

	void Awake () {

		// Cache Screen Height and Width
		screenHeight = Screen.height;
		screenWidth = Screen.width;
	}
	
	void OnGUI () {

		// Load First Level
		if (GUI.Button(new Rect((screenWidth/2)-50, (screenHeight/2)+offset, 100, 50), "Start"))
			Application.LoadLevel("Level01");
	}
}
