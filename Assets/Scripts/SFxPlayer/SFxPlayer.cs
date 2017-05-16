using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFxPlayer : MonoBehaviour {

	public static SFxPlayer Instance;

	private AudioSource myAudio;


	void Awake ()
	{

		MakeInstance ();
		myAudio = gameObject.GetComponent<AudioSource>();

	}

	void MakeInstance ()
	{

		if (Instance == null) {

			Instance = this;

		}

	}

	public void PlaySound ()
	{

		myAudio.Play();


	}


}
