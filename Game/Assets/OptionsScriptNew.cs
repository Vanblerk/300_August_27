using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScriptNew : MonoBehaviour {

	public GameObject MainMenu;
	public GameObject LevelMenu;
	public GameObject OptionsMenu;

	public void Back(){
		Debug.Log("GOING BACK");
		MainMenu.SetActive(true);
		LevelMenu.SetActive(false);
		OptionsMenu.SetActive(false);
	}
}
