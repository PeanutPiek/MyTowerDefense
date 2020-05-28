using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyTowerDefense;

public class BulletHandler : MonoBehaviour {

	public Tower tower;

	public Vector2 direction;

	private float accFactor = 20f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = gameObject.transform.position;
		Vector2 origin = tower.gameObject.transform.position;
		Vector2 distance = new Vector2 (origin.x - position.x, origin.y - position.y);
			
		if (distance.magnitude < 1000) {
			Vector2 moveTo = new Vector2 (position.x - direction.x * Time.deltaTime * accFactor, position.y - direction.y * Time.deltaTime * accFactor);
			gameObject.transform.position = moveTo;
		} else {
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag("Enemy")) {
			Destroy (gameObject);	
		}
	}


}
