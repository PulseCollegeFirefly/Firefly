using UnityEngine;
using System.Collections;

public class FanRotator : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, 0, 500) * Time.deltaTime);
	}
}
