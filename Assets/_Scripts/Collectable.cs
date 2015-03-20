﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Collectable : MonoBehaviour {
	public float howLongToLook;

	private CardboardHead head;

	private float delay = 0.0f; 	
	Object[] orbs;
	private bool alreadyDidOne = false;
 
	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;

		orbs = GameObject.FindGameObjectsWithTag("HaloOrb");
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		GetComponent<Renderer>().material.color = isLookedAt ? Color.green : Color.red;

		if (!isLookedAt) {
			delay = Time.time + howLongToLook;
		}

		if ((Cardboard.SDK.CardboardTriggered && isLookedAt) || (Time.time>delay && isLookedAt) ) {
			// Do Stuff black if looked at for now
			//GetComponent<Renderer>().material.color = isLookedAt ? Color.black : Color.red;
			orbs = GameObject.FindGameObjectsWithTag("HaloOrb");
			if (orbs.Length == 0) {
				Debug.LogError ("No Orbs");
				return;
			}
			if(!alreadyDidOne){
				Destroy(orbs [Random.Range (0, orbs.Length)]);
				Destroy (this.gameObject);
				alreadyDidOne = true;
			}
		}
	}
}
