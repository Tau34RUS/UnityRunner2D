using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public Transform platformGenerator;
	public Transform buildingGenerator;
	public Transform trashGenerator;
	public Transform backGenerator;
	public Movement thePlayer;
	private Vector3 platformStartingPoint;
	private Vector3 trashStartingPoint;
	private Vector3 playerStartPoint;
	private Vector3 buildinStartingPoint;
	private Vector3 backStartingPoint;

	private PlatformDeathLaser[] platformsList;

	private ScoreManager theScoreManager;

	public DeathMenu theDeathScreen;

	public bool powerupReset;

	void Start () {

		platformStartingPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;
		buildinStartingPoint = buildingGenerator.position;
		trashStartingPoint = trashGenerator.position;
		backStartingPoint = backGenerator.position;
		theScoreManager = FindObjectOfType<ScoreManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void RestartGame () {
	
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		theDeathScreen.gameObject.SetActive(true);
	
	}

	public void Reset() {
	
		platformsList = FindObjectsOfType<PlatformDeathLaser>();

		for (int i = 0; i < platformsList.Length; i++) {

			platformsList[i].gameObject.SetActive(false);

		}

		platformGenerator.position = platformStartingPoint;
		thePlayer.transform.position = playerStartPoint;
		buildingGenerator.position = buildinStartingPoint;
		trashGenerator.position = trashStartingPoint;
		thePlayer.gameObject.SetActive (true);
		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
		backGenerator.position = backStartingPoint;
	
		theDeathScreen.gameObject.SetActive(false);

		powerupReset = true;
	}
		
}
