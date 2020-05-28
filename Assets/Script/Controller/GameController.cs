using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyTowerDefense;

public class GameController : MonoBehaviour {


	public GameInfo game;

	private int currentLifes;

	private bool gameOver = false;

    private bool showWaveInfo = false;

    private List<UITextInfo> textInfos = new List<UITextInfo>();

	// Use this for initialization
	void Start () {
		currentLifes = game.maxLifes;
	}

	// Update is called once per frame
	void Update () {
		if (currentLifes <= 0) {
			gameOver = true;
			game.enableSpawn = false;
		}
	}


	void OnGUI() {
		LevelInfo level = game.CurrentLevel ();
		int lnum = 0;
		int wnum = 0;
        WaveInfo wave = null, wnext = null;
		if (level != null) {
			lnum = game.currentLevel + 1;
			wnum = level.currentWave + 1;
            wave = level.CurrentWave();
            wnext = level.NextWave();
		}
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.alignment = TextAnchor.MiddleCenter;

		GUI.BeginGroup(new Rect (new Vector2 (5, 10), new Vector2 (Screen.width * 0.1f, Screen.height * 0.05f)));
		GUI.Box (new Rect (new Vector2 (0, 0), new Vector2 (Screen.width * 0.1f, Screen.height * 0.05f)), "");
		GUI.Label (new Rect (new Vector2 (0, 0), new Vector2 (Screen.width * 0.1f, Screen.height * 0.05f)), string.Format("Level: {0}, Wave: {1}", lnum, wnum), style);
		GUI.EndGroup ();

        GUI.BeginGroup(new Rect(new Vector2(Screen.width * 0.1f + 5, 10), new Vector2(Screen.width * 0.1f, Screen.height * 0.3f)));
        GUI.Box(new Rect(new Vector2(0, 0), new Vector2(Screen.width * 0.1f, Screen.height * 0.05f)), "");
        if (GUI.Button(new Rect(new Vector2(0, 0), new Vector2(Screen.width * 0.1f, Screen.height * 0.05f)), "WaveInfo"))
        {
            showWaveInfo = !showWaveInfo;
        }
        if (showWaveInfo)
        {
            GUI.BeginGroup(new Rect(new Vector2(0, Screen.height * 0.05f), new Vector2(Screen.width * 0.1f, Screen.height * 0.25f)));
            GUI.Box(new Rect(new Vector2(0, 0), new Vector2(Screen.width * 0.1f, Screen.height * 0.25f)), "WaveInfo");
            GUI.Label(new Rect(new Vector2(0, 20), new Vector2(Screen.width * 0.1f, 20)), string.Format("Aktuelle Welle ({0})", wnum), style);
            GUI.Label(new Rect(new Vector2(0, 40), new Vector2(Screen.width * 0.1f, 20)), string.Format("{0} {1}", (wave != null) ? wave.amount : 0, (wave != null) ? wave.enemy.name : ""), style);
            if (wnext != null)
            {
                GUI.Label(new Rect(new Vector2(0, 60), new Vector2(Screen.width * 0.1f, 20)), string.Format("Nächste Welle ({0})", wnum + 1), style);
                GUI.Label(new Rect(new Vector2(0, 80), new Vector2(Screen.width * 0.1f, 20)), string.Format("{0} {1}", (wnext != null) ? wnext.amount : 0, (wnext != null) ? wnext.enemy.name : ""), style);
                if (GUI.Button(new Rect(new Vector2(Screen.width * 0.1f - 32, Screen.height * 0.25f - 32), new Vector2(30, 30)), "+"))
                {
                    long evalue = wnext.enemy.value - 5;
                    if (game.money > evalue)
                    {
                        game.money -= evalue;
                        wnext.amount += 1;
                    }
                }
            }
            GUI.EndGroup();
        }
        GUI.EndGroup();

        GUI.BeginGroup (new Rect (new Vector2 (Screen.width - (Screen.width * 0.15f) - 5, 10), new Vector2 (Screen.width * 0.1f, Screen.height * 0.05f)));
		GUI.Box (new Rect (new Vector2 (0, 0), new Vector2 (Screen.width * 0.1f, Screen.height * 0.05f)), "");
		GUI.Label (new Rect (new Vector2 (0, 0), new Vector2 (Screen.width * 0.1f, Screen.height * 0.05f)), string.Format("{0} G",game.money), style);
		GUI.EndGroup ();

		GUI.BeginGroup (new Rect (new Vector2 (Screen.width - (Screen.width * 0.05f) - 5, 10), new Vector2 (Screen.width * 0.05f, Screen.height * 0.05f)));
		GUI.Box (new Rect (new Vector2 (0, 0), new Vector2 (Screen.width * 0.05f, Screen.height * 0.05f)), "");
		GUI.Label (new Rect (new Vector2 (0, 0), new Vector2 (Screen.width * 0.05f, Screen.height * 0.05f)), string.Format("{0} / {1}", currentLifes, game.maxLifes), style);
		GUI.EndGroup ();

		if (gameOver) {
			GUI.BeginGroup (new Rect (new Vector2 (Screen.width / 2 - 50, Screen.height / 2), new Vector2 (100, 50)));
			GUI.Box (new Rect (new Vector2 (0, 0), new Vector2 (100, 50)), "");
			GUI.Label (new Rect (new Vector2 (0, 0), new Vector2 (100, 50)), "Game Over");
			GUI.EndGroup ();
		}

        if ( textInfos.Count > 0 )
        {
            for (int i = 0; i < textInfos.Count; ++i)
            {
                UITextInfo tInfo = textInfos[i];
                tInfo.Tick(Time.deltaTime);
                if (tInfo.HasReachedTarget())
                {
                    textInfos.Remove(tInfo);
                }
            }
        }
	}


	public void HitPlayer() {
		currentLifes = currentLifes - 1;
	}

    public void SpendMoney(long money)
    {
        if (game.SpendMoney(money))
        {
            UITextInfo tInfo = new UITextInfo("" + money, new Vector2(Screen.width - (Screen.width * 0.15f) - 5, 10), new Vector2(Screen.width - (Screen.width * 0.15f) - 5, 50));

            textInfos.Add(tInfo);
        }
    }
}
