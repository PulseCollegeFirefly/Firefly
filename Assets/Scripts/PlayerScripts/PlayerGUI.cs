using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour {
	
	public Texture activeTexture;
	public Texture defaultTexture;

	public bool activeTex;

	private Texture currentTexture;
	private float screenHeight;
	private float screenWidth;

	private GameObject gameController;
	private GameObject player;

	private MonoBehaviour Bloom;
	private MonoBehaviour Vignetting;

	void Start ()
	{
		// GameController
		gameController = GameObject.FindGameObjectWithTag ("GameController");

		// Player
		player = GameObject.FindGameObjectWithTag ("Player");
		Bloom = player.GetComponentInChildren<Bloom> ();
		Vignetting = player.GetComponentInChildren<Vignetting> ();

		// Cache Screen Height and Width
		screenHeight = Screen.height;
		screenWidth = Screen.width;

		// Default Texture
		currentTexture = defaultTexture;
	}

	void Update ()
	{
		CheckForCoolness ();

		if(player.GetComponent<PlayerObjectPickUp> ().interact && activeTex)
			SetActiveTexture(true);
		else
			SetActiveTexture(false);
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

	// Camera Effects
	public void CheckForCoolness ()
	{
		if (gameController.GetComponent<GameController> ().lvl () % 2 == 0 || gameController.GetComponent<GameController> ().lvl () == 0)
		{
			player.GetComponentInChildren<SSAOEffect> ().enabled = false;
			Bloom.enabled = false;
			Vignetting.enabled = false;
		}
		else
		{
			player.GetComponentInChildren<SSAOEffect> ().enabled = false;
			Bloom.enabled = true;
			Vignetting.enabled = true;
		}
	}

}
