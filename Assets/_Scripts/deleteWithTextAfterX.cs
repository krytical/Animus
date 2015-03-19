using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class deleteWithTextAfterX : MonoBehaviour {
	public float viewTimeToTrigger;
	public float destroyObjectTime;
	public string tagToDestroy;
	public GameObject objToDestroy;
	public Text text;

	private Text[] texts;
	private CardboardHead head;
	private float delay = 0.0f;
	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		GetComponent<Renderer> ().material.color = Color.red;
		//text = objToDestroy.GetComponentInChildren<Text> ();
		texts = objToDestroy.GetComponentsInChildren<Text> ();
		for (int i = 0; i < texts.Length; i++) {
			if(texts[i].gameObject.tag == tagToDestroy){
				text = texts[i];
			}
		}
		text.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);

		if (!isLookedAt) {
			delay = Time.time + viewTimeToTrigger;
			GetComponent<Renderer> ().material.color =  Color.red;
			text.color = Color.Lerp (text.color, Color.clear, 10.0f * Time.deltaTime);
		}
		if (isLookedAt) {
			GetComponent<Renderer> ().material.color =  Color.green;
			text.color = Color.Lerp (text.color, Color.white, 1.0f * Time.deltaTime);
		}
		if (Time.time > delay && isLookedAt) {
			text.color = Color.Lerp (text.color, Color.clear, 10.0f * Time.deltaTime);
			Destroy (objToDestroy, destroyObjectTime);
			Destroy (this.gameObject, destroyObjectTime);
		}

	}
}
