using System;
using UnityEngine;

namespace MyTowerDefense
{
	public class Grid
	{

		private Vector2 tileCount;

		private GridTile[] tileMap;

		private GameObject gameObject;

		private bool[] tileEditMap;

		private GridPath path;

		public Grid (GameObject grid, Vector2 num, GameObject tilePrefab)
		{
			gameObject = grid;
			tileCount = num;
			int size = (int)(num.x * num.y);
			tileEditMap = new bool[size];
			tileMap = new GridTile[size];
			for (int y = 0; y < num.y; ++y) {
				for (int x = 0; x < num.x; ++x) {
					GridTile tile = new GridTile(grid, tilePrefab, x, y);
					tile.SetEditable (true);
					tileMap [(int)(y * num.x) + x] = tile;
				}
			}
		}


		public void SetPath(GridPath path) {
			for (int y = 0; y < tileCount.y; ++y) {
				for (int x = 0; x < tileCount.x; ++x) {
					int pos = (int)(y * tileCount.y) + x;
					tileMap [pos].SetEditable(true);
				}
			}
			path.Reset ();
			Vector2 origin = path.GetNext ();
			origin.x += (int)(tileCount.x / 2);
			origin.y += (int)(tileCount.y / 2);
			int index;
			while (path.HasNext ()) {
				Vector2 t = path.GetNext ();
				t.x += (int)(tileCount.x / 2);
				t.y += (int)(tileCount.y / 2);
				if (t.x == origin.x) {
					for (int i = 0; i < Math.Abs (t.y - origin.y); ++i) {
						index = (int)((origin.y+i*((t.y - origin.y)/Math.Abs (t.y - origin.y))) * tileCount.x + origin.x);
						tileMap [index].SetEditable(false);

						index = (int)((origin.y+i*((t.y - origin.y)/Math.Abs (t.y - origin.y))) * tileCount.x + (origin.x+1));
						if (index < tileMap.Length) {
							tileMap [index].SetEditable (false);
						}

						index = (int)((origin.y+i*((t.y - origin.y)/Math.Abs (t.y - origin.y))) * tileCount.x + (origin.x-1));
						if (index < tileMap.Length) {
							tileMap [index].SetEditable (false);
						}
					}
				} else if(t.y == origin.y) {
					for (int i = 0; i < Math.Abs (t.x - origin.x); ++i) {
						index = (int)(origin.y * tileCount.x + (origin.x+i*((t.x - origin.x)/Math.Abs (t.x - origin.x))));
						tileMap [index].SetEditable(false);

						index = (int)((origin.y+1) * tileCount.x + (origin.x+i*((t.x - origin.x)/Math.Abs (t.x - origin.x))));
						if (index < tileMap.Length) {
							tileMap [index].SetEditable (false);
						}
							
						index = (int)((origin.y-1) * tileCount.x + (origin.x+i*((t.x - origin.x)/Math.Abs (t.x - origin.x))));
						if (index < tileMap.Length) {
							tileMap [index].SetEditable (false);
						}
					}
				}
				origin = t;
			}
			path.Reset ();
			this.path = path;
		}


		public GridPath GetPath() {
			return path;
		}
			


		public GameObject Spawn(GameObject prefab) {
			Vector2 init = path.origin;
			MoveableEntity e = new Enemy ("", prefab);
			GameObject o = e.Spawn (init);
			GridMovementHandler handler = o.AddComponent<GridMovementHandler> ();
			handler.entity = e;
			handler.path = path.points;
			return o;
		}


		public GameObject Spawn(EnemyInfo info) {
			Vector2 init = path.origin;
			MoveableEntity e = new Enemy (info);
			GameObject o = e.Spawn (init);
			GridMovementHandler handler = o.AddComponent<GridMovementHandler> ();
			handler.entity = e;
			handler.path = path.points;
			return o;
		}

	}
}

