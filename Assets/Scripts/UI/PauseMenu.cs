using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public string backMainMenu;

	public GameObject pauseMenu;

	void Start() {

	}

	public void RestartGame() {

		Time.timeScale = 1f;
		//FindObjectOfType<GameController> ().Reset ();
		SceneManager.LoadScene ("MainStage");
		pauseMenu.SetActive (false);
	}

	public void quit2MainMenu() {

		Time.timeScale = 1f;
		//Application.LoadLevel (backMainMenu);
		SceneManager.LoadScene ("MainMenu");

	}

	public void PauseGame(){
	
		Time.timeScale = 0f;
		pauseMenu.SetActive (true);
	
	}

	public void ResumeGame(){
	
		Time.timeScale = 1f;
		pauseMenu.SetActive (false);
	
	}
}
