using UnityEngine;
using System.Collections;

public class shooter : MonoBehaviour {

	public GameObject shot;
	public float whenToShoot;
	public float amountOfTimeToLook;
	public float timeToDestroy;

	private CardboardHead head;
	private bool isShot = false;
	private float delay = 0.0f;
	private float startTime;

	void Start(){
		head = Camera.main.GetComponent<StereoController>().Head;
		startTime = Time.time;
		Destroy (this.gameObject, timeToDestroy);
	}

	// Update is called once per frame
	void Update () {
		// look at player
		Vector3 v = Camera.main.transform.position - transform.position;
		v.x = v.z = 0.0f;
		v.y = 1.0f;
		transform.LookAt( Camera.main.transform.position - v );

		//when to shoot
		if (Time.time > (whenToShoot + startTime) && !isShot) {
			isShot = true;
			shot = (GameObject)Instantiate (shot, transform.position, transform.rotation);
		}

		// is looked at or triggered
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if ((isLookedAt && Time.time > delay) || (isLookedAt && Cardboard.SDK.CardboardTriggered)) { 
			Destroy (this.gameObject);
		}

		if (isLookedAt) { 
			GetComponent<Renderer> ().material.color = Color.red; 
		} else if (!isLookedAt) { 
			GetComponent<Renderer> ().material.color = Color.black;
			delay = Time.time + amountOfTimeToLook;
		}

	}

}
