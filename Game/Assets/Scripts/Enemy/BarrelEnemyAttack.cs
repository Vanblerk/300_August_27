using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelEnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 50.0f; 	// Time in seconds between attacks
	public int attackDamage = 1;				// Amount of damage to player

	Animator anim;								// Reference to animator component.
	GameObject player;							// Reference to the player GameObject.
	PlayerHealth playerHealth;					// Reference to the player's health.
	EnemyHealth enemyHealth; 					// Reference to this enemy's health.
	//EnemyWalk enemyWalk;						// Reference to the enemy walk script
	bool playerInRange; 						// Whether player is within the trigger collider and can be damaged
	float timer;	

	public bool canAttack = true;							// For counting up to next attack				

	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		enemyHealth = GetComponent<EnemyHealth> ();
		//enemyWalk = GetComponent<EnemyWalk> ();
		anim = GetComponent<Animator>();
	}

	void OnCollisionEnter2D(Collision2D coll)
	{


		if (coll.gameObject.tag == "Player")
		{			
			//playerInRange = true;
			//enemyWalk.stopWalking ();
			anim.SetBool("isAttacking", true);
			InvokeRepeating ("Attack", 0.3f, 0.7f);
		}

	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{			
			//playerInRange = false;
			anim.SetBool ("isAttacking", false);
			CancelInvoke ();
		}

	}



	// Update is called once per frame
	void Update () 
	{

		//if (playerInRange) {
		//	enemyWalk.stopWalking ();
		//	Invoke ("Attack", 0.6f);
		//} else if (!playerInRange) {
		//	anim.SetBool ("isAttacking", false);
		//}



		///*OLD CODE*///
		//timer += Time.deltaTime;


		//if(playerInRange){
		//	enemyWalk.stopWalking ();
		//	anim.SetBool ("isWalking", false);
		//	anim.SetBool("isAttacking", true);
		//Invoke ("Attack", 0.4f);
		//	Attack ();
		//} 
		//else if(playerInRange == false)
		//{			
		//	anim.SetBool ("isAttacking", false);
		//}

		//if (playerHealth.currentHealth <= 0) 
		//{
		//	Debug.Log ("Player Dead");
		//anim.SetTrigger("PlayerDead);
		//}
		///*OLD CODE END*///
	}

	void Attack()
	{

		//StartCoroutine(AttackTimer());
		playerHealth.PlayerTakeDamage (attackDamage);

		///*OLD CODE*///
		//timer = 0f;

		//if (playerHealth.currentHealth > 0) 
		//{
		//	if(canAttack == true){				
		//		StartCoroutine(AttackTimer());
		//		playerHealth.PlayerTakeDamage (attackDamage);
		//	}			
		//}
		///*OLD CODE END*///
	}

	//Change WaitForSeconds to delay the Attack time more or less
	IEnumerator AttackTimer()
	{
		//canAttack = false;
		yield return new WaitForSecondsRealtime(1f);
		//canAttack = true;
	}
}
