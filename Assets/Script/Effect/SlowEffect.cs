using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTowerDefense {
	public class SlowEffect : Effect {

		public float factor;

		private GridMovementHandler mHandler;

		private float vBuffer;

		protected override void Activate ()
		{
			mHandler = gameObject.GetComponent<GridMovementHandler> ();
			vBuffer = mHandler.delayFactor;
			mHandler.delayFactor = factor;
		}

		protected override void Deactivate ()
		{
			mHandler.delayFactor = vBuffer;
		}


		protected override void Tick (float time)
		{
			
		}
	}
}