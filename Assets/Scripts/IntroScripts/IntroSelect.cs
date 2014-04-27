using UnityEngine;
using System.Collections;

public class IntroSelect : MonoBehaviour {

	public float offset;

	private float screenHeight;
	private float screenWidth;

	void Awake () {

		// Cache Screen Height and Width
		screenHeight = Screen.height;
		screenWidth = Screen.width;
	}
	
	void OnGUI () {

		// Start new GUI Group
		GUI.BeginGroup( new Rect(offset,offset,screenWidth-(offset*2),screenHeight-(offset*2)));

		// Title Bar
		GUI.Box( new Rect(0,0, 100, 100), "Project Firefly.");

		// Load First Level
		if (GUI.Button(new Rect(100, 100, 200, 30), "Start"))
			Application.LoadLevel("Level01");

		// End GUI Group
		GUI.EndGroup();
	}
}
