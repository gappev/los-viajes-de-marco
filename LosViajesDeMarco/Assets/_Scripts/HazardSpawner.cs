using UnityEngine;
using System.Collections;

public class HazardSpawner : MonoBehaviour {
	public Transform[] spawnPoints;

	public GameObject[] hazardPrefabs;

	// Use this for initialization
	void Start () {
	
	}

	public void Spawn () {
		Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
		GameObject hazardPrefab = hazardPrefabs[Random.Range(0, hazardPrefabs.Length)];

		Instantiate(hazardPrefab, spawnPoint.position, Quaternion.identity);
	}
}
