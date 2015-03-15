using UnityEngine;
using System.Collections;

public class BlackTrigger : MonoBehaviour {
	public bool isStart; // 1 if start piece
	public bool isEnd; // 1 if end piece
	public BlackTrigger prevPiece; // previous piece
	public BlackTrigger startPiece;
	public float timeToSolve;
	public GameObject parentObjectToDestroy;
	
	public float delay = 0.0f;
	private bool isTriggered; // 1 if it is triggered (looked at)
	private CardboardHead head;
	
	
	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		GetComponent<Renderer> ().material.color = Color.black;
		isTriggered = false;
		delay = 0.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		// Middle chain
		if (!isStart && !isEnd) {
			if (isLookedAt && prevPiece.isTriggered) {
				isTriggered = true;
				//GetComponent<Renderer> ().material.color = isLookedAt ? Color.green : Color.red;
			}
		}
		
		// End piece
		if (isEnd && prevPiece.isTriggered && startPiece.isTriggered) {
			// find time for first piece / see if valid
			//GetComponent<Renderer> ().material.color =  Color.green;
			GameObject player = GameObject.FindWithTag ("Player");
			GameObject playerTelePos = GameObject.FindWithTag("TeleReturnPos");
			player.transform.position = playerTelePos.transform.position;
		}
		
		
		// Start Piece / Timer
		if (isStart) {
			if(isLookedAt){
				isTriggered = true;
				//GetComponent<Renderer> ().material.color = isLookedAt ? Color.green : Color.red;
				delay = Time.time + timeToSolve;
			}
			if(Time.time > delay){
				isTriggered = false;
				//GetComponent<Renderer> ().material.color = Color.red;
			}
		}
		
		//Timer
		if (!isStart) {
			if (Time.time > startPiece.delay) {
				isTriggered = false;
				//GetComponent<Renderer> ().material.color = Color.red;
			}
		}
	}
}
