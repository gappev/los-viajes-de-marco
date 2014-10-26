using UnityEngine;
using System.Collections;

public class DissapearOnPause : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Messenger.AddListener<bool>(GameConstants.GameEvents.GAME_PAUSE,OnGamePause);
	}
	
	void OnGamePause(bool pause) {
		gameObject.SetActive(!pause);
	}

	void OnDestroy() {
		Messenger.RemoveListener<bool>(GameConstants.GameEvents.GAME_PAUSE, OnGamePause);
	}
}
