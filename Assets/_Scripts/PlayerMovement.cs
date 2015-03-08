using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

		public float speed;

	void Update()
	{

	}

	void FixedUpdate()
	{
		//float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (1.0f, 0.0f, 0.0f);

		GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);
	}
}
