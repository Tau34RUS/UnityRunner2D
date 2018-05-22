using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGParalax : MonoBehaviour {

	public GameObject theBuilding;
	public Transform generationPoint;
	public float moveSpeed;

	private float distanceBetween;

	private float buildingWidth;
	public float distanceBetweenMin;
	public float distanceBetweenMax;

	void Start () {

		buildingWidth = theBuilding.transform.localScale.x;

	}

	void Update () {

		if (transform.position.x < generationPoint.position.x) {

			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			transform.position = new Vector3 (transform.position.x + buildingWidth + distanceBetween, transform.position.y, transform.position.z);

			Instantiate (theBuilding, transform.position, transform.rotation);

		}


	}
}
