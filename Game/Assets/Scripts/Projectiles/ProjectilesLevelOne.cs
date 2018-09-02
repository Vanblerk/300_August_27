﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesLevelOne : MonoBehaviour {

	GameObject poison;
	//GameObject poison2;
	GameObject ground;
	GameObject ground2;
	GameObject pirate;
	Vector2 projectileStartingPos;
	PlayerActionsLevelOne actionScript;

	// Use this for initialization
	void Start () {

		ground = GameObject.Find ("CaveFloor (3)");
		poison = GameObject.Find ("Projectiles");
		pirate = GameObject.Find ("Character");
		projectileStartingPos.x = poison.transform.position.x;
		projectileStartingPos.y = poison.transform.position.y;
		actionScript = (PlayerActionsLevelOne) pirate.GetComponent(typeof(PlayerActionsLevelOne));

		//poison.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll)
	{

		if (coll.gameObject == ground) {
			//poison.SetActive (false);
			poison.transform.position = projectileStartingPos;
			poison.SetActive (true);
			actionScript.ThrowProjectile(true);


		}

		if (coll.gameObject == ground2) {
			//poison.SetActive (false);
			poison.transform.position = projectileStartingPos;
			poison.SetActive (true);
			actionScript.ThrowProjectile(true);


		}

		if (coll.gameObject == pirate) {
			//poison.SetActive (false);
			poison.transform.position = projectileStartingPos;
			poison.SetActive (true);
			actionScript.ThrowProjectile(true);


		}
	}


}
