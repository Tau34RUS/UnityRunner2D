using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

	public bool doublePoints;
	public bool safeMode;

	public float powerupLenght;

	private PowerUpManager thePowerUpManager;

	public Sprite[] powerupSprites;

	void Start () {

		thePowerUpManager = FindObjectOfType<PowerUpManager> ();
		
	}

	void Awake () {
	
		int powerupSelector = Random.Range (0, powerupSprites.Length);

		switch(powerupSelector){
		
		case 0:
			doublePoints = true;
			break;

		case 1:
			safeMode = true;
			break;
		
		}

		GetComponent<SpriteRenderer>().sprite = powerupSprites[powerupSelector];
	
	}

	void OnTriggerEnter2D(Collider2D other) {
	
		if (other.name == "Player") {

			thePowerUpManager.ActivatePowerup (doublePoints, safeMode, powerupLenght);

		}

		gameObject.SetActive (false);
	
	}
}
