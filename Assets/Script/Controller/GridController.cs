using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using MyTowerDefense;

public class GridController : MonoBehaviour {

	public GameObject tilePrefab;

	private MyTowerDefense.Grid grid;

	private GameInfo game;

	private float finished = 0f;

	private float lastSpawn = 0f;

	private int amountSpawned = 0;

	// Use this for initialization
	void Start () {
		game = GameObject.Find ("Game").GetComponent<GameController> ().game;
		LevelInfo level = game.CurrentLevel ();
		if (level != null) {
			grid = new MyTowerDefense.Grid (this.gameObject, level.mapSize, tilePrefab);
			Vector2 position = new Vector2 ((int)(this.gameObject.transform.position.x - level.mapSize.x/2), (int)(this.gameObject.transform.position.y - level.mapSize.y/2));
			this.gameObject.transform.position = position;
			grid.SetPath (new GridPath (level.waypoints));
		}
	}
	
	// Update is called once per frame
	void Update () {
		LevelInfo level = game.CurrentLevel ();
		if (game.enableSpawn && level != null && Time.time >= lastSpawn + level.spawnTime && Time.time >= finished + game.CurrentLevel().delayTime) {
			WaveInfo wave = level.CurrentWave ();
			if (wave.amount > amountSpawned) {
				GameObject go = grid.Spawn (wave.enemy);


				amountSpawned++;
				lastSpawn = Time.time;
			} else {
				GameObject[] left = GameObject.FindGameObjectsWithTag ("Enemy");
				if (left == null || left.Length == 0) {
					game.WaveFinish ();
					amountSpawned = 0;
					finished = Time.time;
				}
			}
		}
	}
}
