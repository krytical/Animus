using UnityEngine;
using System.Collections;

public class followOrbForPlayer2 : MonoBehaviour {

		public float yoffset;
		private float xoffset = 0.15f;
		private float zoffset = -1.2f;
		
		
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
