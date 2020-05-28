using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerHandler : MonoBehaviour {


	public float ttl;

	private float life;

	private bool run;

	// Use this for initialization
	void Start () {
		life = 0f;
		run = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = gameObject.transform.position;
		position.y += 0.25f * Time.deltaTime;
		gameObject.transform.position = position;
		if (life > ttl) {
			Destroy (this.gameObject);
		}
		life += Time.deltaTime;
	}
}
