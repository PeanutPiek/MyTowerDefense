using System;

namespace MyTowerDefense
{
	public class SlowEffectCast : EffectCast
	{
		private float factor;


		public SlowEffectCast (float factor, float duration) : base("Slow")
		{
			this.factor = factor;
			this._duration = duration;
		}


		public override void Cast (Enemy enemy)
		{
			SlowEffect e = enemy.gameObject.GetComponent<SlowEffect> ();
			if (e == null) {
				e = enemy.gameObject.AddComponent<SlowEffect> ();
				e.duration = _duration;
				e.factor = factor;
			}
		}
	}
}

