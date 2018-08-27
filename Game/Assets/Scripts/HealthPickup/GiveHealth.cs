using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveHealth : MonoBehaviour {


	PlayerHealth playerHealth;					// Reference to the player's health.

	void Awake () 
	{		
		playerHealth = FindObjectOfType<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void givePlayerHealth()
	{
		playerHealth.PlayerGetHealth (10); 		//Give player 10 Health
	}
}
