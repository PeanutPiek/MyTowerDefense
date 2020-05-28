using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyTowerDefense;

public class GridMovementHandler : MonoBehaviour {

	const float IS_REACHED = 0.1f;

	public MoveableEntity entity;

	public Vector2[] path;

	public Vector2 currentTarget {
		get {
            if (path.Length > 0)
            {
                return path[0];
            }
            return Vector2.zero;
		}
	}

	public float delayFactor = 1f;

	private bool dead = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (path.Length > 0) {
			Vector2 position = gameObject.transform.localPosition;
			Vector2 target = path [0];
			Vector2 distance = new Vector2 (target.x - position.x, target.y - position.y);
			if (distance.magnitude > IS_REACHED) {
				//Debug.Log (string.Format ("Move to Target {0}, distance={1}", target, distance.magnitude));
				Vector2 direction = distance.normalized;
				float rho = entity.speed * Time.deltaTime * delayFactor;
				Vector2 moveTo = new Vector2 (position.x + direction.x * rho, position.y + direction.y * rho);
				//Debug.Log (string.Format ("New Target: {0}", moveTo));
				gameObject.transform.localPosition = moveTo;
			} else {
				//Debug.Log ("Target reached.");
				Vector2[] npath = new Vector2[path.Length - 1];
				for (int i = 1; i < path.Length; ++i) {
					npath [i - 1] = path [i];
				}
				path = npath;
			}
		} else {
			//Debug.Log ("No Target Left.");
			Destroy (this.gameObject, 1);
			if (!dead) {
				GameObject.Find ("Game").GetComponent<GameController> ().HitPlayer ();
			}
			dead = true;
		}
	}
}
