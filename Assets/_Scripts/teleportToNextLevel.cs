using UnityEngine;
using System.Collections;

public class teleportToNextLevel : MonoBehaviour {

	public GameObject haloOrb0;
	public GameObject haloOrb1;
	public GameObject haloOrb2;
	public GameObject haloOrb3;
	private CardboardHead head;
	private float delay = 0.0f;
	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		GetComponent<Renderer> ().material.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		bool isReady = (haloOrb0 == null) && (haloOrb1 == null) && (haloOrb2 == null) && (haloOrb3 == null);
		if((Cardboard.SDK.CardboardTriggered && isLookedAt) || (Time.time>delay && isLookedAt)){
			GetComponent<Renderer> ().material.color = isLookedAt ? Color.green : Color.red;
			if (isReady) {
				Debug.Log("Load level 1.1");
				Application.LoadLevel("Level1.1");
			}
		}
		
		if (!isLookedAt) {
			delay = Time.time + 1.0f;
			GetComponent<Renderer> ().material.color = Color.black;
		}
	}
}
