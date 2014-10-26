using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public int playerLives = 3;
	public float spawnTimeGap;

	private GameConstants.GameStates _state = GameConstants.GameStates.Playing;
	private HazardSpawner _hazardSpawner;

	private float _nextSpawn;
	// Use this for initialization
	void Start () {
		_hazardSpawner = GameObject.Find("Hazard Spawner").GetComponent<HazardSpawner>();
		_nextSpawn = Time.timeSinceLevelLoad;

		Messenger.AddListener(GameConstants.GameEvents.PLAYER_COLLISION_HAZARD, OnPlayerHazardCollision);
	}

	void OnDestroy() {
		Messenger.RemoveListener(GameConstants.GameEvents.PLAYER_COLLISION_HAZARD, OnPlayerHazardCollision);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad >= _nextSpawn && _state == GameConstants.GameStates.Playing) {
			_hazardSpawner.Spawn();
			_nextSpawn = Time.timeSinceLevelLoad + spawnTimeGap;
		}
	}


	void OnPlayerHazardCollision() {
		playerLives--;

		if (playerLives == 0) {
			_state = GameConstants.GameStates.GameOver;
			//Messenger.Broadcast(GameConstants.GameEvents.GAME_OVER);
		}
	}

	public bool isPlaying() {
		return _state == GameConstants.GameStates.Playing;
	}
}
