using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour {

	string Direction;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		getEnemyDirection ();
	}

	public string getEnemyDirection()
	{
		if (transform.eulerAngles.y == 0) {		//If enemy is facing left return "left"
			return "left";
		} else {								//Else return right

			return "right";
		}


	}
}
