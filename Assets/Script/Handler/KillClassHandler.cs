using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyTowerDefense;

public class KillClassHandler : MonoBehaviour {

	private TowerHandler tower;

	private KillClass[] classes = new KillClass[] { new KillClass("Rekrut", 0), new KillClass("Veteran", 100), new KillClass("Elite", 500) };

	private KillClass towerClass;

	private long[] killMap;

	private int currentClass;

	// Use this for initialization
	void Start () {
		tower = gameObject.GetComponent<TowerHandler> ();
		currentClass = 0;
		killMap = new long[classes.Length];
		for (int i = 0; i < classes.Length; ++i) {
			killMap [i] = classes [i].required;
		}
	}
	
	// Update is called once per frame
	void Update () {
		towerClass = classes [currentClass];
		if (tower.entity.killCount > killMap [currentClass + 1]) {
			towerClass = classes [currentClass++];
		}
	}
}
