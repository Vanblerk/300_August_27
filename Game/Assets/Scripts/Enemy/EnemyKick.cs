using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKick : MonoBehaviour {
	Animator anim;
	GameObject player;			
	public GameObject barrel;					//references barrel
	public BarrelRoll rollBarrel;		//references barrelroll script
	public EnemyState enemyState;		//references the enemy state script


	public float speed;			//speed of enemy
	private Transform target;	//Target to follow
	bool playerInSight = false;			//To check if player is in line of sight
	bool barrelInRange = false;			//To check if the enemy is in front of a barrel
	bool barrelKicked = false;			//to check if the barrel was already kicked
	 


	void Awake () {
		
		anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag ("Player");
		//barrel = GameObject.FindGameObjectWithTag ("Barrel");
		enemyState = FindObjectOfType<EnemyState> ();
		rollBarrel = FindObjectOfType<BarrelRoll>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player) {	//if colliding with player
			playerInSight = true;
			Debug.Log ("PlayerInSight");
		} 

		if (other.gameObject == barrel) 
		{
			Debug.Log ("BarrelInRange");
			this.barrel = other.gameObject;			//Set barrel to instance this enemy is colliding with
			barrelInRange = true;
		}

	}					

	void OnTriggerExit2D(Collider2D other)
	{

		if (other.gameObject == player) {	//if colliding with player
			playerInSight = false;
		}

		if (other.gameObject == barrel) 
		{
			//Debug.Log ("BarrelOutRange");
			//barrelInRange = false;
		}
	}

	void Update () {		
		//If player is in sight and enemy is in front of barrel, kick the barrel
		if (playerInSight && barrelInRange) {
			this.rollBarrel = barrel.GetComponent<BarrelRoll> ();			//Get the barrel's script
			Debug.Log ("Player in sight and Barrel in range");
			if (barrelKicked == false) {
				anim.SetBool ("isKicking", true);
				//Invoke ("kickBarrel", 1.0f);

				barrelKicked = true;
			}

		} 

	}

	void kickBarrel()
	{
		if (enemyState.getEnemyDirection () == "right") {	//if enemy is facing right he should kick the barrel right
			anim.SetBool ("isKicking", false);
			this.rollBarrel.rollBarrel ("right");
		} else {											//Else kick right
			anim.SetBool ("isKicking", false);
			this.rollBarrel.rollBarrel ("left");
		}


	}
}
