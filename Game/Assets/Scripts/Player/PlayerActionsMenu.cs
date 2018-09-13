using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerActionsMenu : MonoBehaviour {
	//Audio Variables
	public AudioClip grappleSound;
	public AudioClip grappleClankSound;
	public AudioClip ambientMusic;
	public AudioSource mySource;

	//Grappling Variables
	public Texture2D crosshairImage;
	public DistanceJoint2D grapple;
	public float grappleTime = 0f;
	RaycastHit2D hit;
	Ray2D ray;
	public LineRenderer line;
	GameObject pirate;
	GameObject playGameCol;
	GameObject exitGameCol;
	GameObject optionsCol;
	Vector2 mouseCoords;
	Vector2 mouseDirection;
	Animator anim;
	public bool firstHit = false;
	public bool hasHooked = false;
	Vector2 values;
	Vector2 lineR;
	Vector3 target;


	void OnGUI()
	{
		float xMin = (Input.mousePosition.x - 40f) + (crosshairImage.width / 2);
		float yMin = (Screen.height - Input.mousePosition.y) - (crosshairImage.height / 2);
		GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
	}


	// Use this for initialization
	void Start () {
		playGameCol = GameObject.Find ("PlayGameCollider");
		exitGameCol = GameObject.Find ("ExitGameCollider");
		optionsCol = GameObject.Find ("OptionsCollider");
		pirate = GameObject.FindGameObjectWithTag ("Player");
		Cursor.visible = false;
		grapple = GetComponent<DistanceJoint2D> ();
		anim = GetComponent<Animator>();
		anim.SetBool("isWalking", false);
		anim.SetBool("isSwinging", false);
		grapple.enabled = false;
		line.enabled = false;
		firstHit = false;
		hasHooked = false;
		target = transform.position;

		//music
		mySource = GetComponent<AudioSource>();
		mySource.Play();

	}


	// Update is called once per frame
	void Update () {
		Movement();

		if (Input.GetKey (KeyCode.T)) {
			SceneManager.LoadScene ("TutorialLevel");
		}

		if (Input.GetKey (KeyCode.O)) {
			SceneManager.LoadScene ("LevelOne");
		}

		if (Input.GetKey (KeyCode.M)) {
			SceneManager.LoadScene ("MainMenu");
		}



	}

	void Movement()
	{

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			anim.SetBool("isWalking", true);
			transform.Translate(Vector2.right * 5f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);

		}
		else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{

			anim.SetBool("isWalking", true);
			transform.Translate(Vector2.right * 5f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, -180);
		}
		else
		{
			anim.SetBool("isWalking", false);
		}


	}

	public void Swinging(Vector2 coords)
	{
		grapple.connectedAnchor = coords;
		//line.SetPosition (0, pirate.transform.position);
		//line.SetPosition (1, coords);
		grapple.enabled = true;
		//line.enabled = true;
		while (grapple.distance > 2f) {
			grappleTime = grappleTime + 0.0000001f;	
			grapple.distance = grapple.distance - grappleTime;

		}

	}

	public void setSwing(bool val){
		anim.SetBool ("isSwinging", val);
	}

	public void setGrapple(bool val){
		grapple.enabled = val;
	}



}
