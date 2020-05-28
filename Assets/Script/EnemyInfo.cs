using System;

using UnityEngine;

namespace MyTowerDefense
{
	[System.Serializable]
	public class EnemyInfo
	{

		public string name;

		public GameObject prefab;

		public float life;

		public float speed;

		public long value;


		public EnemyInfo ()
		{
		}
	}
}

