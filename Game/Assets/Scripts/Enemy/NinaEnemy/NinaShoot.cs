using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinaShoot : MonoBehaviour {

	public GameObject bullet;				//To reference bullet
	Vector2 bulletPosition;					//Where to instantiate bullet
	Animator anim;							// Reference to animator component.
	GameObject player;						// Reference to the player GameObject.
	private Transform target;				//Target to follow
	public GameObject endLevelCollider;

	//Sound
	public AudioClip gunShotSound;
	public AudioSource mySource;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator>();
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		endLevelCollider = GameObject.Find ("EndGameCollider");

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

			Debug.Log ("SHOOOT!");
			endLevelCollider.SetActive (false);
		}
	}				

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == player) {	//if colliding with player	
			Debug.Log ("NOOOOTSHOOOT!");
			anim.SetBool ("EnemyShoot", false);
		}
	}
	// Update is called once per frame
	void Update () {

	}

	void ShootBullet(){
		mySource.PlayOneShot(gunShotSound);
		if (checkPlayerPosition () == "right") {
			bulletPosition = transform.position;
			bulletPosition += new Vector2 (1.5f, 0f);
			Instantiate (bullet, bulletPosition, Quaternion.identity);
		} else if (checkPlayerPosition () == "left") {
			bulletPosition = transform.position;
			bulletPosition += new Vector2 (-1.5f, 0f);
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
}
