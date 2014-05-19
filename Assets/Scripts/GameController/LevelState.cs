using UnityEngine;
using System.Collections;

public class LevelState : MonoBehaviour 
{
	public string CurrentLevel;
	public bool GuardsKeys = false;
	public bool PrisonDoor = false;
	public bool PrisonDoorOff = false;
	public bool DyingSoldier = false;
	public bool CellOpening = false;
	public bool CellOpeningOff = false;
	public bool Torch = false;

	// Use this for initialization
	void Start () 
	{
		//Level01 State Check

	
	}
	
	// Update is called once per frame
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
			if (GuardsKeys == true)
			{
				GameObject.Find ("GuardsKeys").SetActive (false);
			}
			
			if (Torch == true)
			{
				GameObject.Find ("Torch").SetActive (false);
			}
		}
	}
}
