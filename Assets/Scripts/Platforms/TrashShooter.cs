using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashShooter : MonoBehaviour {

	public GameObject theTrash;
	public Transform generationPoint;
	private float distanceBetweenTrash;

	public float distanceBetweenTrashMin;
	public float distanceBetweenTrashMax;
	private int trashSelector;
	public float trashFlySpeed;
	public float trashFlySpeedUp;

	private Rigidbody2D trashRigid;

	public ObjectPooles[] theObjectPools;




	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) {



			distanceBetweenTrash = Random.Range (distanceBetweenTrashMin, distanceBetweenTrashMax);

			trashSelector = Random.Range (0, theObjectPools.Length);

			transform.position = new Vector3 (transform.position.x + distanceBetweenTrash, transform.position.y, transform.position.z);

			GameObject newTrash = theObjectPools[trashSelector].GetPooledObject();

			trashRigid = newTrash.GetComponent<Rigidbody2D>();


			newTrash.transform.position = transform.position;
			newTrash.transform.rotation = transform.rotation;

			//Rigidbody2D trashRigid = newTrash.GetComponent<Rigidbody2D> ();
			newTrash.SetActive (true);
			trashRigid.velocity = new Vector2 (Random.Range (-trashFlySpeed/2, -trashFlySpeed),Random.Range (trashFlySpeedUp/2, trashFlySpeedUp));


		


		}

	}
}
