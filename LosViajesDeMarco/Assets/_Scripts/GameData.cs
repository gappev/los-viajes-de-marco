using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameData : MonoBehaviour 
{
	private static GameData _instance;

	private int level = -1;
	private float money = 0;
	private List<int> trivias = new List<int>();

	public static GameData instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<GameData>();
				
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}
	
	void Awake() 
	{
		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}

	public void setLevel(int level)
	{
		this.level = level;
	}

	public int getLevel ()
	{
		return this.level;
	}

	public void addMoney (float money)
	{
		this.money += money;
		PlayerPrefs.SetFloat ("Money", this.money);
		PlayerPrefs.Save ();
	} 

	public float getMoney()
	{
		money = PlayerPrefs.GetFloat ("Money");
		return money;
	}

	public void addTriviaAlreadyAnswered(int index) {
		trivias.Add (index);
	}

	public bool isAlreadyAnswered(int index) {
		for(int i=0; i<trivias.Count; i++) {
			if (trivias[i] == index) {
				return true;
			}
		}
		return false;
	}
}