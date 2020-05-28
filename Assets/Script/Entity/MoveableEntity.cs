using System;
using UnityEngine;

namespace MyTowerDefense
{
	public class MoveableEntity : Entity
	{

		public float speed;


		public MoveableEntity (string name, GameObject prefab) : base(name, prefab)
		{
			this.speed = 1f;
		}
	}
}

