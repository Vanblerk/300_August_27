using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour {

	float moveSpeed = 5f;
	Rigidbody2D rigidBody;
	GameObject target;							// Reference to the player GameObject.
	PlayerHealth playerHealth;					// Reference to the player's health.
	GameObject enemy;
	EnemyHealth enemyHealth;
	Vector2 moveDirection;
	Animator anim;								// Reference to animator component.
	// Use this for initialization
	void Start () {
		enemy = GameObject.FindGameObjectWithTag("Enemy"); 
		anim = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D> ();
		target = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = target.GetComponent<PlayerHealth> ();
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rigidBody.velocity = new Vector2 (moveDirection.x, moveDirection.y);
		Invoke ("breakBottle", 5f);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{			
			playerHealth.PlayerTakeDamage (1);

		}

		if (coll.gameObject.tag == "Enemy") {
			enemy = coll.gameObject;
			enemyHealth = enemy.GetComponent<EnemyHealth>();
			enemyHealth.TakeDamage(10);
		}


		anim.SetTrigger ("hit");
		Invoke ("breakBottle", 0.155f);

	}

	void breakBottle(){
		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {

	}
}
