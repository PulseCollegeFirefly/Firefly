using UnityEngine;
using System.Collections;

public class LevelState : MonoBehaviour 
{
	public string CurrentLevel;
	public bool PrisonDoor = false;
	public bool PrisonDoorOff = false;
	public bool DyingSoldier = false;
	public bool CellOpening = false;
	public bool CellOpeningOff = false;


	void Update () 
	{
		if(CurrentLevel == "Level01")
		{
			if (GameObject.Find ("CellDoorBroken") !=null)
			{
				if (CellOpening == true && CellOpeningOff == false)
				{
					GameObject.Find ("CellDoorBroken").SetActive (false);
					CellOpeningOff = true;
				}
			}
			if (GameObject.FindGameObjectWithTag ("Switch1") != null)
			{
				if (PrisonDoor == true && PrisonDoorOff == false)
				{
					GameObject.FindGameObjectWithTag ("Switch1").SetActive (false);
					PrisonDoorOff = true;
				}
			}
		}
	}	
}
