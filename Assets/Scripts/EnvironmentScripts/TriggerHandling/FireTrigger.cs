using UnityEngine;
using System.Collections;

public class FireTrigger : MonoBehaviour {

	// Set Damage Variables.
	public float damage;
	public int damageOffset;

	// Damage to the Variables On Entry.
	void OnTriggerStay (Collider other) {
		if(other.tag == "Player") {
			other.GetComponent<PlayerHealth> ().SetEvDamage(damage, damageOffset);
			other.GetComponent<PlayerHealthGUI> ().flash = true;
			Debug.Log ("Entered Fire");
		}
	}

	// Have them set to 0 on Exit.
	void OnTriggerExit (Collider other) {
		if(other.tag == "Player") {
			other.GetComponent<PlayerHealth> ().SetEvDamage(0, 0);
			other.GetComponent<PlayerHealthGUI> ().flash = false;
			Debug.Log ("Left Fire");
		}
	}
}
