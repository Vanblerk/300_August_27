﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {


	public int startingHealth = 10;                         // Enemy's starting health
	public int currentHealth;                                // Enemy's current health  
	public float flashSpeed = 20f;                            // Speed at which damage flashes
	public Color flashColour = new Color(0, 0, 0, 0);  //Enemy flashes red when taking damage
	public SpriteRenderer damageImage;    

	// public AudioClip deathclip;                           //Sound that plays when enemy is killed
	public AudioClip deathclip;
	public AudioClip swordHit;

	public GameObject endLevelColliderTut;					//End level collider for tutorial
	public GameObject endLevelColliderLvl1;					//End level collider for level 1


	public Fade fade;

	Animator anim;  
	bool isDead;
	bool damaged;
	// AudioSource enemyAudio;



	public AudioSource mySource;
	void Start ()
	{
		endLevelColliderTut = GameObject.Find ("ExitLevelCollider");
		endLevelColliderLvl1 =  GameObject.Find ("EndGameCollider");
	}

	void Awake ()
	{
		anim = GetComponent<Animator>();
		flashSpeed = 20f;
		// enemyAudio = GetComponent();
		//capsuleCollider = GetComponent<CapsuleCollider>();
		currentHealth = startingHealth;
		damageImage = GetComponent<SpriteRenderer>();
		mySource = GetComponent<AudioSource>();

		//

	}

	// Update is called once per frame
	void Update () {
		if(damaged)
		{
			
			//////////////mySource.Stop();/////////////////
			//////////////mySource.Play();/////////////////


			StartCoroutine ("changeColor");
		}
		else
		{
			//StartCoroutine ("changeColor2");

			//damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	public void TakeDamage(int amount)
	{

		if(isDead == true)
		{
			return;
		}
		mySource.PlayOneShot(swordHit);
		damaged = true;



		//enemyAudio.Play();  //Play hurt sound

		currentHealth -= amount;


		if(currentHealth <= 0)
		{
			Debug.Log("DEAD");
			Death();
		}
	}


	void Death()
	{
		Debug.Log (gameObject.name + "death");
		isDead = true;
		///////////////////////mySource.Stop();////////////////////////////
		///////////////////////mySource.PlayOneShot(deathclip);////////////////////

		if (gameObject.name == "ThrowEnemy") {
			anim.SetTrigger ("EnemyDeath");

		} else if (gameObject.name == "Enemy" || gameObject.name == "KickEnemy" || gameObject.name == "GunEnemy") {
			anim.SetTrigger ("EnemyDeath");
		}
		else if(gameObject.name == "NicoEnemy")
		{
			endLevelColliderTut.SetActive (true);
			anim.SetTrigger ("EnemyDeath");
		}
		else if(gameObject.name == "NinaEnemy")
		{		
			endLevelColliderLvl1.SetActive (true);	
			anim.SetTrigger ("EnemyDeath");
		}
		else if(gameObject.name == "VanEnemy")
		{				
			anim.SetTrigger ("EnemyDeath");
			fade.FadeToLevel (0);
	
		}



		isDead = true;

		// Tell the animator that the enemy is dead.
		// anim.SetTrigger("Dead");

		// Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
		// enemyAudio.clip = deathClip;
		// enemyAudio.Play();

		Destroy(gameObject, 0.50f);
	}

	IEnumerator changeColor()
	{


		damageImage.color = flashColour;
		yield return new WaitForSeconds (0.06f);
		damageImage.color = new Color(255, 255, 255, 255);
	}

	IEnumerator changeColor2()
	{
		yield return new WaitForSeconds (0.3f);

	}

	public bool enemyDead(){
		if (isDead == true) {
			return true;
		} else {
			return false;
		}
	
	}

	public void setEnemyHealth(int val){
		currentHealth = val;
	}
}
