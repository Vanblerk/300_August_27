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
			Debug.Log ("TOAJFAS");
			playerInRange = true;
			enemyWalk.stopWalking ();
			anim.SetBool("isAttacking", true);
			//InvokeRepeating ("Attack", 0.7f, 1.0f);
		}

	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{			
			playerInRange = false;
			anim.SetBool ("isAttacking", false);
			CancelInvoke ();
		}

	}



	// Update is called once per frame
	void Update () 
	{


	}

	void Attack()
	{
		

		if (playerInRange) {
			
			playerHealth.PlayerTakeDamage (attackDamage);
		}


	}


	IEnumerator AttackTimer()
	{
		//canAttack = false;
		yield return new WaitForSecondsRealtime(1f);
		//canAttack = true;
	}
}
