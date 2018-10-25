using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerActions : MonoBehaviour
{
	//Nico Variables
	public AudioClip grappleSound;
	public AudioClip grappleClankSound;
	public AudioClip grappleClankSoundHigh;
	public AudioClip grappleClankSoundLow;
	public AudioClip DeathSound;
	public AudioClip BarrelBreak;
	public bool PlayHigh = false;
	public bool PlayLow = false;
	public AudioClip gulpHealth;
	public AudioClip swordSound;
	public AudioClip swordHit;
	public AudioClip ambientMusic;
	public AudioClip HighAttack;
	public AudioClip Intro;
	public AudioClip Outro;
	public AudioSource mySource;

	public Texture2D crosshairImage;


	//Nina Variables
	public DistanceJoint2D grapple;
	public bool facingRight = true;
	public bool isSwinging;
	public bool hasHooked = false;
	public bool firstHit = false;
	public bool projectTest = false;
	public bool isSet = false;
	public float grappleTime = 0f;
	RaycastHit2D hit;
	public LineRenderer line;
	public LayerMask mask;
	GameObject pirate;
	///////////////GameObject projectileCol;
	///////////////GameObject projectExit;
	///////////////GameObject poison;
	GameObject endGame;
	public Transform grapPoint;
	bool canAttack = true;
	bool firstClick = false;
	PlayerHealth playerHealthScript;
	bool isPlatform = false;
	bool flipped = false;

	// //TESTING FOR TUTORIAL VIDEO'S
	GameObject GrapCollider;
	GameObject AttCollider;
	// GameObject video;


	float pokeForce; 
	Ray2D ray;
	Vector2 lineR;
	Vector2 values;
	Vector2 mouseCoords;
	Vector2 mouseDirection;
	///////////////Vector2 projectileStartingPos;
	Vector3 worldView;

	//Vanblerk Variables
	public int attackDamage = 10;      //Damage of the player's attack  
	public EnemyHealth enemyHealth;    //References the enemy's health script
	//for smooth movement
	private Rigidbody2D body;
	private Vector2 velocityLeft;
	private Vector2 velocityRight;

	//Variables for barrel rolling 
	GameObject barrelCollider;
	public BarrelRoll barrelroll;

	//Variables For Health Pickups
	GameObject HealthPickup;			//References the health pickup object
	public GiveHealth giveHealth;		// References the giveHealth script attached to the healthPickup gameObject

	//Variables for projectiles Vanblerk




	Animator anim;
	Vector3 target;
	GameObject Enemy;           //References the enemy

	bool enemyInRange;

	public int attackNumber;






	//TESTING!!!
	public bool canGrap = true;



	void OnGUI()
	{
		float xMin = (Input.mousePosition.x - 120f) + (crosshairImage.width / 2);
		float yMin = (Screen.height - Input.mousePosition.y) - (crosshairImage.height / 2);
		GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
	}









	private void Awake()
	{
		enemyHealth = FindObjectOfType<EnemyHealth>();	//sets enemyHealth to reference the EnemyHealth Script
		barrelroll = FindObjectOfType<BarrelRoll>();	//sets barrelroll to reference the BarrelRoll Script
		giveHealth = FindObjectOfType<GiveHealth> ();	//sets giveHealth to reference the GiveHealth Script
	}
	void Start()
	{

		// //TESTING FOR TUTORIAL VIDEO'S
		GrapCollider = GameObject.Find ("GrappleVideoCollider");
		AttCollider = GameObject.Find ("AttackVideoCollider");
		// video = GameObject.Find ("GrappleVideo");

		//For smooth movement
		body = GetComponent<Rigidbody2D>();
		velocityLeft = new Vector2 (-1f, 0f);
		//transform.position = new Vector3 (-1.0f, 0f, 0f);



		Cursor.visible = false;

		Enemy = GameObject.FindGameObjectWithTag("Enemy"); 
		pirate = GameObject.Find ("Character");
		HealthPickup = GameObject.Find ("HealthPickup");
		///////////////poison = GameObject.Find ("Projectiles");
		///////////////projectExit = GameObject.Find ("ProjectilesExit");
		///////////////projectileCol = GameObject.Find ("ProjectileCollider");
		barrelCollider = GameObject.Find ("BarrelCollider");
		endGame = GameObject.Find ("ExitLevelCollider");
		//barrel = GameObject.Find ("Barrel");
		grapple = GetComponent<DistanceJoint2D> ();
		anim = GetComponent<Animator>();
		anim.SetBool("isWalking", false);
		anim.SetBool("isAttacking", false);
		anim.SetBool("isSwinging", false);
		target = transform.position;
		grapple.enabled = false;
		line.enabled = false;
		///////////////poison.SetActive (false);
		///////////////projectileCol.SetActive (true);
		///////////////projectileStartingPos.x = poison.transform.position.x;
		///////////////projectileStartingPos.y = poison.transform.position.y;
		Vector2 temp;
		playerHealthScript = (PlayerHealth) pirate.GetComponent(typeof(PlayerHealth));

		line.SetPosition (1, pirate.transform.position);
		line.SetPosition (0, pirate.transform.position);


		var vol = VolumeController.SaveStuff.VolumeG;
		AdjustVolume(vol);
		//Music
		mySource = GetComponent<AudioSource>();
		mySource.PlayOneShot(Intro);
		mySource.Play();




	}


	// Check to see if the player is in attacking range


	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy")
		{
			Debug.Log("Gun Enemy in range");

			Enemy = coll.gameObject;
			enemyInRange = true;
		}

		if (coll.gameObject.name == "Platforms") {
			//Debug.Log("platform hit");

		}

		if (coll.gameObject.name == "HealthPickup") {
			/*pickups.SetActive (false);
			mySource.PlayOneShot(gulpHealth);*/
		}

		///////////////if (coll.gameObject.name == "Projectiles") {

		///////////////	poison.SetActive (false);
		///////////////	projectTest = false;
		///////////////	playerHealthScript.PlayerTakeDamage (1);
		///////////////	//reset
		///////////////	poison.transform.position = projectileStartingPos;
		///////////////	poison.SetActive (true);
		///////////////	projectTest = true;
		///////////////	ThrowProjectile (projectTest);
		///////////////}

		///////////////if (coll.gameObject.name == "ProjectilesExit") {
		///////////////	projectTest = false;
		///////////////	poison.SetActive (false);
		///////////////	projectExit.SetActive (false);

		///////////////}


		//if (coll.gameObject.name == "BarrelCollider") {

		//}

		//When Player touches collider that causes a barrel to be rolled




		// //TESTING FOR TUTORIAL VIDEO'S
		if (coll.gameObject == GrapCollider) {
			Debug.Log("YAYS");
			GrapCollider.SetActive (false);
			//bool isShowing;
			//isShowing = true;
			//video.SetActive(isShowing);
		}

		if (coll.gameObject == AttCollider) {
			Debug.Log("YAYS2");
			AttCollider.SetActive (false);
			//bool isShowing;
			//isShowing = true;
			//video.SetActive(isShowing);
		}

	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy")
		{
			///Debug.Log("Enemy out of range");
			enemyInRange = false;
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("triggerEntered");

		if (other.gameObject == barrelCollider)
		{
			Debug.Log ("barrelCollider");
			mySource.PlayOneShot(BarrelBreak);
			//barrelroll.rollBarrel ();

		}

		if (other.gameObject == HealthPickup)
		{
			Debug.Log ("healthPickup");

			giveHealth.givePlayerHealth (); 
			mySource.PlayOneShot(gulpHealth);
			HealthPickup.SetActive (false);
		}

		///////////////if (other.gameObject.name == "ProjectileCollider") {
		///////////////	projectileCol.SetActive (false);
		///////////////poison.SetActive (true);
		///////////////	projectTest = true;
		///////////////}

		if (other.gameObject == endGame) {
			Debug.Log("End Level");
			StartCoroutine(endCooldown());
		}

	}

	IEnumerator endCooldown()
	{
		yield return new WaitForSeconds(0.3f);
		SceneManager.LoadScene ("LevelOne");
	}


	void FixedUpdate()
	{
		Movement();
	}

	void Update()
	{

		if (Input.GetKey (KeyCode.T)) {
			SceneManager.LoadScene ("TutorialLevel");
		}

		if (Input.GetKey (KeyCode.O)) {
			SceneManager.LoadScene ("LevelOne");
		}

		if (Input.GetKey (KeyCode.M)) {
			SceneManager.LoadScene ("MainMenu");
		}

		if (Input.GetKey (KeyCode.H)) {
			SceneManager.LoadScene ("LevelTwo");
		}

		if (Input.GetKey (KeyCode.Y)) {
			SceneManager.LoadScene ("LevelTwoB");
		}

		if (Input.GetKey (KeyCode.L)) {
			playerHealthScript.PlayerGetHealth (100);
		}

		

		Attack();
		if(Input.GetMouseButtonUp(0) == true){
			if(canGrap == true){
				//moving to on colision
				isSet = false;
				line.enabled = false;
				anim.SetBool("isSwinging", false);
				grapple.enabled = false;
				hasHooked = false;
				firstHit = false;
				isPlatform = false;
				flipped = false;
				StartCoroutine(GrappleTimer());
			}

		} 

		if (Input.GetKey (KeyCode.Mouse0)) {
			/*if (firstClick == false) {
				mouseDirection = Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position);
				ray = new Ray2D (pirate.transform.position, mouseDirection); 
				firstClick = true;
				swingFlip(facingRight, mouseDirection);
			}*/

			if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			{
				if (facingRight != true) {
					//pirate.transform.Translate (Vector2.right * 5f * Time.deltaTime);
					pirate.transform.eulerAngles = new Vector2 (0, -180);
					facingRight = true;
				} else {
					//pirate.transform.Translate (Vector2.right * 5f * Time.deltaTime);
					pirate.transform.eulerAngles = new Vector2 (0, 0);
					facingRight = true;
				}

			}
			else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			{
				if (facingRight == true) {
					//pirate.transform.Translate (Vector2.right * 5f * Time.deltaTime);
					pirate.transform.eulerAngles = new Vector2 (0, -180);
					facingRight = false;
				} else {
					//pirate.transform.Translate (Vector2.right * 5f * Time.deltaTime);
					//pirate.transform.eulerAngles = new Vector2 (0, 0);
					facingRight = false;

				}
			}

			if (hasHooked == false) {
				if(canGrap == true ){
					mouseDirection = Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position);
					ray = new Ray2D (pirate.transform.position, mouseDirection); 
					hasHooked = true;
				}
			}
			Swinging();
		}else {
			anim.SetBool ("isSwinging", false);
		}

		

		//Sounds

		if(isSwinging == true){
			//Play Clank noise to say we've attached
			// if(PlayHigh == true){
			// 	mySource.PlayOneShot(grappleClankSoundHigh);
			// 	PlayHigh = false;
			// 	PlayLow = true;
			// }
			// if(PlayLow == true){
			// 	mySource.PlayOneShot(grappleClankSoundLow);
			// 	PlayLow = false;
			// }
			// if(PlayHigh == false){
			// 	if(PlayLow == false){
			// 		mySource.PlayOneShot(grappleClankSound);
			// 		PlayHigh = true;
			// 	}
			// }
		}
		if(Input.GetMouseButtonDown(0) == true){
			//moving to on colision
		} 
		if(Input.GetMouseButtonDown(1) == true){

			// mySource.PlayOneShot(swordSound);
		////////////////////////	int attackNumber = Random.Range (0, 5);
		////////////////////////	Debug.Log (attackNumber);
		/////////////////////////	if (attackNumber == 1 || attackNumber == 2 || attackNumber == 3 ) {
		///////////////////////		mySource.PlayOneShot(swordSound);

		//////////////////////////	} 
		/////////////////////////	else if (attackNumber == 0 || attackNumber == 4) {
		////////////////////////////		mySource.PlayOneShot(HighAttack);
		/////////////////////////////	}
		}

		// This will change how we do our attack and hit enemy functions. 
		// if(anim.GetBool("isAttacking")){
		//     mySource.PlayOneShot(swordHit);
		// }
		///////////////ThrowProjectile(projectTest);

	}

	public void playSwordSwing()
	{
		int attackNumber = Random.Range (0, 5);
		Debug.Log (attackNumber);
		if (attackNumber == 1 || attackNumber == 2 || attackNumber == 3 ) {
			mySource.PlayOneShot(swordSound);

		} 
		else if (attackNumber == 0 || attackNumber == 4) {
			mySource.PlayOneShot(HighAttack);
		}
	}

	void Movement()
	{

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			anim.SetBool("isWalking", true);
			transform.Translate(Vector2.right * 5f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
			facingRight = true;

		}
		else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{

			//transform.eulerAngles = new Vector2(0, 180);
			//body.MovePosition(body.position + velocityLeft*5f*Time.deltaTime);

			//anim.SetBool("isWalking", true);
			//transform.Translate(Vector2.right * 5f * Time.deltaTime);

			//facingRight = false;


			anim.SetBool("isWalking", true);
			transform.Translate(Vector2.right * 5f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180);
			facingRight = false;
		}
		else
		{
			anim.SetBool("isWalking", false);
		}


	}

	void Attack()
	{
		
		if (Input.GetKey(KeyCode.Mouse1))
		{
			int attackNumber = Random.Range (0, 5);
			Debug.Log (attackNumber);
			if (attackNumber == 1 || attackNumber == 2 || attackNumber == 3 || attackNumber == 4 ) {
				anim.SetBool ("isAttacking2", true);

			} 
			else if (attackNumber == 0) {
				anim.SetBool ("isAttacking", true);
			}

			if (enemyInRange && canAttack)
			{
				//Debug.Log("in Range and attacking");
				enemyHealth = Enemy.GetComponent<EnemyHealth>();
				enemyHealth.TakeDamage(attackDamage);
				canAttack = false;
				StartCoroutine(attackCooldown());
			}
		}
		else
		{
			anim.SetBool("isAttacking", false);
			anim.SetBool ("isAttacking2", false);
		}
	}

	void Swinging()
	{

		if (Input.GetKey (KeyCode.Mouse0)) {


			hit = Physics2D.Raycast (ray.origin, ray.direction, 8f);
			//hit.rigidbody.AddForceAtPosition(ray.direction, hit.point);


			if (hit.collider != null) {

				if (hit.collider.tag == "platform") {
					Debug.Log ("platform hit");
					isPlatform = true;
				}


				if (canGrap == true && isPlatform == true) {


					grapple.enabled = true;
					anim.SetBool ("isSwinging", true);
					if (flipped == false) {
						Debug.Log ("swingflip with: "+facingRight);
						swingFlip (facingRight, mouseDirection);

						flipped = true;
					}

					//mySource.PlayOneShot(grappleSound);
					// mySource.PlayClipAtPoint(grappleSound, transform.position);
					// mySource.Play(grappleSound);
					// mySource.PlayClipAtPoint(grappleSound, new Vector3(5, 1, 0));
					// mySource.PlayOneShot(grappleSound);

					if (firstHit == false) {
						// mySource.PlayOneShot (grappleClankSound);
						if (PlayHigh == true && PlayLow == false) {
							// if(PlayLow == false){
							mySource.PlayOneShot (grappleClankSoundHigh);
							PlayHigh = false;
							PlayLow = false;
							Debug.Log ("High Sound");
							// }
						} else if (PlayLow == true && PlayHigh == false) {
							// if(PlayHigh == false){
							mySource.PlayOneShot (grappleClankSoundLow);
							PlayLow = false;
							PlayHigh = true;
							Debug.Log ("Low Sound");
							// }
						} else if (PlayHigh == false && PlayLow == false) {
							// if(PlayLow == false){
							mySource.PlayOneShot (grappleClankSound);
							PlayLow = true;
							Debug.Log ("Normal Sound");
							// }
						}
						firstHit = true;
					}

					//if the mouse click is to the right
					if (pirate.transform.position.x < Input.mousePosition.x) {

						values.x = hit.point.x + 3.7f;
						values.y = hit.point.y;
						lineR.x = hit.point.x + 0f;
						lineR.y = hit.point.y;
						grapple.connectedAnchor = values;
						line.SetPosition (1, lineR);
						line.SetPosition (0, grapPoint.transform.position);
						line.enabled = true;



					} else {
						grapple.connectedAnchor = hit.point;
						lineR.x = hit.point.x + 0f;
						lineR.y = hit.point.y;
						line.SetPosition (0, grapPoint.transform.position);
						line.SetPosition (1, lineR);
						line.enabled = true;
					}

					while (grapple.distance > 2f) {
						grappleTime = grappleTime + 0.00001f;	
						grapple.distance = grapple.distance - grappleTime;

					}
				} else {
					grapple.enabled = false;
					line.enabled = false;
				}

			}//end of if collide
		else {


				grapple.enabled = false;
				line.enabled = false;
				/*mouseCoords = ray.GetPoint (5f);

				//grapple.connectedAnchor = mouseCoords;
				//mouseCoords = lineLimit();
				line.SetPosition (0, transform.position);
				line.SetPosition (1, mouseCoords);
				line.enabled = true;
				StartCoroutine(Example());*/

			}


		}

	}

	public void AdjustVolume (float vol) {
		AudioListener.volume = vol;
	}

	IEnumerator Example()
	{
		yield return new WaitForSeconds(0.3f);
		line.enabled = false;
	}

	IEnumerator attackCooldown()
	{
		yield return new WaitForSeconds(0.5f);
		canAttack = true;
	}

	//Change WaitForSeconds to delay the grapple time more or less
	IEnumerator GrappleTimer()
	{
		canGrap = false;
		yield return new WaitForSeconds(0.25f);
		canGrap = true;
	}

	///////////////public void ThrowProjectile(bool project){
	///////////////if (project == true) {
	///////////////	Vector2 projectileCoords;
	///////////////	projectileCoords.x = poison.transform.position.x + 20f;
	///////////////	projectileCoords.y = poison.transform.position.y - 7f;
	///////////////	poison.transform.position = Vector2.MoveTowards (poison.transform.position, projectileCoords, 3 * Time.deltaTime);
	///////////////} 
	///////////////}

	public void swingFlip(bool isRight, Vector2 mousePos)
	{
		//mouse is clicked to the right
		if (mousePos.x > pirate.transform.position.x) {
			//if I am not right
			Debug.Log("I look to right:"+facingRight);
			if (isRight == false) {
				pirate.transform.Rotate (0f, 180f, 0f);
				facingRight = true;
			}

		} else {
			//mouse was to the left
			//I am facing right 
			if (isRight == true) {
				Debug.Log("I look to right:"+facingRight);
				pirate.transform.eulerAngles = new Vector2 (0, -180);
				facingRight = false;
			}
		}

	}


}