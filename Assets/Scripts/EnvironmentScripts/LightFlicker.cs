using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {
	
	public float minFlickerSpeed = 0.01f;
	public float maxFlickerSpeed = 0.8f;

	public float minLightIntensity = 0.05f;
	public float maxLightIntensity = 0.95f;

	private bool isBusy = false;

	void Update () {
		if(!isBusy)
		{
			StartCoroutine(LightControl ());
		}
	}

	IEnumerator LightControl ()
	{
		// set to busy
		isBusy = true;

		// set intensity
		this.gameObject.light.intensity = Random.Range(minLightIntensity, maxLightIntensity);

		// flicker
		yield return new WaitForSeconds (Random.Range(minFlickerSpeed, maxFlickerSpeed));
		this.gameObject.light.enabled = !this.gameObject.light.enabled;

		// release
		isBusy = false;
	}
}