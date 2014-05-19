using UnityEngine;
using System.Collections;

public class DyingSoldier : MonoBehaviour {

	public float xSpeed;
	public float ySpeed;
	public float zSpeed;
	bool isDead = false;
	public GameObject drop;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (transform.position.z < -0.3 && isDead == false)
		{
			StartCoroutine(Spawn ());
		}
		else
		if(isDead == false)
		{
			this.transform.Translate(xSpeed *Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
		}
	}
	public IEnumerator Spawn()		
	{
		animation.Play ("soldierDieBack", PlayMode.StopAll);
		isDead = true;
		if(GameObject.Find ("GameController").GetComponent<LevelState>().DyingSoldier == false)
		{		
			drop.SetActive (true);
			drop.GetComponent<AudioSource>().enabled = true;
			yield return new WaitForSeconds(2.0f);
			drop.GetComponent<Rigidbody>().detectCollisions = false;
			drop.GetComponent<Rigidbody>().useGravity = false;
			GameObject.Find ("GameController").GetComponent<LevelState>().DyingSoldier = true;
		}

	}
}
