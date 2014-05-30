﻿using UnityEngine;
using System.Collections;

public class RandomAudio : MonoBehaviour 
{
	public AudioClip[] PrisonSound;
	bool isRunning = false;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isRunning ==false)
		{
			isRunning = true;
			audio.clip = PrisonSound[Random.Range (1,5)];
			audio.Play ();
			StartCoroutine(RandomSound ());
		}
	}
	public IEnumerator RandomSound ()
	{
		yield return new WaitForSeconds(10.0f);
		isRunning = false;
	}
}
