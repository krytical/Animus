using UnityEngine;
using System.Collections;

public class teleportToNextLevel : MonoBehaviour {

	private GameObject[] haloOrbs;
	private CardboardHead head;
	private bool spawnTele;
	private float delay = 0.0f;
	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		haloOrbs = GameObject.FindGameObjectsWithTag ("HaloOrb");
		InvokeRepeating ("CheckOrbs", 15, 3);
		GetComponent<Renderer> ().material.color = Color.black;
		spawnTele = false;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if((Cardboard.SDK.CardboardTriggered && isLookedAt) || (Time.time>delay && isLookedAt)){
			GetComponent<Renderer> ().material.color = isLookedAt ? Color.green : Color.red;
			if (spawnTele) {
				Debug.Log("Load level 1.1");
				Application.LoadLevel("Level1.1");
			}
		}
		
		if (!isLookedAt) {
			delay = Time.time + 1.0f;
			GetComponent<Renderer> ().material.color = Color.black;
		}
	}
	
	void CheckOrbs(){
		haloOrbs = GameObject.FindGameObjectsWithTag ("HaloOrb");
		if (haloOrbs.Length == 0) {
			spawnTele = true;
		}
	}
}
