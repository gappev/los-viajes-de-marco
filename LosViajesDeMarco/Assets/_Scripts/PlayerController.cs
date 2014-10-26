using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float laneSwitchSpeed;

	public Transform leftLane;
	public Transform middleLane;
	public Transform rightLane;

	private Animator anim;

	private Transform _currentLane;

	void Start() {
		anim = GetComponent<Animator>();
		_currentLane = middleLane;
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
			transform.Translate(Vector2.right * laneSwitchSpeed * Time.deltaTime);

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
			anim.SetBool("Game Over", true);
			Messenger.Broadcast(GameConstants.GameEvents.PLAYER_COLLISION_HAZARD);
		}
	}
}
