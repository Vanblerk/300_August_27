using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKick : MonoBehaviour {
	Animator anim;
	GameObject player;			
	GameObject barrel;					//references barrel
	public BarrelRoll rollBarrel;		//references barrelroll script

	public float speed;			//speed of enemy
	private Transform target;	//Target to follow
	bool playerInSight;			//To check if player is in line of sight
	bool barrelInRange;			//To check if the enemy is in front of a barrel
	bool barrelKicked = false;			//to check if the barrel was already kicked

	void Awake () {
		playerInSight = false;
		anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag ("Player");
		barrel = GameObject.FindGameObjectWithTag ("Barrel");
		rollBarrel = FindObjectOfType<BarrelRoll>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player) {	//if colliding with player
			playerInSight = true;
			Debug.Log ("PlayerInSight");
		} 
		else if (other.gameObject == barrel) 
		{
			Debug.Log ("BarrelInRange");
			barrelInRange = true;
		}

	}					

	void OnTriggerExit2D(Collider2D other)
	{

		if (other.gameObject == player) {	//if colliding with player
			playerInSight = false;
		}
		else if (other.gameObject == barrel) 
		{
			barrelInRange = false;
		}
	}

	void Update () {
		Debug.Log ("barrel should be rolling");
		//If player is in sight and enemy is in front of barrel, kick the barrel
		if (playerInSight && barrelInRange) {
			
			if (barrelKicked == false) {
				anim.SetBool ("isKicking", true);
				Invoke ("rollBarrekAfterKickAnimation", 1.0f);

				barrelKicked = true;
			}

		} 

	}

	void rollBarrekAfterKickAnimation()
	{
		anim.SetBool ("isKicking", false);
		rollBarrel.rollBarrel ();

	}
}
