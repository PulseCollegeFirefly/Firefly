using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	private float health=100; 
	private float timer;

	void Start ()
	{
		DontDestroyOnLoad(this.gameObject);

		// This Value Controls Health
		setHealth (100);
	}

	void Update ()
	{
		// Game Timer
		timer += Time.deltaTime;
	}

	// Get and Set Health
	public void setHealth (float h) {
		health = h;
	}

	public float getHealth () {
		return health;
	}

	// Get Timer
	public float getTimer () {
		return timer;
	}
}
