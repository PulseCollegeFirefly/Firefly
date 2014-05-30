using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	// Player Health
	private float playerHealth;
	private GameObject GameCon;

	// Set Time Between time damage hits
	public int generalDamageOffset = 8; // The amount of time between health time damage hits // general
	private int addDamageOffset = 0;

	// Temparary Variables
	private float damage;
	private float addDamage;
	private float timeTemp;

	void Awake () {

		// On Start set player health (Set in Game Controller)
		GameCon = GameObject.FindGameObjectWithTag("GameController");
		playerHealth = GameCon.GetComponent<GameController>().getHealth();

		// Calculate time Damage
		damage = playerHealth / (1000 / generalDamageOffset);

		// Set temp to 0
		timeTemp = 0;
	}

	void Update() {

		// Update Players Current Health and Timer.
		playerHealth = GameCon.GetComponent<GameController>().getHealth();

		// If player died
		if(playerHealth <= 0)
		{
			dead();
		}

		// If Additional damage due to Triggers
		if(timeTemp >= addDamageOffset && addDamageOffset != 0)
		{
			timeTemp = 0;
			DoDamage (addDamage);
		}

		// Else smoke damage
		if(timeTemp >= generalDamageOffset)
		{
			timeTemp = 0;
			DoDamage (damage);
		}

		// Increase timer
		timeTemp += Time.deltaTime;
	}

	// Set the Environmental Damage and time between hits
	public void SetEvDamage(float d, int a) {
		addDamage = d;
		addDamageOffset = a;
	}

	void dead () {
		Application.LoadLevel ("DeadScene");
	}

	void DoDamage(float d) {
		float h = playerHealth - d;
		GameCon.GetComponent<GameController>().setHealth(h);
	}
}
