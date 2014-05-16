using UnityEngine;
using System.Collections;

public class SirenRotator : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(500, 0, 0) * Time.deltaTime);
	}
}
