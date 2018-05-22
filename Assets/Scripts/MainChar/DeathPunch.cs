using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPunch : MonoBehaviour {
	
	public bool playerIsPunching;

	// Use this for initialization
	void Start () {
		//playerIsPunching = GameObject.Find("Player").GetComponent<Movement>().isPunching;
	}
	
	void Update() {
	
		playerIsPunching = GameObject.Find("Player").GetComponent<Movement>().isPunching;
	
	}

	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.name == "Player" && playerIsPunching == true) {

			//other.gameObject.SetActive (false);
			gameObject.SetActive(false);

		}

	}

}
