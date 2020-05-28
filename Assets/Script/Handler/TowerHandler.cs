using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyTowerDefense;

public class TowerHandler : MonoBehaviour {

	public Tower entity;

	public bool isEnabled = true;

	private List<GameObject> targets;


	private float lastShot;

	// Use this for initialization
	void Start () {
		targets = new List<GameObject> ();
		lastShot = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (isEnabled && targets.Count > 0) {
			if (Time.time > lastShot + entity.GetAttackInfo ().speed * Time.deltaTime) {
				int n = 0;
				GameObject tar = null;
				while ((tar = targets [n++]) == null && n < targets.Count) {
				}
				if (tar != null) {

					GridMovementHandler mHandler = tar.GetComponent<GridMovementHandler> ();

					Vector2 target = tar.transform.position;
					Vector2 distance = new Vector2 (target.x - gameObject.transform.position.x, target.y - gameObject.transform.position.y);
					Vector2 moveTo = mHandler.currentTarget;
					Vector2 moveDir = new Vector2 (moveTo.x - target.x, moveTo.y - target.y).normalized;
					
					target = new Vector2 (target.x + (moveDir.x * 1 / distance.magnitude), target.y + (moveDir.y * 1 / distance.magnitude));
					Bullet bullet = entity.Shot (target);
					lastShot = Time.time;
				}
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (isEnabled && coll.gameObject.CompareTag ("Enemy")) {
			targets.Add (coll.gameObject);
		}
	}


	void OnCollisionExit2D(Collision2D coll) {
		targets.Remove (coll.gameObject);
	}
}
