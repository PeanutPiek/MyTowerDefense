using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTowerDefense
{
	[System.Serializable]
	public class LevelInfo
	{

		public Vector2 mapSize;

		public Vector2[] waypoints;

		public List<WaveInfo> waves;

		public float spawnTime;

		public int currentWave;

		public float delayTime;


		public LevelInfo ()
		{
			
		}


		public WaveInfo CurrentWave() {
			if (waves.Count > currentWave) {
				return waves [currentWave];
			}
			return null;
		}

        public WaveInfo NextWave()
        {
            if (waves.Count > currentWave+1)
            {
                return waves[currentWave + 1];
            }
            return null;
        }
			
	}
}

