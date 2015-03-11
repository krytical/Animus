using UnityEngine;
using System.Collections;

public class LookAtSpawnScript : MonoBehaviour {
	
	public GameObject objToSpawn;

	private CardboardHead head;
	private GameObject objSpawned;
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if (isLookedAt) {
			//Spawn Object
			objSpawned = (GameObject)Instantiate(objToSpawn, transform.position, transform.rotation);

		}
	
	}
}
