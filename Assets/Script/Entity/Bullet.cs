using System;

using UnityEngine;



namespace MyTowerDefense
{
	public class Bullet
	{

		private GameObject _gameObject;

		public Bullet (Tower tower, Vector2 target)
		{
			Vector2 direction = new Vector2 (target.x - tower.gameObject.transform.position.x, target.y - tower.gameObject.transform.position.y);
			_gameObject = GameObject.Instantiate (tower.bulletPrefab);
			_gameObject.transform.parent = tower.gameObject.transform;
			_gameObject.transform.localPosition = Vector2.zero;
			BulletHandler handler = _gameObject.AddComponent<BulletHandler> ();
			handler.tower = tower;
			handler.direction = -direction.normalized;
		}
	}
}

