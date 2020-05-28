using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyTowerDefense;

namespace MyTowerDefense {
	[System.Serializable]
	public class GameInfo {


		public bool enableSpawn;

		public List<LevelInfo> levels;

		public int currentLevel;

		public int maxLifes;

		public long money = 0;


		public GameInfo() {
			levels = new List<LevelInfo> ();
		}


		public LevelInfo CurrentLevel() {
			if (levels.Count > currentLevel) {
				return levels [currentLevel];
			}
			return null;
		}


		public void WaveFinish() {
			CurrentLevel ().currentWave += 1;
			money += 100;
			if (CurrentLevel ().CurrentWave () == null) {
				LevelFinish ();
			}
		}

		public void LevelFinish() {
			money += 150;
			if (levels.Count > currentLevel) {
				currentLevel += 1;
			} else {
				// Win
				enableSpawn = false;
			}
		}

        public bool SpendMoney(long m)
        {
            if ( m > money )
            {
                return false;
            }
            money -= m;
            return true;
        }

	}
}