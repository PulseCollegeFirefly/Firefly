using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public float offset;
	public string[] creditNames;
	public float fadeSpeed = 2f;

	private int count;
	private Color guiColor;
	private float screenHeight;
	private float screenWidth;

	private float highIntensity = 1f;
	private float lowIntensity = 0.02f;
	private float targetIntensity;
	private float changeMargin = 0.01f;

	void Start () {

		// Set GUIColor
		guiColor = Color.white;
		guiColor.a = 0;

		// Set TargetIntensity
		targetIntensity = highIntensity;

		// Cache the Screen Height and Width
		screenHeight = Screen.height;
		screenWidth = Screen.width;

		// Set Count to 0
		count = 0;
	}

	void Update () {

		// Lerp the Alpha to the target intensity
		guiColor.a = Mathf.Lerp(guiColor.a, targetIntensity, fadeSpeed * Time.deltaTime);

		// If target intensity is == to low && the gui Alpha is within the change margin
		if(targetIntensity == lowIntensity && Mathf.Abs (targetIntensity - guiColor.a) < changeMargin)
		{
			LineEmUpSally();
			if(count == creditNames.Length)
				Destroy (this.gameObject);
		}

		// Check Target Intensity
		CheckTargetIntensity();
	}

	// Return Current Name
	private string CurrentName () {
		return creditNames[count];
	}

	void OnGUI () {

		GUI.color = guiColor;
		GUI.BeginGroup( new Rect(offset, offset, screenWidth-(offset*2), screenHeight-(offset*2)));
		GUI.Box( new Rect(0,0,130,30), CurrentName());
		GUI.EndGroup();
	}

	void LineEmUpSally () {
		count++;

	}

	void CheckTargetIntensity()
	{
		if(Mathf.Abs (targetIntensity - guiColor.a) < changeMargin)
		{	
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
}
