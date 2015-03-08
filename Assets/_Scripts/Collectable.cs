using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Collectable : MonoBehaviour {

	private CardboardHead head;
	private Vector3 startingPosition;
	private float delay = 2.0f; 	

	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		GetComponent<Renderer>().material.color = isLookedAt ? Color.red : Color.green;

		if ((Cardboard.SDK.CardboardTriggered && isLookedAt) || (Time.time>delay && isLookedAt) ) {
			// Do Stuff black if looked at for now
			GetComponent<Renderer>().material.color = isLookedAt ? Color.black : Color.red;
		}
	}
}
