using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class MaineMenu : MonoBehaviour {

	public string playGameLevel;

	public void PlayGame() {

		SceneManager.LoadScene ("MainStage");
	}

	public void QuitGame() {
	
		Application.Quit();
	
	}

}
