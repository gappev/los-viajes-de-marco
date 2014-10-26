using UnityEngine;
using System.Collections;

public class TriviaBackgroundSelector : MonoBehaviour {

	public Sprite level1Background;
	public Sprite level2Background;
	public Sprite level3Background;
	public Sprite defaultBackground;

	// Use this for initialization
	void Start () {
		var level = GameData.instance.getLevel();

		var sr = GetComponent<UISprite>();
		sr.spriteName = level == 1 ? level1Background.name
						:level == 2 ? level2Background.name
						:level == 3 ? level3Background.name
						:defaultBackground.name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
