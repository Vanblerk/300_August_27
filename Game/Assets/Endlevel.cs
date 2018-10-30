using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endlevel : MonoBehaviour {

	public Fade fade;
	public GameObject player;							// Reference to the player GameObject.
	public int levelToFadeTo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player )	//if colliding with player
		{
			endLevel();

		}

	}

	public void endLevel(){
		fade.FadeToLevel (levelToFadeTo);
	}

}
