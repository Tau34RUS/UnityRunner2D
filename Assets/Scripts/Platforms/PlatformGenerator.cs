using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	private float distanceBetween;

	private float platformWidth;
	public float distanceBetweenMin;
	public float distanceBetweenMax;

	private int platformSelector;
	private float[] platformWidths;

	private CoinGenerator theCoinGenerator;

	public ObjectPooles[] theObjectPools;

	public float randomCoinTreshold;

	public float randomSpikeTreshold;

	public ObjectPooles deathBlocks;

	public float powerupHeight;

	public ObjectPooles powerupPool;

	public float powerupTreshold;

	void Start () {

		platformWidths = new float[theObjectPools.Length];

		for (int i = 0; i < theObjectPools.Length; i++) {
		
			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		
		}

		theCoinGenerator = FindObjectOfType<CoinGenerator> ();
			
	}

	void Update () {

		if (transform.position.x < generationPoint.position.x) {

			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			platformSelector = Random.Range (0, theObjectPools.Length);

			if (Random.Range (0f, 100f) < powerupTreshold) {
			
				GameObject newPowerup = powerupPool.GetPooledObject ();

				newPowerup.transform.position = transform.position + new Vector3(distanceBetween/2f, Random.Range (powerupHeight/2, powerupHeight),0f);

				newPowerup.SetActive (true);
			
			}

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween, transform.position.y, transform.position.z);
		
			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);


			if (Random.Range (0f, 100f) < randomCoinTreshold) {
			
				theCoinGenerator.SpawnCoins (new Vector3 (transform.position.x, transform.position.y + theCoinGenerator.distanceFromGround, transform.position.z));
			}

			if (Random.Range (0f, 100f) < randomSpikeTreshold) {

				GameObject newSpike = deathBlocks.GetPooledObject ();

				float spikeXPosition = Random.Range (-platformWidths[platformSelector] +1f / 2, platformWidths[platformSelector] / 2 -1f); 

				Vector3 spikePosition = new Vector3(spikeXPosition,0.5f,-1f);

				newSpike.transform.position = transform.position + spikePosition;
				newSpike.transform.rotation = transform.rotation;
				newSpike.SetActive (true);
			}

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector]/2), transform.position.y, transform.position.z);

		}

	}
}
