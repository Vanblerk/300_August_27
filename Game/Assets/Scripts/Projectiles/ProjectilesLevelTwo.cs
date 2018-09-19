using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesLevelTwo : MonoBehaviour {


	GameObject poison;
	//GameObject poison2;
	GameObject ground;
	GameObject ground2;
	GameObject pirate;
	Vector2 projectileStartingPos;
	PlayerActionsLevelOne actionScript;

	PlayerHealth playerHealth;					// Reference to the player's health script

	// Use this for initialization
	void Start () {

		ground = GameObject.Find ("floor (1)");
		ground2 = GameObject.Find ("Bench (3)");
		poison = GameObject.Find ("Projectileslvl2");
		pirate = GameObject.Find ("Character");
		playerHealth = pirate.GetComponent<PlayerHealth> ();
		projectileStartingPos.x = poison.transform.position.x;
		projectileStartingPos.y = poison.transform.position.y;
		actionScript = (PlayerActionsLevelOne) pirate.GetComponent(typeof(PlayerActionsLevelOne));

		//poison.SetActive (false);
	}

	//this if might have to change if we add rocks or water or something
	void Update () {
		if (poison.transform.position.y < -3.5f) {
			poison.transform.position = projectileStartingPos;
			poison.SetActive (true);
			actionScript.ThrowProjectile(true);
		}
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
			playerHealth.PlayerTakeDamage (1);
			poison.transform.position = projectileStartingPos;
			poison.SetActive (true);
			actionScript.ThrowProjectile(true);


		}
	}

}
