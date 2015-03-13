using UnityEngine;
using System.Collections;

public class LookAtSpawnScript : MonoBehaviour {
	
	public GameObject objToSpawn;

	private float delay = 0.0f;
	private CardboardHead head;
	private GameObject objSpawned;
	private bool spawned;
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		spawned = false;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if (((Cardboard.SDK.CardboardTriggered && isLookedAt) || (Time.time>delay && isLookedAt)) && !spawned) {
			//Spawn Object
			objSpawned = (GameObject)Instantiate(objToSpawn, transform.position, transform.rotation);
			spawned = true;

		}
		if (!isLookedAt && spawned) {
			Destroy (objSpawned);
			spawned = false;
		}
		if (!isLookedAt) {
			delay = Time.time + 1.0f;
		}
	
	}
}
