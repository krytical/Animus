﻿using UnityEngine;
using System.Collections;

public class followOrbForPlayer3 : MonoBehaviour {

	public float yoffset;
	private float xoffset = 2.0f;
	private float zoffset = -3.0f;
	
	
	void Start(){
		Renderer rend = GetComponent<Renderer> ();
		rend.enabled = true;
	}
	
	void FixedUpdate(){
		GameObject player = GameObject.FindWithTag ("Player");
		Vector3 temp = new Vector3(player.transform.position.x + xoffset, player.transform.position.y + yoffset, player.transform.position.z +zoffset);
		transform.position = temp;

	}

}
