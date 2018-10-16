using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour {
	GameObject poison;
	GameObject ground;
	GameObject ground2;
	GameObject pirate;
	Vector2 projectileStartingPos;
	PlayerActions actionScript;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	GameObject enemy;


	// Use this for initialization
	void Start () {

		ground = GameObject.Find ("newWoodenFloor (2)");
		ground2 = GameObject.Find ("GroundTop");
		poison = GameObject.Find ("Projectiles");
		enemy = GameObject.Find ("ThrowEnemy");
		pirate = GameObject.Find ("Character");
		projectileStartingPos.x = poison.transform.position.x;
		projectileStartingPos.y = poison.transform.position.y;
		actionScript = (PlayerActions) pirate.GetComponent(typeof(PlayerActions));
		enemyHealth = (EnemyHealth) enemy.GetComponent(typeof(EnemyHealth));

		//poison.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (enemyHealth.enemyDead() == true) {
			poison.SetActive (false);
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


	}


}
