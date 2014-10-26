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
			Trigger();
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

		int i = 1;
		for (; i <= questionAnswers.Length ; i++) {
			Transform questionChild = transform.Find("Answer" + i);
			Debug.Log(questionAnswers[i -1].answer);
			questionChild.GetComponent<UILabel>().text = questionAnswers[i -1].answer.ToUpper();
		}
	}

	string[] questions = 
	{
		"Fue el jade más cotizado que el\noro para el desarrollo del arte maya?",
		"No es uno de los primeros dioses\ncreadores de la civilización mayas",
		"Fue de las civilizaciones más\ndominantes de las sociedades\nindígenas de Mesoamérica",
		"Tenían los mayas libros?"
	};
	
	class Answer
	{
		public bool correct { get; set;}
		public string answer {get; set;}
	}
	
	//Hardcode
	Answer[][] answers = 
	{
		new Answer[]{
			new Answer{correct=true, answer="Si"},
			new Answer{correct=false, answer="No"}
		},
		new Answer[]{
			new Answer{correct=false, answer="Del viento"},
			new Answer{correct=false, answer="De la tormenta"},
			new Answer{correct=false, answer="Del fuego"},
			new Answer{correct=true, answer="Del sol"}
		},
		new Answer[]{
			new Answer{correct=false, answer="Azteca"},
			new Answer{correct=true, answer="Maya"},
			new Answer{correct=false, answer="Inca"},
			new Answer{correct=false, answer="Olmeca"}
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

		transform.position = new Vector3(1700, 0);
		Time.timeScale = 1;
	}
}
