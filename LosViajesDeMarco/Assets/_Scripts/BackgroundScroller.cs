using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	public float scrollingSpeed;

	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		float movement = scrollingSpeed * Time.deltaTime;
		position.y = (position.y - movement);
		position.y = position.y % 14;
		transform.position = position;
	}
}
