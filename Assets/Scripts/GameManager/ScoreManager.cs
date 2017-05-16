using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager Instance;

	private Text ScoreText;
	private int ScoreValue;

	void Awake ()
	{

		ScoreText = GameObject.Find ("Score").GetComponent<Text>();
		MakeInstance ();

	}

	void MakeInstance ()
	{
		if (Instance == null) {

			Instance = this;

		}

	}

	public void IncrementScore ()
	{

		ScoreValue = ScoreValue + 10;
		ScoreText.text = ScoreValue.ToString();

	}

	public int GetScore ()
	{

		return this.ScoreValue;

	}


}
