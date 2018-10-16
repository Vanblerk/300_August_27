using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenuClick : MonoBehaviour {

	public GameObject menu;
	public GameObject lvl1;
	public GameObject tut;
	public GameObject lvl2;
	public PlayerActionsMenu actionScript;
	SubMenuClick subScript;
	public GameObject subMenu;
	//GameObject pirate;
	Vector2 coords;
	Vector2 pirateCoords;

	// public AudioSource mySource;




	// Use this for initialization
	void Start () {
		//menu = GameObject.Find ("LevelMenu");
		//pirate = GameObject.Find ("Character");
		//subMenu = GameObject.FindGameObjectWithTag("submen");
		/*lvl1 = GameObject.Find ("box");
		lvl2 = GameObject.Find ("box3");
		tut = GameObject.Find ("box2");*/

		//pirateCoords = pirate.transform.position;
		lvl1.SetActive(false);
		lvl2.SetActive(false);
		tut.SetActive(false);
		// mySource = GetComponent<AudioSource>();
		// mySource.Play();
	}

	// Update is called once per frame
	void Update () {
		lvl1.SetActive (true);
		lvl2.SetActive (true);
		tut.SetActive (true);
	}

	public void startLvl(){
		menu.SetActive (true);
		lvl1.SetActive (true);
		lvl2.SetActive (true);
		tut.SetActive (true);
	}

	public void PlayGame(){
		//play grapple func
		actionScript.setSwing (true);
		coords = lvl1.transform.position;
		//actionScript.Swinging(coords);
		StartCoroutine(playEnum());
	}

	public void GoToOptions(){
		//play grapple
		//actionScript.setSwing (true);
		coords = tut.transform.position;
		//actionScript.Swinging(coords);
		//Disable all components and enable the others
		StartCoroutine(optionsEnum());

	}

	public void ExitGame(){
		//play grapple
		//actionScript.setSwing (true);
		coords = lvl2.transform.position;
		//actionScript.Swinging(coords);
		StartCoroutine(exitEnum());

	}



	IEnumerator playEnum()
	{
		yield return new WaitForSeconds(0.1f);
		SceneManager.LoadScene("LevelOne");
	}

	IEnumerator exitEnum()
	{
		yield return new WaitForSeconds(0.1f);
		SceneManager.LoadScene("LevelTwo");
	}

	IEnumerator optionsEnum()
	{
		yield return new WaitForSeconds(0.1f);
		SceneManager.LoadScene("TutorialLevel");
	}

}
