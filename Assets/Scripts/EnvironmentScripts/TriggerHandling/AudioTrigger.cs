using UnityEngine;
using System.Collections;

public class AudioTrigger : MonoBehaviour {

	public AudioClip audioClip;

	private bool hasPlayed = false;

	void OnTriggerEnter (Collider p)
	{
		if(p.tag == "Player")
		{
			if(!hasPlayed)
			{
				this.gameObject.audio.PlayOneShot (audioClip);
				hasPlayed = true;
			}

		}
	}
}
