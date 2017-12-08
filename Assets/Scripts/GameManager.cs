using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField] public float GAME_TIMER = 30.0f;
	private float GAMEOVER_TIMER = 5.0f;
	[SerializeField] public bool playing = false;
	private bool gameoverShow = false;
	[SerializeField] public Text start;
	[SerializeField] public Text gameOver;

	private float gameTimeLeft;
	private float gameoverTimerLeft;

	// Use this for initialization
	void Start () {
		gameTimeLeft = GAME_TIMER;
		start.text = "PRESS ANY BUTTON TO START";
		gameOver.text = "GAME OVER";
	}
	
	// Update is called once per frame
	void Update () {
		if (playing) {
			start.canvasRenderer.SetAlpha (0);
			gameTimeLeft -= Time.deltaTime;
			if (gameTimeLeft < 0) {
				stopPlaying ();
			}
		} else {
			if (!gameoverShow) {
				start.canvasRenderer.SetAlpha (1);
				if (Input.anyKey) {
					startPlaying ();
				}
			}
		}

		if (gameoverShow) {
			gameOver.canvasRenderer.SetAlpha (1);
			gameoverTimerLeft -= Time.deltaTime;
			if (gameoverTimerLeft < 0) {
				gameoverShow = false;
			}
		} else {
			gameOver.canvasRenderer.SetAlpha (0);
		}
	}

	void stopPlaying() {
		playing = false;
		gameTimeLeft = GAME_TIMER;
		gameoverShow = true;
	}

	void startPlaying() {
		playing = true;
		gameoverTimerLeft = GAMEOVER_TIMER;
		gameoverShow = false;
	}
}
