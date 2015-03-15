using UnityEngine;
using System.Collections;

public class shooter : MonoBehaviour {

	public GameObject shot;

	void Start(){
		StartCoroutine (Fire ());
	}

	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Fire(){
		while (true) {
			shot = (GameObject)Instantiate (shot, transform.position, transform.rotation);
			yield return new WaitForSeconds(3);
		}
	}
}
