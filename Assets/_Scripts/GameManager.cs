using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	SpawnSpot[] spawnSpots;
	public GameObject orb;
	// Use this for initialization
	void Start () {
		spawnSpots = GameObject.FindObjectsOfType<SpawnSpot> ();
		SpawnOrbs ();
		Debug.Log ("Started");
	}


	void SpawnOrbs() {
		if (spawnSpots == null) {
			Debug.LogError ("No Spawn Spots");
			return;
		}
		Debug.Log ("In SpawnOrbs");
		SpawnSpot orbSpawnSpot = spawnSpots [Random.Range (0, spawnSpots.Length)];
		Debug.Log ("Created Orb");
		orb = (GameObject)Instantiate (orb, orbSpawnSpot.transform.position, orbSpawnSpot.transform.rotation);
	}
}
