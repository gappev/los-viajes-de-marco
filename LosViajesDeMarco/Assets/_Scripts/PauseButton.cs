using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseButton : MonoBehaviour {
	public UI2DSprite pauseMessage;

    private bool paused;
	// Use this for initialization
	void Start () {
        paused = false;
		Messenger.AddListener(GameConstants.GameEvents.GAME_OVER, OnGameOver);
	}

	void OnDestroy() {
		Messenger.RemoveListener(GameConstants.GameEvents.GAME_OVER, OnGameOver);
	}

    void OnClick()
    {
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;

    }

	void updateUi() {		
		pauseMessage.gameObject.SetActive(paused);
	}

	void OnGameOver()
	{
		gameObject.SetActive(false);
	}
	
}
