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
			if (CellOpening == true && CellOpeningOff == false)
			{
				GameObject.Find ("CellDoorBroken").SetActive (false);
				CellOpeningOff = true;

			}
			if (PrisonDoor == true && PrisonDoorOff == false)
			{

				GameObject.Find ("PrisonDoor").SetActive (false);
				PrisonDoorOff = true;
			}
		}
	}	
}
