using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyTowerDefense;

public class SlowEffectActivator : TowerBehaviour {

	public float factor;

	public float duration;

	private SlowEffectCast effect;

	protected override bool InitTower ()
	{
		AttackInfo attack = tower.entity.attack;
		effect = new SlowEffectCast (factor, duration);
		attack.effects.Add (effect);
		tower.entity.attack = attack;
		return true;
	}

	protected override void TowerUpdate ()
	{}
		
}
