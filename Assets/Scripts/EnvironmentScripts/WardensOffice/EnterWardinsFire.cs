using UnityEngine;
using System.Collections;

public class EnterWardinsFire : MonoBehaviour {

	// Set Damage Variables.
	public float damage;
	public int damageOffset;

	private GameObject player;
	private PlayerHealth playerHealth;
	private PlayerHealthGUI playerHealthGUI;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		playerHealthGUI = player.GetComponent<PlayerHealthGUI> ();
	}

	// Damage to the Variables On Entry.
	void OnTriggerStay (Collider other) {
		if(other.tag == "Player") {
			playerHealth.SetEvDamage(damage, damageOffset);
			playerHealthGUI.flash = true;
		}
	}
	
	// Have them set to 0 on Exit.
	void OnTriggerExit (Collider other) {
		if(other.tag == "Player") {
			playerHealth.SetEvDamage(0, 0);
			playerHealthGUI.flash = false;
		}
	}

	void OnDestroy ()
	{
		playerHealth.SetEvDamage(0, 0);
		playerHealthGUI.flash = false;
	}
}
