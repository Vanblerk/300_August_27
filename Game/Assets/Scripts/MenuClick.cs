using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuClick : MonoBehaviour {

	GameObject menu;
	GameObject play;
	GameObject options;
	GameObject exit;
	public PlayerActionsMenu actionScript;
	SubMenuClick subScript;
	public GameObject subMenu;
	GameObject pirate;
	Vector2 coords;
	Vector2 pirateCoords;

	// public AudioSource mySource;




	// Use this for initialization
	void Start () {
		menu = GameObject.Find ("MainMenu");
		pirate = GameObject.Find ("Character");
		//subMenu = GameObject.FindGameObjectWithTag("submen");
		play = GameObject.Find ("box");
		exit = GameObject.Find ("box3");
		options = GameObject.Find ("box2");

		subScript = (SubMenuClick) subMenu.GetComponent(typeof(SubMenuClick));
		pirateCoords = pirate.transform.position;

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
		SceneManager.LoadScene("LevelOne");
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
		subScript.startSub ();
		play.SetActive (false);
		options.SetActive (false);
		exit.SetActive (false);
		menu.SetActive(false);
	}


}
