using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubMenuClick : MonoBehaviour {

	// Use this for initialization

	public GameObject subMenu;
	public GameObject Menu;
	public GameObject back;
	public GameObject tut;
	public GameObject sound;
	//GameObject pirate;
	PlayerActionsMenu actionScript;
	//Vector2 pirateCoords;
	//Vector2 coords;

	void Start () {
		subMenu = GameObject.FindGameObjectWithTag("submen");
		Menu = GameObject.Find ("MainMenu");
		//pirate = GameObject.Find ("Character");
		subMenu.SetActive (false);
		//actionScript = (PlayerActionsMenu) pirate.GetComponent(typeof(PlayerActionsMenu));
		//pirateCoords = pirate.transform.position;
		back.SetActive (false);
		tut.SetActive (false);
		sound.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Tutorial(){
		Vector2 coords = tut.transform.position;
		//actionScript.setSwing (true);
		//actionScript.Swinging(coords);
		StartCoroutine(tutEnum());
	} 

	public void goBack(){
		Vector2 coords = back.transform.position;
		//actionScript.setSwing (true);
		//actionScript.Swinging(coords);
		StartCoroutine(backEnum());

	} 

	public void SoundandControlls(){
		Vector2 coords = sound.transform.position;
		actionScript.setSwing (true);
		//actionScript.Swinging(coords);
		StartCoroutine(soundEnum());
	} 

	IEnumerator backEnum()
	{
		yield return new WaitForSeconds(0.3f);
		Menu.SetActive (true);
		//pirate.transform.position = pirateCoords;
		//actionScript.setGrapple(false);
		//actionScript.setSwing (false);
		subMenu.SetActive (false);
		back.SetActive (false);
		tut.SetActive (false);
		sound.SetActive (false);
	}

	IEnumerator tutEnum()
	{
		yield return new WaitForSeconds(0.3f);

		//do your stuff here
		SceneManager.LoadScene("TutorialLevel");
	}

	IEnumerator soundEnum()
	{
		yield return new WaitForSeconds(0.3f);

		//do your stuff here
	}

	public void startSub(){
		subMenu.SetActive (true);
		tut.SetActive (true);
		back.SetActive (true);
		sound.SetActive (true);
	}


}
