using UnityEngine;
using System.Collections;

public class dummyShooter : MonoBehaviour {
	public GameObject shot;
	private GameObject invoke;
	public float shootHowOften;

	
	private CardboardHead head;

	private float delay = 0.0f;
	
	void Start(){
		head = Camera.main.GetComponent<StereoController>().Head;
		InvokeRepeating ("Shoot", 3, shootHowOften);
	}
	
	// Update is called once per frame
	void Update () {
		// is looked at or triggered
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		
		if (isLookedAt) { 
			GetComponent<Renderer> ().material.color = Color.red; 
		} else if (!isLookedAt) { 
			GetComponent<Renderer> ().material.color = Color.black;
			delay = Time.time + shootHowOften;
		}
		
	}

	void Shoot(){
		invoke = (GameObject)Instantiate (shot, transform.position, transform.rotation);
	}

}
