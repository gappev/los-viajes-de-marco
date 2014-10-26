using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	public float scrollingSpeed;
	public Sprite spriteLevel1;
	public Sprite spriteLevel2;
	public Sprite spriteLevel3;

	private GameManager _gameManager;

	void Start() {
		_gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();	
		int level = GameData.instance.getLevel ();

		for (int i = 0; i < transform.childCount; i++)
		{
			Transform t = transform.GetChild(i);
			SpriteRenderer sr = t.renderer as SpriteRenderer;
			sr.sprite = level == 1 ? spriteLevel1
					   :level == 2 ? spriteLevel2
					   :spriteLevel2;
		}
		
	}

	// Update is called once per frame
	void Update () {
		if (_gameManager.isPlaying()) {
			Vector3 position = transform.position;
			float movement = _gameManager.CurrentSpeed() * Time.deltaTime;
			position.y = (position.y - movement);
			position.y = position.y % 25.6f;
			transform.position = position;
		}
	}

}
