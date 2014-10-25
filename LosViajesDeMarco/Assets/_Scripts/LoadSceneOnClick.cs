using UnityEngine;
using System.Collections;

public class LoadSceneOnClick : MonoBehaviour {
	public string sceneToLoad;

	void OnClick() {
		Application.LoadLevel(sceneToLoad);
	}
}
