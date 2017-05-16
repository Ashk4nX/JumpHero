using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	public static GameOverManager Instance;

	private GameObject GameOverPanel;
	private Animator GameOverPanelAnim;

	private Button BackBtn, RestartBtn;
	private Text FinalScore;
	private GameObject ScoreText;


	void Awake ()
	{
		MakeInstance ();
		InitializeVariables ();
	}



	void MakeInstance ()
	{

		if (Instance == null) {

			Instance = this;

		}

	}


	void InitializeVariables ()
	{

		GameOverPanel = GameObject.Find ("Game Over Panel Handler");
		GameOverPanelAnim = GameOverPanel.GetComponent<Animator>();

		BackBtn = GameObject.Find ("BackBtn").GetComponent<Button>();
		RestartBtn = GameObject.Find ("RestartBtn").GetComponent<Button>();
		FinalScore = GameObject.Find("FinalScore").GetComponent<Text>();
		ScoreText = GameObject.Find ("Score");

		GameOverPanel.SetActive (false);

		BackBtn.onClick.AddListener (() => ReturnToHome ());
		RestartBtn.onClick.AddListener (() => PlayAgain ());

	}

	public void ShowGameOverPanel ()
	{

		ScoreText.SetActive(false);
		GameOverPanel.SetActive (true);
		GameOverPanelAnim.Play ("FadeIn");

		FinalScore.text = ScoreManager.Instance.GetScore ().ToString();

	}

	public void PlayAgain ()
	{

		SceneManager.LoadScene("Game01");

	}

	public void ReturnToHome ()
	{

		SceneManager.LoadScene("MainMenu");

	}


}
