using UnityEngine;
using System.Collections;

public class LoadSceneOnClick : MonoBehaviour {
	public string sceneToLoad;

	void OnClick() {
		Debug.Log ("_**_");
		Application.LoadLevel(sceneToLoad);
	}
}
