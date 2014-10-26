using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == GameConstants.Tags.HAZARD) {
			Destroy(other.gameObject);
		}
	}
}
