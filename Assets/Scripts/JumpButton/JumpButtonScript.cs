using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class JumpButtonScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {


	public void OnPointerDown (PointerEventData data)
	{

		//Debug.Log ("We are pressing the button");

		if (PlayerJumpScript.Instance != null) {

			PlayerJumpScript.Instance.SetPower(true);

		}


	}

	public void OnPointerUp (PointerEventData data)
	{

		//Debug.Log ("We have Released the button");

		if (PlayerJumpScript.Instance != null) {

			PlayerJumpScript.Instance.SetPower(false);

		}

	}

}
