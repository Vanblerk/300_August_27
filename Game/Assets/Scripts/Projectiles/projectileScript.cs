using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour {

	float moveSpeed = 5f;
	public float velocityX = 5f;
	public float velocityY = 0f;
	Rigidbody2D rigidBody;
	GameObject target;							// Reference to the player GameObject.
	PlayerHealth playerHealth;					// Reference to the player's health.
	Vector2 moveDirection;
	Animator anim;								// Reference to animator component.
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D> ();
		target = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = target.GetComponent<PlayerHealth> ();
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rigidBody.velocity = new Vector2 (moveDirection.x, moveDirection.y);
		Invoke ("breakBottle", 5f);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{			
			playerHealth.PlayerTakeDamage (1);

		}

		anim.SetTrigger ("hit");
		Invoke ("breakBottle", 0.155f);

	}

	void breakBottle(){
		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {

	}
}
