using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

	public Animator anim;
	private int levelToLoad;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void FadeToLevel(int levelIndex)
	{
		levelToLoad = levelIndex;
		anim.SetTrigger ("FadeOut");
	}

	public void OnFadeComplete()
	{
		SceneManager.LoadScene (levelToLoad);
	}
}
