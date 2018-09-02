using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 50.0f; 	// Time in seconds between attacks
	public int attackDamage = 1;				// Amount of damage to player

	Animator anim;								// Reference to animator component.
	GameObject player;							// Reference to the player GameObject.
	PlayerHealth playerHealth;					// Reference to the player's health.
	EnemyHealth enemyHealth; 					// Reference to this enemy's health.
	EnemyWalk enemyWalk;						// Reference to the enemy walk script
	bool playerInRange; 						// Whether player is within the trigger collider and can be damaged
	float timer;	
	
	public bool canAttack = true;							// For counting up to next attack				

	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		enemyHealth = GetComponent<EnemyHealth> ();
		enemyWalk = GetComponent<EnemyWalk> ();
		anim = GetComponent<Animator>();
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{			
			playerInRange = true;
		}

	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{			
			playerInRange = false;
		}

	}

	/*void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)	//if colliding with player
		{
			Debug.Log ("Player in range");
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player) 
		{
			playerInRange = false;
		}
	}*/
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;

		if (timer >= timeBetweenAttacks && playerInRange) {
			enemyWalk.stopWalking ();
			anim.SetBool ("isWalking", false);
			anim.SetBool("isAttacking", true);
			Attack ();
		} 
		else if(playerInRange == false)
		{			
			anim.SetBool ("isAttacking", false);
		}

		if (playerHealth.currentHealth <= 0) 
		{
			Debug.Log ("Player Dead");
			//anim.SetTrigger("PlayerDead);
		}
	}

	void Attack()
	{
		timer = 0f;

		

		if (playerHealth.currentHealth > 0) 
		{
			if(canAttack == true){
				playerHealth.PlayerTakeDamage (attackDamage);
				StartCoroutine(AttackTimer());
			}
			
		}
	}

	//Change WaitForSeconds to delay the Attack time more or less
	IEnumerator AttackTimer()
	{
		canAttack = false;
		yield return new WaitForSeconds(1f);
		canAttack = true;
	}
}
