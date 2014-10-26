using UnityEngine;
using System.Collections;

public class PoliceCar : MonoBehaviour {

	public Transform target;
	public Transform returnTarget;
	public float speed; 


	private bool _triggered;

	void Start() {
		Messenger.AddListener<bool>(GameConstants.GameEvents.TRIGGER_POLICE, OnTriggerPolice);
	}

	void Update() {
		if (_triggered) {
			audio.enabled = true;
			transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
		} else {
			audio.enabled = false;
			transform.position = Vector3.Lerp(transform.position, returnTarget.position, speed * Time.deltaTime);
		}
	}

	void OnTriggerPolice(bool triggered) {
		_triggered = triggered;	
	}
}
