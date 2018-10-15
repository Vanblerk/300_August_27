using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuClick : MonoBehaviour {

	GameObject menu;
	public GameObject play;
	public GameObject options;
	public GameObject exit;
	public GameObject box6;
	public GameObject box7;
	public GameObject box8;
	public GameObject LevelMenus;
	public PlayerActionsMenu actionScript;
	SubMenuClick subScript;
	public GameObject subMenu;
	GameObject pirate;
	Vector2 coords;
	Vector2 pirateCoords;
	public GameObject levelMenu;
	LevelMenuClick lvlScript;

	// public AudioSource mySource;




	// Use this for initialization
	void Start () {
		menu = GameObject.Find ("MainMenu");
		pirate = GameObject.Find ("Character");
		//subMenu = GameObject.FindGameObjectWithTag("submen");
		/*play = GameObject.Find ("box");
		exit = GameObject.Find ("box3");
		options = GameObject.Find ("box2");*/

		lvlScript = (LevelMenuClick) levelMenu.GetComponent(typeof(LevelMenuClick));
		subScript = (SubMenuClick) subMenu.GetComponent(typeof(SubMenuClick));
		pirateCoords = pirate.transform.position;
		box6.SetActive(false);
		box7.SetActive(false);
		box8.SetActive(false);

		// mySource = GetComponent<AudioSource>();
		// mySource.Play();
	}

	// Update is called once per frame
	void Update () {
		play.SetActive(true);
		exit.SetActive(true);
		options.SetActive(true);
	}

	public void PlayGame(){
		//play grapple func
		actionScript.setSwing (true);
		coords = play.transform.position;
		actionScript.Swinging(coords);
		StartCoroutine(playEnum());
	}

	public void GoToOptions(){
		//play grapple
		actionScript.setSwing (true);
		coords = options.transform.position;
		actionScript.Swinging(coords);
		//Disable all components and enable the others
		StartCoroutine(optionsEnum());

	}

	public void ExitGame(){
		//play grapple
		actionScript.setSwing (true);
		coords = exit.transform.position;
		actionScript.Swinging(coords);
		StartCoroutine(exitEnum());

	}



	IEnumerator playEnum()
	{
		yield return new WaitForSeconds(1.6f);
		pirate.transform.position = pirateCoords;
		actionScript.setGrapple(false);
		actionScript.setSwing (false);
		
		play.SetActive (false);
		options.SetActive (false);
		exit.SetActive (false);
		menu.SetActive(false);
		// LevelMenus.SetActive(true);
		box6.SetActive(true);
		box7.SetActive(true);
		box8.SetActive(true);
		lvlScript.startLvl();

	}

	IEnumerator exitEnum()
	{
		yield return new WaitForSeconds(1.6f);
		Application.Quit();
	}

	IEnumerator optionsEnum()
	{
		yield return new WaitForSeconds(1.6f);
		pirate.transform.position = pirateCoords;
		actionScript.setGrapple(false);
		actionScript.setSwing (false);
		subScript.startSub();
		play.SetActive (false);
		options.SetActive (false);
		exit.SetActive (false);
		menu.SetActive(false);
	}


}
