using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour {
	Animator anim;

	void Awake () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {



		anim.SetBool ("EnemyIdle", false);
		anim.SetBool ("isWalking", true);
		transform.Translate(Vector2.left * 1.2f * Time.deltaTime);
		transform.eulerAngles = new Vector2(0, 0);
	}

	public void Walk(){



	}
}
