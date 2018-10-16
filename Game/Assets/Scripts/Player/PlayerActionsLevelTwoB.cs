using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerActionsLevelTwoB : MonoBehaviour {

	public AudioClip grappleSound;
	public AudioClip grappleClankSound;
	public AudioClip grappleClankSoundHigh;
	public AudioClip grappleClankSoundLow;
	public bool PlayHigh = false;
	public bool PlayLow = false;
	public AudioClip gulpHealth;
	public AudioClip swordSound;
	public AudioClip swordHit;
	public AudioClip ambientMusic;
	public AudioSource mySource;

	public Texture2D crosshairImage;


	//Nina Variables
	public DistanceJoint2D grapple;
	public bool facingRight = true;
	public bool isSwinging;
	public bool hasHooked = false;
	public bool firstHit = false;
	public bool projectTest = false;
	public bool projectTest2 = false;
	public bool isSet = false;
	public float grappleTime = 0f;
	RaycastHit2D hit;
	public LineRenderer line;
	public LayerMask mask;
	GameObject pirate;
	GameObject projectileCol;
	GameObject projectileCol2;
	GameObject projectExit;
	GameObject poison;
	GameObject poison2;
	GameObject endGame;
	public Transform grapPoint;
	bool canAttack = true;
	bool firstClick = false;
	PlayerHealth playerHealthScript;

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
	Vector2 projectileStartingPos;
	Vector2 projectileStartingPos2;
	Vector3 worldView;

	//Vanblerk Variables
	public int attackDamage = 10;      //Damage of the player's attack  
	public EnemyHealth enemyHealth;    //References the enemy's health script

	//Variables for barrel rolling 
	GameObject barrelCollider;
	public BarrelRoll barrelroll;

	//Variables For Health Pickups
	GameObject HealthPickup;			//References the health pickup object
	public GiveHealth giveHealth;		// References the giveHealth script attached to the healthPickup gameObject



	Animator anim;
	Vector3 target;
	GameObject Enemy;           //References the enemy

	bool enemyInRange;




	//TESTING!!!
	public bool canGrap = true;



	void OnGUI()
	{
		float xMin = (Input.mousePosition.x - 40f) + (crosshairImage.width / 2);
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


		Cursor.visible = false;

		Enemy = GameObject.FindGameObjectWithTag("Enemy"); 
		pirate = GameObject.Find ("Character");
		HealthPickup = GameObject.Find ("HealthPickup");
		poison = GameObject.Find ("Projectileslvl2");
		poison2 = GameObject.Find ("Projectiles2");
		projectExit = GameObject.Find ("ProjectilesExit");
		projectileCol = GameObject.Find ("ProjectileCollider");
		projectileCol2 = GameObject.Find ("ProjectileCollider2");
		//projectileCol2 = GameObject.Find ("ProjectileCollider2");
		barrelCollider = GameObject.Find ("BarrelCollider");
		endGame = GameObject.Find ("EndGameCollider");
		//barrel = GameObject.Find ("Barrel");
		grapple = GetComponent<DistanceJoint2D> ();
		anim = GetComponent<Animator>();
		anim.SetBool("isWalking", false);
		anim.SetBool("isAttacking", false);
		anim.SetBool("isSwinging", false);
		target = transform.position;
		grapple.enabled = false;
		line.enabled = false;
		poison.SetActive (false);
		poison2.SetActive (false);
		projectileCol.SetActive (true);
		projectileCol2.SetActive (true);
		playerHealthScript = (PlayerHealth) pirate.GetComponent(typeof(PlayerHealth));

		var vol = VolumeController.SaveStuff.VolumeG;
		AdjustVolume(vol);
		//Music
		mySource = GetComponent<AudioSource>();
		mySource.Play();
		mySource.PlayOneShot(ambientMusic);




	}


	// Check to see if the player is in attacking range


	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy")
		{
			//Debug.Log("Enemy in range");
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


		if (coll.gameObject.name == "ProjectilesExit") {
			projectTest = false;
			poison.SetActive (false);
			projectExit.SetActive (false);

		}
		if (coll.gameObject == endGame) {
			Debug.Log("End Level");
			if (Input.GetKey (KeyCode.UpArrow)) {
				Application.LoadLevel ("LevelOne");
			}
			//bool isShowing;
			//isShowing = true;
			//video.SetActive(isShowing);
		}

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
			Debug.Log("Enemy out of range");
			enemyInRange = false;
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject == barrelCollider)
		{
			Debug.Log ("BarrelCollider");
			//barrelroll.rollBarrel ();

		}

		if (other.gameObject == HealthPickup)
		{
			Debug.Log ("healthPickup");

			giveHealth.givePlayerHealth (); 
			mySource.PlayOneShot(gulpHealth);
			HealthPickup.SetActive (false);
		}

		if (other.gameObject.name == "ProjectileCollider") {
			projectileCol.SetActive (false);
			poison.SetActive (true);
			projectTest = true;
		}

		if (other.gameObject.name == "ProjectileCollider2") {
			projectileCol2.SetActive (false);
			poison2.SetActive (true);
			projectTest2 = true;
		}

	}

	void FixedUpdate()
	{
		Movement();
	}

	// Update is called once per frame
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
		Swinging();
		if(Input.GetMouseButtonUp(0) == true){
			if(canGrap == true){
				//moving to on colision
				isSet = false;
				line.enabled = false;
				anim.SetBool("isSwinging", false);
				grapple.enabled = false;
				hasHooked = false;
				firstHit = false;
				StartCoroutine(GrappleTimer());
			}

		} 

		if (Input.GetKey (KeyCode.Mouse0)) {
			
			if (firstClick == false) {
				mouseDirection = Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position);
				ray = new Ray2D (pirate.transform.position, mouseDirection); 
				firstClick = true;
				swingFlip(facingRight, mouseDirection);
			}

			if (hasHooked == false) {
				if(canGrap == true){
					mouseDirection = Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position);
					ray = new Ray2D (pirate.transform.position, mouseDirection); 
					anim.SetBool ("isSwinging", true);
					hasHooked = true;
					grapple.enabled = true;
					swingFlip(facingRight, mouseDirection);
					mySource.PlayOneShot(grappleSound);
				}
			}
		}

		//Sounds

		if(isSwinging == true){
			//Play Clank noise to say we've attached
			// mySource.PlayOneShot(grappleClankSound);
		}
		if(Input.GetMouseButtonDown(0) == true){
			//moving to on colision
		} 
		if(Input.GetMouseButtonDown(1) == true){

			mySource.PlayOneShot(swordSound);
		}

		// This will change how we do our attack and hit enemy functions. 
		// if(anim.GetBool("isAttacking")){
		//     mySource.PlayOneShot(swordHit);
		// }
		ThrowProjectile(projectTest);
		ThrowProjectile2(projectTest2);


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

			anim.SetBool("isWalking", true);
			transform.Translate(Vector2.right * 5f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, -180);
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
			if (attackNumber == 1 || attackNumber == 2 || attackNumber == 3 ) {
				anim.SetBool ("isAttacking2", true);
			} 
			else if (attackNumber == 0 || attackNumber == 4) {
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

		if (Input.GetKey(KeyCode.Mouse0))
		{

			//if statement to ensure that you can't drag the mouse and the coordinates change
			if (hasHooked == false) {

				/*worldView = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.x, pirate.transform.position.z));
				mouseDirection = worldView - pirate.transform.position;
				mouseDirection.Normalize();*/

				/*ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
				ray.direction.Set (ray.direction.x, ray.direction.y, 0);*/
				//set it's max distance


			}
			hit = Physics2D.Raycast (ray.origin, ray.direction, 8f);
			//hit.rigidbody.AddForceAtPosition(ray.direction, hit.point);


			if (hit.collider != null) {

				Debug.Log ("platform hit");

				if(canGrap == true){



					// mySource.PlayClipAtPoint(grappleSound, transform.position);
					// mySource.Play(grappleSound);
					// mySource.PlayClipAtPoint(grappleSound, new Vector3(5, 1, 0));
					// mySource.PlayOneShot(grappleSound);

					if (firstHit == false) {
						// mySource.PlayOneShot (grappleClankSound);
						if(PlayHigh == true && PlayLow == false){
							// if(PlayLow == false){
								mySource.PlayOneShot(grappleClankSoundHigh);
								PlayHigh = false;
								PlayLow = false;
								Debug.Log("High Sound");
							// }
						}
						else if(PlayLow == true && PlayHigh == false){
							// if(PlayHigh == false){
								mySource.PlayOneShot(grappleClankSoundLow);
								PlayLow = false;
								PlayHigh = true;
								Debug.Log("Low Sound");
							// }
						}
						else if(PlayHigh == false && PlayLow == false){
							// if(PlayLow == false){
								mySource.PlayOneShot(grappleClankSound);
								PlayLow = true;
								Debug.Log("Normal Sound");
							// }
						}
						firstHit = true;
					}

					//if the mouse click is to the right
					if (pirate.transform.position.x < Input.mousePosition.x) {

						values.x = hit.point.x + 3.5f;
						values.y = hit.point.y + 0f;
						lineR.x = hit.point.x + 0f;
						lineR.y = hit.point.y;
						grapple.connectedAnchor = values;
						line.enabled = true;
						line.SetPosition (1, lineR);
						line.SetPosition (0, grapPoint.transform.position);



					} else {

						grapple.connectedAnchor = hit.point;
						lineR.x = hit.point.x + 0f;
						lineR.y = hit.point.y;
						line.enabled = true;
						line.SetPosition (0, grapPoint.transform.position);
						line.SetPosition (1, lineR);
					}

					while (grapple.distance > 2f) {
						grappleTime = grappleTime + 0.00001f;	
						grapple.distance = grapple.distance - grappleTime;

					}
				}


			}//end of if collide
			else {


				mouseCoords = ray.GetPoint (5f);
				grapple.enabled = false;
				//grapple.connectedAnchor = mouseCoords;
				//mouseCoords = lineLimit();
				line.enabled = true;
				line.SetPosition (0, transform.position);
				line.SetPosition (1, mouseCoords);
				StartCoroutine(Example());

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
		yield return new WaitForSeconds(0.6f);
		canAttack = true;
	}

	//Change WaitForSeconds to delay the grapple time more or less
	IEnumerator GrappleTimer()
	{
		canGrap = false;
		yield return new WaitForSeconds(0.25f);
		canGrap = true;
	}

	public void ThrowProjectile(bool project){
		if (project == true) {
			Vector2 projectileCoords;
			projectileCoords.x = poison.transform.position.x - 40f;
			projectileCoords.y = poison.transform.position.y - 40f;
			poison.transform.position = Vector2.MoveTowards (poison.transform.position, projectileCoords, 3 * Time.deltaTime);
		} 
	}

	public void ThrowProjectile2(bool project){
		if (project == true) {
			Vector2 projectileCoords;
			projectileCoords.x = poison2.transform.position.x + 40f;
			projectileCoords.y = poison2.transform.position.y - 25f;
			poison2.transform.position = Vector2.MoveTowards (poison2.transform.position, projectileCoords, 3 * Time.deltaTime);
		} 
	}

	public void swingFlip(bool isRight, Vector2 mousePos)
	{
		//mouse is clicked to the right
		if (mousePos.x > pirate.transform.position.x) {
			//if I am not right
			if (isRight != true) {
				pirate.transform.Rotate (0f, 180f, 0f);
				facingRight = true;
			}

		} else {
			//mouse was to the left
			//I am facing right 
			if (isRight == true) {
				pirate.transform.Rotate (0f, 180f, 0f);
				facingRight = false;
			}
		}

	}
}
