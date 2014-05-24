using UnityEngine;
using System.Collections;

public class IntroSelect : MonoBehaviour {

	public float offset;
	public Transform lookAtTarget;

	private float screenHeight;
	private float screenWidth;

	void Awake ()
	{
		// Cache Screen Height and Width
		screenHeight = Screen.height;
		screenWidth = Screen.width;
	}

	void Update ()
	{
		// Move Camera
		transform.LookAt(lookAtTarget);
		transform.Translate(Vector3.right * Time.deltaTime);
	}
	
	void OnGUI ()
	{
		// Load First Level
		if (GUI.Button(new Rect((screenWidth/2)-50, (screenHeight/2)+offset, 100, 50), "Start"))
		{
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController> ().lockCusor = true;
			Application.LoadLevel("Level01");
		}
	}
}
