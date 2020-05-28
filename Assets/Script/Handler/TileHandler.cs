using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyTowerDefense;

public class TileHandler : MonoBehaviour {

	public GridTile tile;

	bool isSelected;

	GameController game;

	// Use this for initialization
	void Start () {
		isSelected = false;
		game = GameObject.Find ("Game").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isSelected) {
			this.gameObject.GetComponent<SpriteRenderer> ().color = (tile != null ) ? ((tile.editable) ? Color.yellow : Color.grey) : Color.black;
		} else {
			this.gameObject.GetComponent<SpriteRenderer> ().color = (tile.editable) ? Color.white : Color.gray;
		}
	}

	void OnGUI() {
		if (isSelected && tile != null && tile.build != null) {
			int width = 170;
			int height = 200;
			int name_width = 100;
			int name_height = 20;

			List<string> effects = new List<string>();
			foreach (EffectCast e in tile.build.attack.effects) {
				effects.Add(e.name);
			}
			string effectsString = string.Join(",", effects.ToArray());

			GUIStyle style = null;

			Vector2 point = Camera.main.WorldToScreenPoint (gameObject.transform.position);
			GUI.BeginGroup (new Rect (new Vector2 (point.x, Screen.height - point.y - height/2), new Vector2 (width, height)));
			GUI.Box (new Rect (new Vector2 (0, 0), new Vector2 (width, height)), "");
			style = new GUIStyle(GUI.skin.label);
			style.alignment = TextAnchor.MiddleCenter;
			GUI.Label (new Rect (new Vector2 (width / 2 - name_width / 2, 0), new Vector2 (name_width, name_height)), tile.build.name, style);
			GUI.Label (new Rect (new Vector2 (width / 2 - name_width / 2, name_height + 5), new Vector2 (name_width, name_height)), string.Format("Level: {0}", tile.build.level), style);
			GUI.Label (new Rect (new Vector2 (2, 2 * name_height), new Vector2 (width - 4, height / 2)), string.Format ("Schaden\t\t{0}\n\rTempo\t\t{1}\n\rReichweite\t\t{2}", tile.build.attack.damage, tile.build.attack.speed, tile.build.attack.range));
			if (effects.Count > 0) {
				GUI.Label (new Rect (new Vector2 (2, 4 * name_height), new Vector2 (width - 4, height / 2)), string.Format ("Effekte\n\r{0}", effectsString));
			}

			if (GUI.Button (new Rect (new Vector2 (width - 30, 5), new Vector2 (25, 25)), "U")) {
				if (game.game.money >= tile.build.cost) {
					game.game.money -= tile.build.cost;
					tile.build.LevelUp ();
				}
			}
			if (GUI.Button (new Rect (new Vector2 (5, 5), new Vector2 (25, 25)), "$")) {
				float refund = tile.build.cost / 2;
				tile.Clear ();
				game.game.money = (long)(game.game.money + refund);
				ValueMarker marker = new ValueMarker (gameObject, refund + "", 2f, Color.green);
				marker.Spawn (gameObject.transform.position, null);
			}
			GUI.EndGroup ();
		}
	}

	void OnMouseDown() {
		isSelected = !isSelected;
		foreach(GameObject o in GameObject.FindGameObjectsWithTag("GridTile")) {
			if (o != this.gameObject) {
				o.GetComponent<TileHandler> ().isSelected = false;
			}
		}
		if (isSelected) {
			Camera.main.GetComponent<GUIController> ().selectedTile = this.tile;
		} else {
			Camera.main.GetComponent<GUIController> ().selectedTile = null;
		}
		Debug.Log (string.Format("IsSelected: {0}, isEditable: {1}", isSelected, tile.editable));
	}
}
