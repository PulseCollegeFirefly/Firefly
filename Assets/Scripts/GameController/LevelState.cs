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
	public GameObject npc;
	

	void Update () 
	{
		// If Level 1
		if(CurrentLevel == "Level01")
		{
			// If the cell has already open turn it off
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

			// Turn off Torch if picked up
			if(GameObject.FindGameObjectWithTag("Inventory").GetComponent<GameInventory>().findItem("TorchInv"))
			{
				if(GameObject.Find ("Torch") !=null)
					GameObject.Find ("Torch").SetActive (false);
			}

			if(DyingSoldier == true)
			{
				if(GameObject.Find ("FirstFireTrigger") !=null)
				{
					GameObject.Find ("FirstFireTrigger").GetComponent<FirstFireTrigger>().npc.SetActive (true);
					GameObject.Find ("FirstFireTrigger").SetActive (false);
				}
			}
			if (GameObject.Find ("StartScripts") !=null)
			{
				GameObject.Find ("StartScripts").SetActive (false);
			}

		}
	}	
}
