using UnityEngine;
using System.Collections;

public class PlayerAddBehaviours : MonoBehaviour {


	public float crouchDeltaHeight = 0.1f;
	public float crouchingCamHeight = -1.5f;
	public float standardCamHeight = 0f;

	private Vector3 cameraTmp;


	private bool crouching;
	private GameObject mainCamera;
	

	void Awake() {
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		cameraTmp = mainCamera.transform.localPosition;
		crouching = false;
	}

	void Update() {

		if (Input.GetButtonDown ("Crouch"))
		{
			if(crouching)
			{
				stopCrouching();
				return;
			}
			
			if(!crouching)
				crouch();
			Debug.Log(mainCamera.transform.localPosition.y);
		}


		if(crouching)
		{
			if(cameraTmp.y > crouchingCamHeight){
				if(cameraTmp.y - (crouchDeltaHeight*Time.deltaTime*8) < crouchingCamHeight){
					mainCamera.transform.localPosition = cameraTmp;
				} else {
					cameraTmp.y -= crouchDeltaHeight*Time.deltaTime*8;
					mainCamera.transform.localPosition = cameraTmp;
				}
			}
		} 
		else 
		{
			if(cameraTmp.y < standardCamHeight){
				if(cameraTmp.y + (crouchDeltaHeight*Time.deltaTime*8) > standardCamHeight){
					mainCamera.transform.localPosition = cameraTmp;
				} else {
					cameraTmp.y += crouchDeltaHeight*Time.deltaTime*8;
					mainCamera.transform.localPosition = cameraTmp;
				}
			}
				
		}

	}

	void crouch()
	{
		this.gameObject.GetComponent<CapsuleCollider>().height -= crouchDeltaHeight;
		this.GetComponent<CapsuleCollider>().center -= new Vector3(0,crouchDeltaHeight/2, 0);
		crouching = true;
	}

	void stopCrouching()
	{
		crouching = false;
		this.GetComponent<CapsuleCollider>().height += crouchDeltaHeight;
		this.GetComponent<CapsuleCollider>().center += new Vector3(0,crouchDeltaHeight/2, 0);
	}
}
