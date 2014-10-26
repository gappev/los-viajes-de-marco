using UnityEngine;
using System.Collections;

public class AnswerClick : MonoBehaviour {

	public int index;
	void OnClick() {
		Messenger.Broadcast<int>(GameConstants.GameEvents.ANSWER_CLICK, index);
		Messenger.Broadcast<bool>(GameConstants.GameEvents.TRIGGER_POLICE, false);
	}
}
