using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class GameOverUi : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Messenger.AddListener(GameConstants.GameEvents.GAME_OVER, OnGameOver);
	}

	void OnGameOver() {
		HOTween.To(transform, 0.5f, new TweenParms().Ease(EaseType.EaseInBounce).Prop("position", Vector3.zero));
	}
}
