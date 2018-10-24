using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanWalk : MonoBehaviour {

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
		////////////////endLevelCollider = GameObject.Find ("ExitLevelCollider");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player)	//if colliding with player
		{					
			playerInSight = true;
			///////////////////endLevelCollider.SetActive (false);
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


	/// <summary>
	/// Shoots then walks to player
	/// </summary>
	public void WalkToPlayer(){

		anim.SetBool ("isWalking", true);
		Debug.Log ("walking to player");

		transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

	}

	public void stopWalking(){
		
		anim.SetBool ("isWalking", false);
	}
}
