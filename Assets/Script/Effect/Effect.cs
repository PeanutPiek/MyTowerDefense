using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour {

	public float duration;

	private float counter;

	// Use this for initialization
	void Start () {
		Activate ();
	}
	
	// Update is called once per frame
	void Update () {
		if (counter > duration) {
			Deactivate ();
			Destroy (this);
		} else {
			Tick (Time.deltaTime);
		}
		counter += Time.deltaTime;
	}


	protected abstract void Activate ();

	protected abstract void Deactivate();

	protected abstract void Tick (float time);
}
