using System;

using UnityEngine;


namespace MyTowerDefense
{
	[System.Serializable]
	public class TowerInfo
	{
		public string name;

		public long cost;

		public long upgradeCost;

		public GameObject prefab;

		public GameObject bulletPrefeb;

		public AttackInfo attack;

		public TowerInfo ()
		{
		}
	}
}

