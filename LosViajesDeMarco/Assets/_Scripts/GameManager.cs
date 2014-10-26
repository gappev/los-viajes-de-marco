using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public UILabel scoreLabel;

	public float maxSpeed;
	public int playerLives = 3;
	public float spawnTimeGap;

	private GameConstants.GameStates _state = GameConstants.GameStates.Playing;
	private HazardSpawner _hazardSpawner;


	private float _currentSpeed = 8.0f;
	private float _nextSpawn;
	private float _traveledDistance = 0;

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
		if (_state == GameConstants.GameStates.Playing) {

			_traveledDistance += _currentSpeed * Time.deltaTime;
			
			UpdateUi();

			int amount = Time.timeSinceLevelLoad < 30.0f ? 1 : 2;

			if (Time.timeSinceLevelLoad >= _nextSpawn) {
				_hazardSpawner.Spawn(amount);
				_nextSpawn = Time.timeSinceLevelLoad + spawnTimeGap;
			}

			if (Time.timeSinceLevelLoad >= 0 && Time.timeSinceLevelLoad <= 15) {
				_currentSpeed += 0.3f * Time.deltaTime;
				spawnTimeGap -= 0.05f * Time.deltaTime;
			} else if (Time.timeSinceLevelLoad >= 15 && Time.timeSinceLevelLoad <= 30) {
				_currentSpeed += 0.2f * Time.deltaTime;
				spawnTimeGap -= 0.03f * Time.deltaTime;
			} else {
				_currentSpeed += 0.15f * Time.deltaTime;
				spawnTimeGap -= 0.02f * Time.deltaTime;
			}

			_currentSpeed = Mathf.Clamp(_currentSpeed, 0.0f, maxSpeed);
			spawnTimeGap = Mathf.Clamp(spawnTimeGap, 1.0f, 3.0f);
		}
	}

	public float CurrentSpeed() {
		return _currentSpeed;
	}

	private void UpdateUi() {
		scoreLabel.text = ((int)_traveledDistance).ToString();
	}

	private void OnPlayerHazardCollision() {
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
