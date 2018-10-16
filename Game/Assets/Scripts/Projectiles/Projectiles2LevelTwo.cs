using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles2LevelTwo : MonoBehaviour {

	GameObject poison;
	//GameObject poison2;
	GameObject ground;
	GameObject ground2;
	GameObject pirate;
	Vector2 projectileStartingPos;
	PlayerActionsLevelOne actionScript;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	GameObject enemy;

	// Use this for initialization
	void Start () {

		ground = GameObject.Find ("floor (4)");
		poison = GameObject.Find ("Projectiles2");
		pirate = GameObject.Find ("Character");
		projectileStartingPos.x = poison.transform.position.x;
		projectileStartingPos.y = poison.transform.position.y;
		actionScript = (PlayerActionsLevelOne) pirate.GetComponent(typeof(PlayerActionsLevelOne));
		playerHealth = pirate.GetComponent<PlayerHealth> ();

		enemy = GameObject.Find ("ThrowEnemy2");
		enemyHealth = (EnemyHealth) enemy.GetComponent(typeof(EnemyHealth));

		//poison.SetActive (false);
	}

	void Update () {
		if (poison.transform.position.y < 5f) {
			poison.transform.position = projectileStartingPos;
			poison.SetActive (true);
			actionScript.ThrowProjectile(true);
		}

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
			actionScript.ThrowProjectile2(true);


		}

		if (coll.gameObject == pirate) {
			//poison.SetActive (false);
			playerHealth.PlayerTakeDamage (1);
			poison.transform.position = projectileStartingPos;
			poison.SetActive (true);
			actionScript.ThrowProjectile2(true);


		}
	}
	// Update is called once per frame

}
