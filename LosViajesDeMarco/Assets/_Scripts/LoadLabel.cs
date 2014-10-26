using UnityEngine;
using System.Collections;

public class LoadLabel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UILabel label = GetComponent<UILabel> ();
		string str = "L. " + GameData.instance.getMoney ();
		label.text = str;
		Debug.Log (str);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
