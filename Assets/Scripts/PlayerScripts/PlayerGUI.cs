using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour {
	
	public Texture activeTexture;
	public Texture defaultTexture;

	private Texture currentTexture;

	private float screenHeight;
	private float screenWidth;

	void Start () {
		// Cache Screen Height and Width
		screenHeight = Screen.height;
		screenWidth = Screen.width;

		// Default Texture
		currentTexture = defaultTexture;
	}

	void OnGUI ()
	{
		GUI.DrawTexture( new Rect((screenWidth/2-6), (screenHeight/2-6), 12, 12), currentTexture);
	}

	public void SetActiveTexture(bool status)
	{
		if(status)
			currentTexture = activeTexture;
		else
			currentTexture = defaultTexture;
	}

}
