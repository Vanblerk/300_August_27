using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRoll : MonoBehaviour {


	//private float thrust = 1.0f;
	Rigidbody2D barrel;

	//GameObject player;
	// Use this for initialization

	void Awake (){
		barrel = GetComponent<Rigidbody2D> ();

	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if player comes into range, start rolling barrel

	}

	public void rollBarrel(string direction)
	{
		if (direction == "right") {
			barrel.AddForce (Vector2.right * 300);
		} else {
			barrel.AddForce (Vector2.left * 300);
		}


	}


}
