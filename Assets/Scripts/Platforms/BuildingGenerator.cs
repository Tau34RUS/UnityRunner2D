using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour {

	public GameObject theBuilding;
	public Transform generationPoint;
	private float distanceBetween;

	public float distanceBetweenMin;
	public float distanceBetweenMax;
	private int buildingSelector;

	public ObjectPooles[] theObjectPools;

	void Start () {

	}

	void Update () {

		if (transform.position.x < generationPoint.position.x) {

			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			buildingSelector = Random.Range (0, theObjectPools.Length);

			transform.position = new Vector3 (transform.position.x + distanceBetween, transform.position.y, transform.position.z);

			GameObject newBuilding = theObjectPools[buildingSelector].GetPooledObject();

			newBuilding.transform.position = transform.position;
			newBuilding.transform.rotation = transform.rotation;

			newBuilding.SetActive (true);

		}


	}
}
