using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	private float health=100; 
	private float timer;
	public int lvlCount;

	void Start ()
	{
		DontDestroyOnLoad(this.gameObject);
		Application.targetFrameRate = 26;

		QualitySettings.vSyncCount = 2;

		// This Value Controls Health
		setHealth (100);
		lvlCount = 0;
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

	// Get and Set lvlCount
	public void incLvl () {
		lvlCount++;
	}

	public int lvl () {
		return lvlCount;
	}
}
