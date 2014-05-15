using UnityEngine;
using System.Collections;

public class CellOpening : MonoBehaviour 
{
	//Force Upwards of the Explosion attached to the Celldoor
	public float upForce;
	//Force Outwards of the Explosion attached to the celldoor
	public float sideForce;
	//The Explosion Particle Effect prefab, had to be dragged manually into the inspector
	public GameObject explode;
	//A GameObject for the Player, can be Public and dragged or declared as down below
	GameObject thePlayer;
	GameObject gameController;
	//Same as Explosion except for Door fragments
	public GameObject doorFire1;
	public GameObject doorFire2;
	public GameObject doorFire3;
	GameObject MainLight;
	public GameObject spawningKeys;

	//An array of Rigidbodies for the Children of the door
	Rigidbody [] doorParts;

	// Use this for initialization

	void Start () 
	{
		gameController = GameObject.FindGameObjectWithTag("GameController");

		//Sets the Player FPC to the GameObject
		thePlayer = GameObject.FindGameObjectWithTag("Player");
		MainLight = GameObject.Find ("MainLight");
		//Defines all the rigidbodies in the doorParts array
		doorParts = GetComponentsInChildren<Rigidbody>();
		//Ensures Explosions begins as "off"
		explode.SetActive (false);
		doorFire1.SetActive (false);
		doorFire2.SetActive (false);
		doorFire3.SetActive (false);
		//Call the Coroutine, required due to timings involved
		// if the lvl is the first time round
		if(gameController.GetComponent<GameController> ().lvlCount == 0)
			StartCoroutine(DoorCoroutine ());
	}

	void Update ()
	{
		Screen.lockCursor = true;
	}


	public IEnumerator DoorCoroutine()		
	{	
		//Turns off the FirstPersonCharacter Script, prevents movement using the keys, but the mouse still looks around
		thePlayer.GetComponent<FirstPersonCharacter> ().enabled = false;
		thePlayer.GetComponent<Rigidbody>().detectCollisions = false;
		thePlayer.GetComponent<Rigidbody>().useGravity = false;
		//Wait for two seconds
		yield return new WaitForSeconds(2.0f);
		//Turns off the Keys
		spawningKeys.SetActive (false);
		//Turn on the Explosion particle effect
		explode.SetActive (true);
		//Shake the Camera
		thePlayer.GetComponent<PlayerHeadShake>().shakeHead();

		//Explode the door, turn on the gravity (the door is a little above the floor).

		//Loop that checks number of child objects with rigidbodies and modifies appropriate stats, I started with IsKinematic on so they dont react to each other on launch.
		for(var i=0; i< doorParts.Length; i++)
		{
			doorParts[i].isKinematic = false;
			doorParts[i].AddForce(transform.forward * sideForce);
			doorParts[i].AddForce(transform.up * upForce);
			doorParts[i].useGravity = true;
		}
		//Wait another two seconds
		MainLight.SetActive (false);
		yield return new WaitForSeconds (2.0f);
		//Turn on Fragment Fires
		doorFire1.SetActive (true);
		doorFire2.SetActive (true);
		doorFire3.SetActive (true);
		//Turn back on movement
		for(var i=0; i< doorParts.Length; i++)
		{
			doorParts[i].isKinematic = true;
			doorParts[i].useGravity = false;
		}
		thePlayer.GetComponent<FirstPersonCharacter> ().enabled = true;
		thePlayer.GetComponent<Rigidbody>().detectCollisions = true;
		thePlayer.GetComponent<Rigidbody>().useGravity = true;
	}

	// Release mouse lock
	void OnDisable()
	{
		Screen.lockCursor = false;
	}
}
