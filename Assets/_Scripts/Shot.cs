using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
	public float speed;
	public float timeToDestroy;

	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += speed * gameObject.transform.forward;
		if (Time.time - startTime >= timeToDestroy) {
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.GetComponent<Collider>().gameObject.tag == "Player") {
			GameObject player = GameObject.FindWithTag ("Player");
			GameObject destination = GameObject.FindWithTag ("BlackTrap");
			GameObject playerTelePos = GameObject.FindWithTag("TeleReturnPos");
			playerTelePos.transform.position = player.transform.position;
			player.transform.position = destination.transform.position;
		}
	}
}
