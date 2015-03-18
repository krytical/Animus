using UnityEngine;
using System.Collections;

public class waitXForTriggerGone : MonoBehaviour {
	public GameObject waitForDestroyed;
	public float waitToDestroySelf;

	private float startTime;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(waitForDestroyed == null){
			startTime = Time.time;
			if(Time.time - startTime >= waitToDestroySelf) {
				Destroy(this.gameObject);
			}
		}
	}
}
