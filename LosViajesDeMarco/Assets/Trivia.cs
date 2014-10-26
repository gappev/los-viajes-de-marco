using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class Trivia : MonoBehaviour {

	public AudioClip wrongClip;
	public AudioClip rightClip;

	void Start() {
		Messenger.AddListener<bool>(GameConstants.GameEvents.TRIGGER_POLICE, OnTriggerPolice);
		Messenger.AddListener<int>(GameConstants.GameEvents.ANSWER_CLICK, OnAnswerClick);
	}

	void OnDestroy() {
		Messenger.RemoveListener<bool>(GameConstants.GameEvents.TRIGGER_POLICE, OnTriggerPolice);
		Messenger.RemoveListener<int>(GameConstants.GameEvents.ANSWER_CLICK, OnAnswerClick);
	}

	void OnTriggerPolice(bool trigger) {
		if (trigger)
			Invoke("Trigger", 1.0f);
		else
			Time.timeScale = 1;
	}

	private int questionIndex;

	void OnTweenComplete() {
		Time.timeScale = 0;
	}

	public void Trigger() {
		HOTween.To(transform, 0.5f, new TweenParms().Prop("position",Vector3.zero).Ease(EaseType.EaseOutBounce).OnComplete(OnTweenComplete));
		questionIndex = Random.Range(0, questions.Length);
		string question = questions[questionIndex].ToUpper();
		Answer[] questionAnswers = answers[questionIndex];

		UILabel questionLabel = transform.FindChild("Question").GetComponent<UILabel>();
		questionLabel.text = question;

		Debug.Log(question);

		for (int i =0; i < questionAnswers.Length ; i++) {
			Transform questionChild = transform.Find("Answer" + (i+1));
			Debug.Log(questionAnswers[i].answer);
			questionChild.GetComponent<UILabel>().text = questionAnswers[i].answer.ToUpper();
		}
	}

	string[] questions = 
	{
		"Tela gano fama como\npuerto de bananas, pero\nahora exporta tambien: ", 
		"Tela se considera\nconsta de las playas\npremium de Honduras\njunto con:",
		"Tela fue una vez\nsede de la siguiente\nempresa:",
		"Tela cuenta con\ncampos de golf"	
	};
	
	class Answer
	{
		public bool correct	 { get; set;}
		public string answer {get; set;}
	}
	
	//Hardcode
	Answer[][] answers = 
	{			
		new Answer[]{
			new Answer{correct=true, answer="Coco y\nfrutas citricas"},
			new Answer{correct=false, answer="Mango"},
			new Answer{correct=false, answer="Cacao"}
		},
		new Answer[]{
			new Answer{correct=true, answer="Trujillo"},
			new Answer{correct=false, answer="Roatan"},
			new Answer{correct=false, answer="La Ceiba"}
		},
		new Answer[]{
			new Answer{correct=true, answer="United Fruit"},
			new Answer{correct=false, answer="Fruit of the Loom"},
			new Answer{correct=false, answer="Hanes"}
		},
		new Answer[]{
			new Answer{correct=true, answer="Si"},
			new Answer{correct=false, answer="No"}
		}
	};

	public void OnAnswerClick(int index) {
		Debug.Log("Answer clicked: " + index);
		Answer answer = answers[questionIndex][index];
		if ( answer.correct) {
			AudioSource.PlayClipAtPoint(rightClip, transform.position);
			GameData.instance.addMoney(50.0f);
		} else {
			AudioSource.PlayClipAtPoint(wrongClip, transform.position);
		}

		for (int i =0; i < 4 ; i++) {
			Transform questionChild = transform.Find("Answer" + (i+1));
			questionChild.GetComponent<UILabel>().text = "";
		}

		transform.position = new Vector3(1700, 0);
		Time.timeScale = 1;
	}
}
