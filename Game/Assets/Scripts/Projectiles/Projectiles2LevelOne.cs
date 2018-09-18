using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles2LevelOne : MonoBehaviour {

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
		ground2 = GameObject.Find ("CaveFloor (8)");
		poison = GameObject.Find ("Projectiles2");
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
			actionScript.ThrowProjectile2(true);


		}

		if (coll.gameObject == pirate) {
			//poison.SetActive (false);
			poison.transform.position = projectileStartingPos;
			poison.SetActive (true);
			actionScript.ThrowProjectile2(true);


		}
	}
}
