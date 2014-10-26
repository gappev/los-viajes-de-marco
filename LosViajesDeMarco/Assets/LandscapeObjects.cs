using UnityEngine;
using System.Collections;

public class LandscapeObjects : MonoBehaviour {

	public Sprite palm;
	public Sprite estela;
	public Sprite pine;
	public Sprite fabric;

	// Use this for initialization
	void Start () {
		var level = GameData.instance.getLevel();

		// Background 
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform t = transform.GetChild(i);
			SpriteRenderer sr = t.renderer as SpriteRenderer;
			sr.sprite = level == 1 ? palm
						:level == 2 ? fabric
						:level == 3 ? pine
						:estela;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
