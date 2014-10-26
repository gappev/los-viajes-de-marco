using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public AudioClip ouchSound;
	public AudioClip potHoleSound;

	public Transform leftLane;
	public Transform middleLane;
	public Transform rightLane;

	private Animator anim;

	private Transform _currentLane;

	void Start() {
		anim = GetComponent<Animator>();
		_currentLane = middleLane;

		Messenger.AddListener(GameConstants.GameEvents.GAME_OVER, OnGameOver);
	}

	void OnGameOver() {
		anim.SetBool("Game Over", true);
	}

	public void MoveLeft() {
		if (_currentLane != leftLane) {

			if (_currentLane == rightLane) {
				_currentLane = middleLane;
			} else if (_currentLane == middleLane) {
				_currentLane = leftLane;
			}

			transform.position = _currentLane.position;
		}
	}

	public void MoveRight() {
		if (_currentLane != rightLane) {

			if (_currentLane == leftLane) {
				_currentLane = middleLane;
			} else if (_currentLane == middleLane) {
				_currentLane = rightLane;
			}

			transform.position = _currentLane.position;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == GameConstants.Tags.HAZARD) {
			//Destroy(other.gameObject);
			
			AudioSource.PlayClipAtPoint(potHoleSound, transform.position, 0.4f);
			audio.Play();
			Messenger.Broadcast(GameConstants.GameEvents.PLAYER_COLLISION_HAZARD);
		} else if (other.tag == GameConstants.Tags.POLICE_CONE) {
			Messenger.Broadcast<bool>(GameConstants.GameEvents.TRIGGER_POLICE, true);
		}
	}

}
