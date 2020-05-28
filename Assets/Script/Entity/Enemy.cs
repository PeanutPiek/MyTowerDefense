using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTowerDefense
{
	public class Enemy : MoveableEntity
	{
		private float maxLife;

		private float life;

		private long value;


		public long armor {
			get {
				return _armor;
			}
		}
		private long _armor;

		public List<Effect> stateEffects {
			get {
				return _stateEffects;
			}
		}
		private List<Effect> _stateEffects = new List<Effect> ();
		
		public Enemy (string name, GameObject prefab) : base(name, prefab)
		{
		}

		public Enemy(EnemyInfo info) : base(info.name, info.prefab)
		{
			maxLife = life = info.life;
			speed = info.speed;
			value = info.value;
		}



		public void Hit(AttackInfo attack) {
			float damage = attack.damage;
			if (attack.type != DamageType.PIERCE) {
				damage -= armor / 10;
			}
			foreach (EffectCast e in attack.effects) {
				Debug.Log (string.Format ("Add Effect {0} to Enemy {1}", e.name, this.name));
				e.Cast (this);
				damage += e.damage;
			}
			life = life - Mathf.Max (damage, 0f);
		}


		public bool isDead() {
			return life <= 0;
		}


		public float GetLifepoints() {
			return this.maxLife;
		}


		public float GetCurrentLifepoints() {
			return this.life;
		}


		public long GetEntityValue() {
			return this.value;
		}


		protected override void setupObject (GameObject ob)
		{
			base.setupObject (ob);
			EnemyHandler handler = ob.AddComponent<EnemyHandler> ();
			handler.entity = this;
		}
	}
}

