using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScriptNew : MonoBehaviour {

	public void PlayTutorial(){
		SceneManager.LoadScene("TutorialLevel");
	}

	public void PlayLevelOne(){
		SceneManager.LoadScene("LevelOne");
	}

	public void PlayLevelTwo(){
		SceneManager.LoadScene("LevelTwo");
	}
}
