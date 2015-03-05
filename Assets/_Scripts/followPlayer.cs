using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {

	public Cardboard player;
	private Vector3 offset;

	void Start(){
		offset = transform.position;
	}

	void LateUpdate(){
		transform.position = player.transform.position + offset;
	}
	
}

