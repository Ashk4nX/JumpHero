﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	public void PlayTheGame ()
	{

		SceneManager.LoadScene("Game01");

	}

	public void QuitTheGame ()
	{

		Application.Quit ();
		Debug.Log ("QUIT");

	}

}
