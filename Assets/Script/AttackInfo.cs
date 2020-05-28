using System;
using System.Collections;
using System.Collections.Generic;

namespace MyTowerDefense
{
	[System.Serializable]
	public class AttackInfo
	{
		public float damage;

		public float speed;

		public float range;

		public DamageType type;

		public List<EffectCast> effects = new List<EffectCast>();

		public AttackInfo ()
		{
		}
	}
}

