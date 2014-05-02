using UnityEngine;
using System.Collections;

public class DyingSoldier : MonoBehaviour {

	public float xSpeed;
	public float ySpeed;
	public float zSpeed;
	bool isDead = false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (transform.position.z < -0.3 && isDead == false)
		{
			animation.Play ("soldierDieBack", PlayMode.StopAll);
			isDead = true;
		}
		else
		if(isDead == false)
		{
			this.transform.Translate(xSpeed *Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
		}
	}
}
