using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	private float health; 
	private float timer;

	void Awake () {
		DontDestroyOnLoad(this.gameObject);
	}

	// Get and Set Health
	void setHealth (float h) {
		health = h;
	}

	public float getHealth () {
		return health;
	}

	// Get and Set Timer
	void setTimer (float t) {
		timer = t;
	}

	public float getTimer () {
		return timer;
	}
}
