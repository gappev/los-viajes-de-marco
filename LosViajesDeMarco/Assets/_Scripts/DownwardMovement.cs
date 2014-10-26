﻿using UnityEngine;
using System.Collections;

public class DownwardMovement : MonoBehaviour {
	private float speed = 3.0f;
	private GameManager _gameManager;

	// Use this for initialization
	void Start () {	
		_gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_gameManager.isPlaying())
			transform.Translate(-Vector2.up * _gameManager.CurrentSpeed() * Time.deltaTime);
	}
}
