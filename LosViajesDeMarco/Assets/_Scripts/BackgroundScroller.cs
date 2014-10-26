using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	public float scrollingSpeed;

	private GameManager _gameManager;

	void Start() {
		_gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();	
	}

	// Update is called once per frame
	void Update () {
		if (_gameManager.isPlaying()) {
			Vector3 position = transform.position;
			float movement = scrollingSpeed * Time.deltaTime;
			position.y = (position.y - movement);
			position.y = position.y % 25.6f;
			transform.position = position;
		}
	}

}
