﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour {
	Animator anim;
	GameObject player;

	public float speed;			//speed of enemy
	private Transform target;	//Target to follow
	bool playerInSight;			//To check if player is in line of sight

	void Awake () {
		playerInSight = false;
		anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag ("Player");
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player)	//if colliding with player
		{			
			playerInSight = true;
		}
	}					

	void OnTriggerExit2D(Collider2D other)
	{

		if (other.gameObject == player)	//if colliding with player
		{			
			playerInSight = false;
		}
	}

	void Update () {

		if (playerInSight == true) {
			WalkToPlayer ();
		} else {
			stopWalking ();
		}


	}

	public void WalkToPlayer(){

		anim.SetBool ("EnemyIdle", false);
		anim.SetBool ("isWalking", true);
		transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

	}

	public void stopWalking(){
		anim.SetBool ("EnemyIdle", true);
		anim.SetBool ("isWalking", false);
	}
}