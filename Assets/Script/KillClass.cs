using System;

namespace MyTowerDefense
{
	public class KillClass
	{
		public string label {
			get {
				return _label;
			}
		}
		private string _label;

		public long required {
			get {
				return _required;
			}
		}
		private long _required;

		public KillClass (string label, long required)
		{

			this._label = label;
			this._required = required;
		}
	}
}

