using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public static MusicManager Instance;

	void Awake () {

		if (Instance != null){

			Destroy (gameObject);
			print ("Added Music Player Destroyed!");

		} else {

			Instance = this;;
			GameObject.DontDestroyOnLoad(gameObject);

		}

	}
}
