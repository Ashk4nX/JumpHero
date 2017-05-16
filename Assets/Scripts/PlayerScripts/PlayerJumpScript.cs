using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpScript : MonoBehaviour {

	public static PlayerJumpScript Instance;

	private Rigidbody2D MyRigidBody;
	private Animator anim;

	[SerializeField]
	private float ForceX, ForceY;

	private float ThresholdX = 7f;
	private float ThresholdY = 14f;

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
		}

	}

	void Jump ()
	{

		MyRigidBody.velocity = new Vector2(ForceX, ForceY);
		ForceX = ForceY = 0f;
		didJump = true;

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

			if (target.tag == "Platform") {

				if (GameManager.Instance != null) {

					GameManager.Instance.CreateNewPlatformAndLerp (target.transform.position.x);

				}

				if (ScoreManager.Instance != null) {

					ScoreManager.Instance.IncrementScore ();

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
