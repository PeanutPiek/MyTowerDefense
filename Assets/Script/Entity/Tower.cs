using System;
using UnityEngine;

namespace MyTowerDefense
{
	public class Tower : Entity
	{
		public GameObject bulletPrefab {
			get {
				return _bulletPrefab;
			}
		}
		private GameObject _bulletPrefab;

		public AttackInfo attack {
			get {
				return _attack;
			}
			set {
				_attack = value;
			}
		}
		private AttackInfo _attack;

		public long killCount {
			get {
				return _killCount;
			}
			set {
				_killCount = value;
			}
		}
		private long _killCount;

		public long level {
			get {
				return _level+1;
			}
		}
		private long _level;

		public long cost {
			get {
				return _cost;
			}
		}
		private long _cost;

		public Tower (TowerInfo info) : base(info.name, info.prefab)
		{
			this._attack = info.attack;
			this._bulletPrefab = info.bulletPrefeb;
			this._cost = info.upgradeCost;
		}


		public AttackInfo GetAttackInfo() {
			return _attack;
		}

		public Bullet Shot(Vector2 target) {
			Bullet b = new Bullet (this, target);
			return b;
		}


		public void LevelUp() {
			this._level += 1;
			this._cost = (long)(this._cost * 1.5);
			AttackInfo ai = _attack;
			ai.damage = (1 + (ai.damage / 2)) * _level;
			ai.range = (1 + (ai.range / 2)) * _level;
			ai.speed = (1 + (ai.speed / 2)) * _level;
			_attack = ai;
		}


		protected override void setupObject (GameObject ob)
		{
			base.setupObject (ob);
			TowerHandler handler = ob.AddComponent<TowerHandler> ();
			handler.entity = this;
			handler.isEnabled = true;
			CircleCollider2D collider = ob.GetComponent<CircleCollider2D> ();
			collider.radius = 1 * _attack.range;
		}
			


		protected override void disposeObject ()
		{
			base.disposeObject ();

		}


	}
}

