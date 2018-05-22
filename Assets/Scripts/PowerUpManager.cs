using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

	private bool doublePoints;
	private bool safeMode;
	private bool powerupActive;

	private float PowerupLenghCounter;
	private ScoreManager theScoreManager;
	private PlatformGenerator thePlatformGenerator;
	private float spikeRate;
	private float normalPointsPerSecond;
	private PlatformDeathLaser[] SpikesList;
	private GameController theGameController;

	void Start () {

		theScoreManager = FindObjectOfType<ScoreManager> ();
		thePlatformGenerator = FindObjectOfType<PlatformGenerator> ();
		theGameController = FindObjectOfType<GameController> ();
	}

	void Update () {

		if (powerupActive == true) {
		
			PowerupLenghCounter -= Time.deltaTime;
		
			if (theGameController.powerupReset == true) {

				PowerupLenghCounter = 0;
				theGameController.powerupReset = false;
			}

			if (doublePoints == true) {
			
				theScoreManager.pointsPerSEcond = normalPointsPerSecond * 2.75f;
				theScoreManager.shouldDouble = true;
			
			}

			if (safeMode == true) {
			
				thePlatformGenerator.randomSpikeTreshold = 0f;
			
			
			}

			if (PowerupLenghCounter <= 0) {
			
				theScoreManager.pointsPerSEcond = normalPointsPerSecond;
				thePlatformGenerator.randomSpikeTreshold = spikeRate;
				theScoreManager.shouldDouble = false;
				powerupActive = false;
			
			}
		}
		
	}

	public void ActivatePowerup(bool points, bool safe, float time) {
	
		doublePoints = points;
		safeMode = safe;
		PowerupLenghCounter = time;
	
		normalPointsPerSecond = theScoreManager.pointsPerSEcond;
		spikeRate = thePlatformGenerator.randomSpikeTreshold;

		if (safeMode == true) {
			SpikesList = FindObjectsOfType<PlatformDeathLaser> ();

			for (int i = 0; i < SpikesList.Length; i++) {
				if (SpikesList [i].gameObject.name.Contains("DeathBlock")) {
					SpikesList [i].gameObject.SetActive (false);
				}
			}

		}

		powerupActive = true;
	}
}
