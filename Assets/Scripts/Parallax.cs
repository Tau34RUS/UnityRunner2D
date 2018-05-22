using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {
	
	public float forwardSpeed;

	void Update() {
		transform.Translate(Vector2.right * Time.deltaTime * forwardSpeed);
	}
}