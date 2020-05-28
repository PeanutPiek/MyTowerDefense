using System;
using UnityEngine;

namespace MyTowerDefense
{
	public class GridTile
	{

		public GameObject tile {
			get {
				return _gameObject;
			}
		}

		private GameObject _gameObject;

		public Tower build {
			get {
				return _building;
			}
		}
		private Tower _building;

		public bool editable {
			get {
				return _editable;
			}
		}

		private bool _editable;

		public GridTile (GameObject parent, GameObject prefab, int x, int y)
		{
			_gameObject = GameObject.Instantiate (prefab);
			_gameObject.transform.parent = parent.transform;
			_gameObject.transform.localPosition = new Vector2 (x, y);
			TileHandler handler = _gameObject.AddComponent<TileHandler> ();
			handler.tile = this;
		}


		public void SetEditable(bool editable) {
			this._editable = editable;
		}


		public GameObject Build(TowerInfo info) {
			if (_building == null) {
				if (_editable) {
					_building = new Tower (info);

					return _building.Spawn (Vector2.zero, _gameObject.transform);
				}
				return null;
			}
			throw new Exception ("Already build");
		}


		public bool HasBuild() {
			return _building != null;
		}


		public void Clear() {
			if (_building != null) {
				_building.Destroy ();
				_building = null;
			}
		}
			
	}
}

