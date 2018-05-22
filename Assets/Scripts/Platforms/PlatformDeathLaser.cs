using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDeathLaser : MonoBehaviour {

	public GameObject DeathLaser;

	void Start () {

		DeathLaser = GameObject.Find ("Death Laser");
		
	}

	void Update () {

		if (transform.position.x < DeathLaser.transform.position.x) {
		
			//Destroy (gameObject);
			gameObject.SetActive(false);
		}
		
	}
}
