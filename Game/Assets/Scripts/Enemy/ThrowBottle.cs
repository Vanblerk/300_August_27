using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBottle : MonoBehaviour {

	public GameObject projectile;			//To reference projectile
	Vector2 projectilePosition;				//Where to instantiate projectile
	public float throwRate = 1f;			//Rate at whic enemy will throw


	bool playerInRange = false;

	Animator anim;								// Reference to animator component.
	GameObject player;							// Reference to the player GameObject.
	private Transform target;	//Target to follow
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator>();
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player) {	//if colliding with player
			
			if (checkPlayerPosition () == "right") {
				this.transform.eulerAngles = new Vector2(0, 180);
				Debug.Log ("Player In throw range");
				anim.SetBool ("ThrowBottle", true);
				InvokeRepeating ("throwBottle", 1.2f, 1.9f);
			} else {
				this.transform.eulerAngles = new Vector2(0, 0);
				Debug.Log ("Player In throw range");
				anim.SetBool ("ThrowBottle", true);
				InvokeRepeating ("throwBottle", 1.2f, 1.9f);
			}


		}
	}					

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == player) {	//if colliding with player
			Debug.Log ("Player out range");
			anim.SetBool ("ThrowBottle", false);
			CancelInvoke ();
		}
	}
	
	// Update is called once per frame
	void Update () {


	}

	void throwBottle(){
		projectilePosition = transform.position;
		projectilePosition += new Vector2 (0f, 1f);
		Instantiate (projectile, projectilePosition, Quaternion.identity );
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
