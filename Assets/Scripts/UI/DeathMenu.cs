using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

	public string backMainMenu;
	public GameObject pauseButton;

	public void RestartGame() {

		//FindObjectOfType<GameController> ().Reset ();
		Time.timeScale = 1f;
		pauseButton.SetActive (true);
		SceneManager.LoadScene ("MainStage");

	}

	public void quit2MainMenu() {

		//Application.LoadLevel (backMainMenu);
		Time.timeScale = 1f;

		SceneManager.LoadScene ("MainMenu");

	}

}
