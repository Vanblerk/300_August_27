﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NicoWalk : MonoBehaviour {
	Animator anim;
	GameObject player;

	public float speed;			//speed of enemy
	private Transform target;	//Target to follow
	bool playerInSight;			//To check if player is in line of sight

	public GameObject endLevelCollider;

	void Awake () {
		playerInSight = false;
		anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag ("Player");
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		endLevelCollider = GameObject.Find ("ExitLevelCollider");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player)	//if colliding with player
		{		
			if (checkPlayerPosition () == "right") {
				this.transform.eulerAngles = new Vector2(0, 180);
			} else {
				this.transform.eulerAngles = new Vector2(0, 0);
			}
			playerInSight = true;
			endLevelCollider.SetActive (false);
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

	string checkPlayerPosition()
	{
		float PlayerXPosition = target.position.x;
		float EnemyXPosition = transform.position.x;
		if(PlayerXPosition > EnemyXPosition)
		{
			return "right";
		}
		else{
			return "left";
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
