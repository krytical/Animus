using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	SpawnSpot[] spawnSpots;
	public GameObject haloOrb;
	public GameObject orb;
	public int numOfOrbs;
	private GameObject shooterInstance;
	public GameObject shooterPrefab;
	public float timeToSpawnShooter;
	
	// Use this for initialization
	void Start () {
		/*spawnSpots = GameObject.FindObjectsOfType<SpawnSpot> ();
		int a = 0;
		while (a < numOfOrbs) {
			SpawnOrbs ();
			a++;
		}*/
		//SpawnHaloOrb (numOfOrbs);
		//Debug.Log ("Started");

		StartCoroutine(SpawnShooter());
	}


	/*void SpawnOrbs() {
		if (spawnSpots == null) {
			Debug.LogError ("No Spawn Spots");
			return;
		}
		Debug.Log ("In SpawnOrbs");
		SpawnSpot orbSpawnSpot = spawnSpots [Random.Range (0, spawnSpots.Length)];
		Debug.Log ("Created Orb");
		orb = (GameObject)Instantiate (orb, orbSpawnSpot.transform.position, orbSpawnSpot.transform.rotation);

	}*/

	IEnumerator SpawnShooter(){

		while (true) {
			GameObject player = GameObject.FindWithTag ("Player");
			// random teleport
			float xpos, zpos;
			xpos = Random.value + 1.0f;
			zpos = Random.value + 1.0f;
			if (zpos - 1.0f > 0.5f) {
				zpos = -zpos;
			}
			if (xpos - 1.0f < 0.5f) {
				xpos = -xpos;
			}

			Vector3 direction = new Vector3 (player.transform.position.x + xpos * 3, player.transform.position.y + (Random.value * 2.0f), player.transform.position.z + (zpos * 3));
			shooterInstance = (GameObject)Instantiate (shooterPrefab, direction, player.transform.rotation);

			yield return new WaitForSeconds (timeToSpawnShooter);
		}
	}

}
