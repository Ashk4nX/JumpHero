using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJumpScript : MonoBehaviour {

	public static PlayerJumpScript Instance;

	private Rigidbody2D MyRigidBody;
	private Animator anim;
	private Slider PowerBar;

	[SerializeField]
	private float ForceX, ForceY;

	private float ThresholdX = 7f;
	private float ThresholdY = 14f;
	private float PowerBarThreshold = 10f;
	private float PowerBarValue = 0f;

	private bool setPower, didJump;


	void Awake ()
	{

		MakeInstance ();
		Initialize ();

	}

	void Initialize ()
	{

		MyRigidBody = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		PowerBar = GameObject.Find("Slider").GetComponent<Slider>();

		PowerBar.minValue = 0f;
		PowerBar.maxValue = 10f;
		PowerBar.value = PowerBarValue;

	}


	void MakeInstance ()
	{

		if (Instance == null) {

			Instance = this;

		}

	}


	void Update ()
	{

		SetPower ();

	}

	void SetPower ()
	{

		if (setPower) {

			ForceX += ThresholdX * Time.deltaTime;
			ForceY += ThresholdY * Time.deltaTime;

			if (ForceX > 6.5f) {

				ForceX = 6.5f;
			}

			if (ForceY > 13.5f) {
		
				ForceY = 13.5f;
			}

			PowerBarValue += PowerBarThreshold * Time.deltaTime;
			PowerBar.value = PowerBarValue;

		}

	}

	void Jump ()
	{

		MyRigidBody.velocity = new Vector2(ForceX, ForceY);
		ForceX = ForceY = PowerBarValue = 0f;
		didJump = true;
		anim.SetBool ("Jump", didJump);
		PowerBar.value = PowerBarValue;

	}

	public void SetPower (bool setPower)
	{

		this.setPower = setPower;

		if (setPower) {

			Debug.Log ("We are setting the power");

		} else {

			Jump ();


		}

	}

	void OnTriggerEnter2D (Collider2D target)
	{

		if (didJump) {

			didJump = false;

			anim.SetBool ("Jump", didJump);

			if (target.tag == "Platform") {

				if (GameManager.Instance != null) {

					GameManager.Instance.CreateNewPlatformAndLerp (target.transform.position.x);

				}

				if (ScoreManager.Instance != null) {

					ScoreManager.Instance.IncrementScore ();

				}

				if (SFxPlayer.Instance != null) {

					SFxPlayer.Instance.PlaySound ();

				}

			}


		}

		if (target.tag == "DeadZone") {

			if (GameOverManager.Instance != null) {

				GameOverManager.Instance.ShowGameOverPanel ();

			}

		}

	}

}
