using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class CloseDLC : MonoBehaviour {

	public void OnClick()
	{
		Debug.Log("Llego aqui");
		HOTween.To(transform, 0.5f, new TweenParms().Prop("position", new Vector3(500,0,0)).Ease(EaseType.EaseInBounce));
	}
	
}
