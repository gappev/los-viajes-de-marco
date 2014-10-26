using UnityEngine;
using System.Collections;

public class LoadTrivia : MonoBehaviour {

	public GameObject prefab;

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

	// Ewww
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

	// Use this for initialization
	void Start () {
		
		Debug.Log("level was loaded");
		var index = Random.Range (0,3);
		while (GameData.instance.isAlreadyAnswered(index)) {
			index = Random.Range (0,3);
		}
		GameData.instance.addTriviaAlreadyAnswered (index);

		var lblQuestion = transform.FindChild ("lblQuestion").GetComponent<UILabel>();
		
		lblQuestion.text = questions [index];

		for (int i = 0; i<answers[index].Length; i++) {
			
			var panel = transform.FindChild ("AnswersPanel");
			var lbl = (GameObject.Instantiate(prefab) as GameObject).GetComponent<UILabel>();
			lbl.text = answers[index][i].answer;
			lbl.transform.parent = panel;
			lbl.transform.position = new Vector2(lbl.transform.position.x, lbl.transform.position.y - i*0.1f-0.15f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
