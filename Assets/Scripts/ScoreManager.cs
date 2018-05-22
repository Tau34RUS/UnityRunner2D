using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text hiScoreText;
	public float pointsPerSEcond;
	public bool scoreIncreasing;

	public float scoreCount;
	private float hiScoreCount;

	public bool shouldDouble;

	// Use this for initialization
	void Start () {

		if(PlayerPrefs.HasKey("HighScore")){

			hiScoreCount = PlayerPrefs.GetFloat ("HighScore");

		}
	}
	
	// Update is called once per frame
	void Update () {

		if (scoreIncreasing) {
			
			scoreCount += pointsPerSEcond * Time.deltaTime;

		}

		if (scoreCount > hiScoreCount) {

			hiScoreCount = scoreCount;
			PlayerPrefs.SetFloat ("HighScore", hiScoreCount);

		}

		scoreText.text = "Score: " + Mathf.Round(scoreCount);
		hiScoreText.text = "High Score: " + + Mathf.Round(hiScoreCount);
	}

	public void AddScore(int pointsToAdd) {
	
		if (shouldDouble == true) {
		
			pointsToAdd = pointsToAdd * 2;
		
		}
		scoreCount += pointsToAdd;
	
	}
}
