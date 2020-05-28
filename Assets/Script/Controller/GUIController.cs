using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyTowerDefense;

public class GUIController : MonoBehaviour {

	public GridTile selectedTile;

	public List<TowerInfo> towerInfo;

	private GameController game;

	// Use this for initialization
	void Start () {
		game = GameObject.Find ("Game").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() {
		if (selectedTile != null && selectedTile.editable) {
			GUI.BeginGroup (new Rect (new Vector2 (0, Screen.height - 150), new Vector2 (Screen.width, 150)));
			if (!selectedTile.HasBuild ()) {
				GUI.Box (new Rect (new Vector2 (0, 0), new Vector2 (Screen.width, 150)), "");
				for (int i = 0; i < towerInfo.Count; ++i) {
					if (GUI.Button (new Rect (new Vector2 (25 * (i + 1) + 100 * i, 25), new Vector2 (100, 100)), string.Format ("{0}\n\r{1} G", towerInfo [i].name, towerInfo [i].cost))) {
						if (game.game.money >= towerInfo [i].cost) {
							selectedTile.Build (towerInfo [i]);
							game.game.money -= towerInfo [i].cost;
						}
					}
				}
				if (GUI.Button (new Rect (new Vector2 (Screen.width - 75, 25), new Vector2 (50, 50)), "")) {
					if (selectedTile.HasBuild ()) {
						selectedTile.Clear ();
					}
				}
			}
			GUI.EndGroup ();
		}
	}
}
