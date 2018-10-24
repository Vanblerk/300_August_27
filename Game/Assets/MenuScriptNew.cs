using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScriptNew : MonoBehaviour {

	public GameObject MainMenu;
	public GameObject LevelMenu;
	public GameObject OptionsMenu;

	public void GoToLevels(){
		Debug.Log("GOING TO LEVELS");
		MainMenu.SetActive(false);
		LevelMenu.SetActive(true);
		OptionsMenu.SetActive(false);
	}

	public void Options(){
		Debug.Log("OPTIONS");
		MainMenu.SetActive(false);
		LevelMenu.SetActive(false);
		OptionsMenu.SetActive(true);
	}

	public void QuitGame(){
		Debug.Log("EXIT GAME!");
		Application.Quit();
	}
}
