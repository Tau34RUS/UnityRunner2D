using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour {
	void OnGui(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
	}

}
