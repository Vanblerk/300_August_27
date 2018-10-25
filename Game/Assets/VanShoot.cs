using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanShoot : MonoBehaviour {

	public float speed;						//speed of enemy
	public GameObject bullet;				//To reference bullet
	Vector2 bulletPosition;					//Where to instantiate bullet
	Animator anim;							// Reference to animator component.
	GameObject player;						// Reference to the player GameObject.
	private Transform target;				//Target to follow
	bool playerInSight = false;			//To check if player is in line of sight
	bool canWalk = false;
	//////////////public GameObject endLevelCollider;

	//Sound
	public AudioClip gunShotSound;
	public AudioSource mySource;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator>();
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		////////////////////endLevelCollider = GameObject.Find ("EndGameCollider");

		mySource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{


		if (other.gameObject == player) {	//if colliding with player
			
			if (checkPlayerPosition () == "right") {
				this.transform.eulerAngles = new Vector2(0, 180);
				anim.SetBool ("EnemyShoot", true);

			} else if(checkPlayerPosition () == "left") {
				this.transform.eulerAngles = new Vector2(0, 0);
				anim.SetBool ("EnemyShoot", true);
			}

			playerInSight = true;
			///////////////////////endLevelCollider.SetActive (false);
		}
	}				

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == player) {	//if colliding with player	
			
			anim.SetBool ("EnemyShoot", false);
			playerInSight = false;
			canWalk = false;
		}
	}
	// Update is called once per frame
	void Update () {
		if (playerInSight == true && canWalk == true) {
			WalkToPlayer ();
		} else {
			stopWalking ();
		}
	}

	void ShootBullet(){
		mySource.PlayOneShot(gunShotSound);
		if (checkPlayerPosition () == "right") {
			bulletPosition = transform.position;
			bulletPosition += new Vector2 (1.6f, 0.31f);
			Instantiate (bullet, bulletPosition, Quaternion.identity);
		} else if (checkPlayerPosition () == "left") {
			bulletPosition = transform.position;
			bulletPosition += new Vector2 (-1.6f, 0.31f);
			Instantiate (bullet, bulletPosition, Quaternion.identity);
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

		speed = 1.2f;
		anim.SetBool ("isWalking", true);
		Debug.Log ("walking to player");

		transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

	}

	public void stopWalking(){

		anim.SetBool ("isWalking", false);
	}

	public void CanWalk(){
		canWalk = true;
	}
}
