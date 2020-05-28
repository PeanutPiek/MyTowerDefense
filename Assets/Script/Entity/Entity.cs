using System;
using UnityEngine;

namespace MyTowerDefense
{
	public class Entity
	{
		public string name {
			get {
				return _name;
			}
		}
		private string _name;

		private GameObject prefab;

		public GameObject gameObject {
			get {
				return _gameObject;
			}
		}
		private GameObject _gameObject;

		public Entity (string name, GameObject prefab)
		{
			this._name = name;
			this.prefab = prefab;
		}


		public GameObject Spawn(GameObject parent) {
			return this.Spawn (parent.transform.position, parent.transform);
		}


		public GameObject Spawn(Vector2 position, Transform parent = null) {
			if (_gameObject != null) {
				//GameObject.Destroy (_gameObject);
				Destroy();
			}
			GameObject go = GameObject.Instantiate (prefab);
			setupObject (go);
			go.name = _name;
			if (parent != null) {
				go.transform.parent = parent;
			}
			go.transform.localPosition = position;
			_gameObject = go;
			return _gameObject;
		}


		public void Destroy() {
			disposeObject ();
			GameObject.Destroy (_gameObject);
		}

		protected virtual void setupObject(GameObject ob) {

		}


		protected virtual void disposeObject() {

		}
	}
}

