using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	private float health=100; 
	private float timer;
	private float fogLevel;

	public float lvlCount;
	public float fogOffset;
	public bool lockCusor;

	void Start ()
	{
		DontDestroyOnLoad(this.gameObject);
		Application.targetFrameRate = 26;

		QualitySettings.vSyncCount = 2;

		// This Value Controls Health
		setHealth (100);
		lvlCount = 0;
		fogLevel = 0;
		lockCusor = false;
	}

	void Update ()
	{
		// Game Timer
		timer += Time.deltaTime;

		// If user clicks lock mouse
		if (lockCusor)
		{
			Screen.lockCursor = true;
		}

		if(Application.loadedLevelName != "IntroScene" && Input.GetMouseButtonUp(0))
		{
			lockCusor = true;
		}
	}

	void OnDisable ()
	{
		lockCusor = false;
		Screen.lockCursor = false;
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

	public float lvl () {
		return lvlCount;
	}

	// Get and Set Fog Level
	public float getFogLevel () {
		return fogLevel;
	}

	public void setFoglevel (float f) {
		fogLevel = f;
	}
}
