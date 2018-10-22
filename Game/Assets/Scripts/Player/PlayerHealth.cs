﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 10;								// The amount of health the player starts the game with.
	public int currentHealth;									// The current health the player has.
	int savedhealth;
	Text text; 
	Text text2; 												// Text to Modify how many Lives we have.
	public Slider healthSlider;                                 // Reference to the UI's health bar.
	public SpriteRenderer damageImage;                          // Reference to an image to flash on the screen on being hurt.
	public AudioClip deathClip;                                 // The audio clip to play when the player dies.
	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
	public Color flashColour = new Color(0, 0, 0, 0);     		// The colour the damageImage is set to, to flash.
	public GameObject HealthUI;									//To Reference the healthUI			
	public GameObject HealthUIIII;									//To Reference the healthUI	

	//Used to disable from player from moving after death, but need one for each playerActions script
	public PlayerActions input;									
	public PlayerActionsLevelOne input2;
	public PlayerActionsLevelTwo input3;
	public PlayerActionsLevelTwoB input4;

	Animator anim;                                              // Reference to the Animator component.
	PolygonCollider2D polygonCollider;							// References the players collider.
	public AudioSource playerAudio;                                    // Reference to the AudioSource component.
	bool isDead = false;                                                // Whether the player is dead.
	bool ninaisDead = false; 
	bool damaged;                                              // True when the player gets damaged.
	bool mayDie = true;

	void Awake()
	{
		anim = GetComponent <Animator>();
		input = GetComponent<PlayerActions>();
		input2 = GetComponent<PlayerActionsLevelOne>();
		input3 = GetComponent<PlayerActionsLevelTwo>();
		input4 = GetComponent<PlayerActionsLevelTwoB>();
		// HealthUI = GameObject.FindGameObjectWithTag ("HealthUI");
		HealthUI = GameObject.Find("HealthShadow");
		HealthUIIII = GameObject.Find("Health");
		//playerAudio = GetComponent<AudioSource> ();
		text = HealthUI.GetComponent <Text> ();
		text2 = HealthUIIII.GetComponent <Text> ();
		damageImage = GetComponent<SpriteRenderer>();
		currentHealth = startingHealth;
		playerAudio = GetComponent<AudioSource>();
	}
	

	void Update () 
	{
		text.text = "x" + currentHealth;
		text2.text = "x" + currentHealth;
		// If player takes damage
		if (damaged) 
		{
			//set player colour to red
			StartCoroutine ("changeColor");

			text.text = "x" + currentHealth;
		}
		else 
		{
			//damageImage.color = new Color(255, 255, 255, 255);
		}
		damaged = false;


	
	}

	public void PlayerTakeDamage(int amount)
	{

		if (isDead == true) {
			return;
		}
		damaged = true;



		//enemyAudio.Play();  //Play hurt sound

		currentHealth -= amount;


		if (currentHealth <= 0 && isDead == false) {
				Death ();
		}

	}

	public bool didDie(){
		return ninaisDead;
	}

	public void PlayerGetHealth(int amount)
	{
		Debug.Log ("Player got health");

		currentHealth += amount;
	}
		

	public void Death()
	{
		ninaisDead = true;
		if (mayDie == true) {
			input.enabled = false;
			input2.enabled = false;
			input3.enabled = false;
			input4.enabled = false;
			isDead = true;
			currentHealth = 0;
			playerAudio.PlayOneShot (deathClip);
			anim.SetTrigger ("isDead");
			StartCoroutine (waitingToDie ());
		} 

	}

	IEnumerator waitingToDie()
	{
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	IEnumerator changeColor()
	{


		damageImage.color = flashColour;
		yield return new WaitForSeconds (0.1f);
		damageImage.color = new Color(255, 255, 255, 255);
	}

	public int saveHealth(){
		savedhealth = currentHealth;
		return savedhealth;
	}

	public void changeHealth(int amount){
		currentHealth = amount;
	}

	public void setMaydie(bool val){
		mayDie = val;
	}
}
