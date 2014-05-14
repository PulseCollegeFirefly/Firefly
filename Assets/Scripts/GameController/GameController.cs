using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	private float health=100; 
	private float timer;

	private bool[] hasItem;
	private GameObject[] inventorys;

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

	public void setInventorys(GameObject[] items) {
		inventorys = items;
	}

	public void setHasItems(bool[] invents)
	{
		hasItem = invents;
	}
}
