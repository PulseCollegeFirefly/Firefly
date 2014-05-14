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

		// Start new GUI Group
		GUI.BeginGroup( new Rect(0, 0, screenWidth, screenHeight));

		GUI.DrawTexture (new Rect (0, 0, screenWidth, screenHeight), introTexture, ScaleMode.StretchToFill, true);

		// Load First Level
		if (GUI.Button(new Rect((screenWidth/2)-50, (screenHeight/2)+offset, 100, 50), "Start"))
			Application.LoadLevel("Level01");

		// End GUI Group
		GUI.EndGroup();
	}
}
