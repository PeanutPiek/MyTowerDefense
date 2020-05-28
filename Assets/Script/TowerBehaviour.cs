using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTowerDefense {
	public abstract class TowerBehaviour : MonoBehaviour {

		protected TowerHandler tower;

		private bool init = false;

		// Use this for initialization
		void Start () {
			tower = gameObject.GetComponent<TowerHandler> ();
		}
		
		// Update is called once per frame
		void Update () {
			if (!init) {
				init = InitTower ();
			}
			TowerUpdate ();
		}

		protected abstract bool InitTower ();

		protected abstract void TowerUpdate ();
	}
}