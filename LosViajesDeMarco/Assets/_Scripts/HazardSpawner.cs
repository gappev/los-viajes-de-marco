﻿using UnityEngine;
using System.Collections;

public class HazardSpawner : MonoBehaviour {
	public Transform[] spawnPoints;

	public GameObject[] hazardPrefabs;

	public GameObject conePrefab;

	// Use this for initialization
	void Start () {
	
	}

	public void Spawn(int amount) {
		if (amount < 3) {
			for (int i = 0; i < amount; i++) {
				Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
				GameObject hazardPrefab = hazardPrefabs[Random.Range(0, hazardPrefabs.Length)];
				Instantiate(hazardPrefab, spawnPoint.position, Quaternion.identity);
			}
		}
	}

	public void SpawnPoliceCones() {
		for (int i = 0; i < 2; i++) {
			Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
			Instantiate(conePrefab, spawnPoint.position, Quaternion.identity);
		}
	}

	public void Spawn () {
		Spawn (1);
	}
}
