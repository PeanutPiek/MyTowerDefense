using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float hm, vm, scroll;
		scroll = Input.GetAxis ("Mouse ScrollWheel");
		if (scroll != 0) {
			float size = Camera.main.orthographicSize;
			size -= scroll;
			Camera.main.orthographicSize = size;
		}
		Vector3 position = Camera.main.transform.position;
		if ((hm = Input.GetAxis("Horizontal")) != 0) {
			position.x += hm;
		}
		if ((vm = Input.GetAxis("Vertical")) != 0) {
			position.y += vm;
		}
		Camera.main.transform.position = position;
	}
}
