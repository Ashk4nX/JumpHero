using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	[SerializeField]
	private GameObject Player;

	[SerializeField]
	private GameObject Platform;

	private float minX = -2.4f, maxX = 2.4f, minY = -4.8f, maxY= -3.8f;

	private bool LerpCamera;
	private float LerpTime = 1.5f;
	private float LerpX;


	void Awake ()
	{

		MakeInstance ();
		CreateInitialPlatforms ();
	}


	void MakeInstance ()
	{

		if (Instance == null) {

			Instance = this;

		}

	}

	void Update ()
	{

		if (LerpCamera) {

			LerpTheCamera ();

		}

	}

	void CreateInitialPlatforms ()
	{

		Vector2 temp = new Vector2 (Random.Range(minX, minX + 1f), (Random.Range(minY, maxY)));

		Instantiate (Platform, temp, Quaternion.identity);

		temp.y += 2f;

		Instantiate (Player, temp, Quaternion.identity);

		temp = new Vector2 (Random.Range(maxX, maxX - 1f), (Random.Range(minY, maxY)));

		Instantiate (Platform, temp, Quaternion.identity);

	} //CreateInitialPlatforms


	void CreateNewPlatforms ()
	{

		float CameraX = Camera.main.transform.position.x;
		float newMaxX = (maxX * 2) + CameraX;

		Instantiate (Platform, new Vector2 (Random.Range (newMaxX, newMaxX - 1.2f), Random.Range(minY, maxY)), Quaternion.identity);	

	}

	public void CreateNewPlatformAndLerp (float LerpPosition)
	{

		CreateNewPlatforms ();

		LerpX = LerpPosition + maxX;
		LerpCamera = true;

	}

	void LerpTheCamera ()
	{

		float x = Camera.main.transform.position.x;

		x = Mathf.Lerp(x, LerpX, LerpTime * Time.deltaTime);

		Camera.main.transform.position = new Vector3 (x, Camera.main.transform.position.y, Camera.main.transform.position.z);

		if (Camera.main.transform.position.x >= (LerpX - 0.07f)){

			LerpCamera = false;

		}

	}


} //GameManager



























