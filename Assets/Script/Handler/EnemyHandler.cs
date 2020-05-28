using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyTowerDefense;

public class EnemyHandler : MonoBehaviour {

	const float IS_REACHED = 0.1f;

	public Enemy entity;


	public bool showLP = true;

	private GridMovementHandler mHandler;

	private GameController game;

	// Use this for initialization
	void Start () {
		mHandler = gameObject.GetComponent<GridMovementHandler> ();
		game = GameObject.Find ("Game").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnGUI() {
		if (showLP) {
			Vector2 sp = Camera.main.WorldToScreenPoint (gameObject.transform.position);
			int sx = (int)(sp.x - 20);
			int y = (int)(Screen.height - sp.y - 20);
			int w = 40;
			int h = 5;
			float lp = entity.GetCurrentLifepoints () / entity.GetLifepoints ();
			GUIStyle style = new GUIStyle (GUI.skin.box);

			GUI.backgroundColor = Color.black;
			style.normal.background = Texture2D.blackTexture;
			style.normal.textColor = Color.black;

			GUI.Box (new Rect (new Vector2 (sx, y), new Vector2 (w, h)), "", style);

			style = new GUIStyle (GUI.skin.box);

			Texture2D tex = Texture2D.whiteTexture;
			for(int j = 0; j < tex.height; ++j) {
				for (int i = 0; i < tex.width; ++i) {
					tex.SetPixel(i, j, Color.red);
				}
			}
			style.normal.background = tex;
			style.normal.textColor = Color.black;
			GUI.backgroundColor = Color.red;
			GUI.Box (new Rect (new Vector2 (sx, y), new Vector2 ((int)(w * lp), h)), string.Format("{0}/{1}", entity.GetCurrentLifepoints(), entity.GetLifepoints()), style);
		}
	}


	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag ("Shot")) {
			BulletHandler handler = coll.gameObject.GetComponent<BulletHandler> ();
			entity.Hit (handler.tower.GetAttackInfo());
			if (entity.isDead ()) {
				handler.tower.killCount += 1;
				game.game.money += entity.GetEntityValue ();
				ValueMarker marker = new ValueMarker (gameObject, entity.GetEntityValue() + "", 2f, Color.yellow);
				GameObject valueMarker = marker.Spawn (gameObject.transform.position, null);
				Destroy (gameObject);
			}
		}
	}
}
