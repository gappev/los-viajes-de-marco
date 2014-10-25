using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	public float scrollingSpeed;

	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		float movement = scrollingSpeed * Time.deltaTime;
		//transform.Translate(-Vector2.up * scrollingSpeed * Time.deltaTime);
		position.y = (position.y - movement);

		if ( position.y < -14.0f)
			position.y = 0.0f;

		transform.position = position;

		Debug.Log(position);
	}
}
