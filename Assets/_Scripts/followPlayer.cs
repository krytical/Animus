using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {

	//public GameObject player;
	private Vector3 offset;
	//public Rigidbody rb;

	void Start(){
	//	offset = transform.position;
		//rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate(){
		GameObject player = GameObject.FindWithTag ("Player");
		Vector3 temp = new Vector3(player.transform.position.x, player.transform.position.y + 3.0f, player.transform.position.z);
		transform.position = temp;
		//diff
		//this.transform.position = player.transform.position;
		//this.transform.rotation = player.transform.rotation;
		//rb.MovePosition (player.transform.position + transform.up);
	}
	
}

