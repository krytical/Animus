﻿using UnityEngine;
using System.Collections;

public class Autowalk : MonoBehaviour {
	public float amountOfTimeToLook;


	private CardboardHead head;
	//private Vector3 startingPosition;
	private float delay = 0.0f; 
	
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		//startingPosition = transform.localPosition;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		// if looking at object for 2 seconds, enable/disable autowalk
		if ((isLookedAt && Time.time>delay) || (isLookedAt && Cardboard.SDK.CardboardTriggered)) { 
			GameObject FPSController = GameObject.Find("Head");
			FPSInputController autowalk = FPSController.GetComponent<FPSInputController>();
			autowalk.checkAutoWalk = !autowalk.checkAutoWalk;
			delay = Time.time + amountOfTimeToLook;
		}
		// currently looking at object
		else if (isLookedAt) { 
			GetComponent<Renderer>().material.color = Color.yellow; 
		} 
		// not looking at object
		else if (!isLookedAt) { 
			GetComponent<Renderer>().material.color = Color.red; 
			delay = Time.time + amountOfTimeToLook; 
		}
	}
	
}
