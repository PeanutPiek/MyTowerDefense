using System;
using UnityEngine;

namespace MyTowerDefense
{
	public class GridPath
	{

		public Vector2[] points {
			get {
				return _points;
			}
		}

		public Vector2 origin {
			get {
				if (_points.Length > 0) {
					return _points [0];
				}
				return Vector2.zero;
			}
		}

		public Vector2 target {
			get {
				if (_points.Length > 0) {
					return _points [_points.Length - 1];
				}
				return Vector2.zero;
			}
		}


		private Vector2[] _points;

		private int nfi;


		public GridPath (Vector2[] points)
		{
			this._points = points;
			this.nfi = 0;
		}


		public bool HasNext() {
			return this.nfi < this._points.Length;
		}

		public Vector2 GetNext() {
			return this._points [this.nfi++];
		}

		public void Reset() {
			this.nfi = 0;
		}

		public Vector2 GetNearest(Vector2 pos) {
			Vector2 nearest = this.origin;
			float minDist = float.MaxValue;
			foreach (Vector2 v in this._points) {
				Vector2 distance = new Vector2 (pos.x - v.x, pos.y - v.y);
				if (distance.magnitude < minDist) {
					minDist = distance.magnitude;
					nearest = v;
				}
			}
			return nearest;
		}


		public int GetNearestIndex(Vector2 pos) {
			int index = 0;
			float minDist = float.MaxValue;
			for (int i = 0; i < this._points.Length; ++i) {
				Vector2 v = this._points [i];
				Vector2 distance = new Vector2 (pos.x - v.x, pos.y - v.y);
				if (distance.magnitude < minDist) {
					minDist = distance.magnitude;
					index = i;
				}
			}
			return index;
		}
	}
}