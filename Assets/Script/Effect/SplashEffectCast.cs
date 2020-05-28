using System;

namespace MyTowerDefense
{
	public class SplashEffectCast : EffectCast
	{
		public float radius {
			get {
				return _radius;
			}
		}
		private float _radius;

		public SplashEffectCast (float radius) : base("SplashEffect")
		{
			this._radius = radius;
		}


		public override void Cast (Enemy enemy)
		{
			SplashEffect e = enemy.gameObject.GetComponent<SplashEffect> ();
			if (e == null) {
				e = enemy.gameObject.AddComponent<SplashEffect> ();
				e.radius = _radius;
			}
		}
	}
}

