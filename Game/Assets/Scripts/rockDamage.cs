using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockDamage : MonoBehaviour {

	GameObject player;							// Reference to the player GameObject.
	PlayerHealth playerHealth;					// Reference to the player's health script
	bool killPlayer = false;
	bool playerDead = false;


	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player && killPlayer == false)	//if colliding with player
		{
			killPlayer = true;

		}
	}

	
	// Update is called once per frame
	void Update () {

		if (killPlayer == true) {
			if (playerDead == false) {
				playerHealth.Death ();
				playerDead = true;
			}
		}
	}
}
