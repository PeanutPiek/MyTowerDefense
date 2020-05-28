using System;
using UnityEngine;

namespace MyTowerDefense
{
	[System.Serializable]
	public abstract class EffectCast
	{
		public string name {
			get {
				return _name;
			}
		}
		private string _name;

		public float damage {
			get {
				return _damage;
			}
		}
		protected float _damage = 0f;

		public float duration {
			get {
				return _duration;
			}
		}
		protected float _duration = 0f;

		public bool active {
			get {
				return _active;
			}
		}
		private bool _active;

		public EffectCast (string name)
		{
			this._name = name;
			this._active = true;
		}


		public abstract void Cast (Enemy enemy);
	}
}

