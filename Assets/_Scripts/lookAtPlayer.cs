﻿using UnityEngine;
using System.Collections;

	

public class lookAtPlayer : MonoBehaviour {
	//public GameObject cameraToLookAt;
	// Use this for initialization
	//public float yoffset;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v = Camera.main.transform.position - transform.position;
		
		v.x = v.z = 0.0f;
		v.y = 5.0f;
		
		transform.LookAt( Camera.main.transform.position - v );
		
		transform.rotation =(Camera.main.transform.rotation);
		if (transform.position.y <= 2.0f) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + 1.0f, transform.position.z);
		}
		
	}
}
