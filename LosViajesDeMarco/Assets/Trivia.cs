using UnityEngine;
using System.Collections;

public class Trivia : MonoBehaviour {

	public void Trigger() {
		int questionIndex = Random.Range(0, questions.Length);
		string question = questions[questionIndex];
		//Answer[] questionAnswers = Answer[questionIndex];


		/*var lbl = (GameObject.Instantiate(prefab) as GameObject).GetComponent<UILabel>();
		lbl.text = answers[index][i].answer;
		//lbl.transform.parent = panel;
		lbl.transform.position = new Vector2(lbl.transform.position.x, lbl.transform.position.y - i*0.1f-0.15f);
*/
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
}
