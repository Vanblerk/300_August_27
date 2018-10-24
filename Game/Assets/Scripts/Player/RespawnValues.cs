using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnValues : MonoBehaviour {

	Vector2 spawnCoords;
	GameObject pirate;
	GameObject spawnPoint;
	int health;
	PlayerHealth playerHealthScript;

	// Use this for initialization
	void Awake () {
		pirate = GameObject.Find ("Character");
		spawnCoords = pirate.transform.position;
		//spawnPoint = GameObject.FindGameObjectWithTag("SP");
		playerHealthScript = (PlayerHealth) pirate.GetComponent(typeof(PlayerHealth));
		health = playerHealthScript.getHealth ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "SP") 
		{
			Debug.Log("Reset SP");
			health = playerHealthScript.getHealth ();
			spawnCoords = other.transform.position;
			//other.enabled = false;
		}
	}

	public Vector2 getSpawn(){
		return spawnCoords;
	}

	public int getSpawnHealth(){

		return health;	
	}
}
