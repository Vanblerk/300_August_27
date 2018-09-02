using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockDamage : MonoBehaviour {

	GameObject player;							// Reference to the player GameObject.
	PlayerHealth playerHealth;					// Reference to the player's health script


	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player)	//if colliding with player
		{
			Debug.Log ("player rock death");
			playerHealth.Death ();

		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
