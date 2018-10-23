using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelDamage : MonoBehaviour {
	Animator anim;
	public float timeBetweenDamage = 0.5f;		// The intervals between which the barrel can damage you
	public int barrelDamage = 5;				// Amount of damage the barrel does
	GameObject player;							// Reference to the player GameObject.
	GameObject enemy;
	PlayerHealth playerHealth;					// Reference to the player's health.
	EnemyHealth enemyHealth;
	bool playerInRange; 						// Whether player is within the trigger collider and can be damaged
	float timer;								// For counting up to next damage
	Collider2D BarrelCollider;				


	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		enemy = GameObject.FindGameObjectWithTag("Enemy"); 
		anim = GetComponent<Animator>();
		BarrelCollider = GetComponent<Collider2D> ();
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{			
			if (playerHealth.currentHealth > 0) 
			{
				playerHealth.PlayerTakeDamage (barrelDamage);
				Destroy (BarrelCollider);
				anim.SetTrigger("destroyBarrel");
				Invoke ("destroyBarrel", 0.35f);
			}
		}
		if (coll.gameObject.tag == "Enemy") {
			enemy = coll.gameObject;
			enemyHealth = enemy.GetComponent<EnemyHealth>();
			enemyHealth.TakeDamage(barrelDamage);
			anim.SetTrigger("destroyBarrel");
			Invoke ("destroyBarrel", 0.35f);
		}



	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{			
			playerInRange = false;
		}

	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (timer >= timeBetweenDamage && playerInRange) {
			
		} 

	}

	void damagePlayer (){


	}


	void destroyBarrel()
	{

		Destroy(gameObject, 0f);
	}
}
