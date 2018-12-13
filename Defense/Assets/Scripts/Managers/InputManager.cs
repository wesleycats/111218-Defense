using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles all the input
/// </summary>
public class InputManager : MonoBehaviour {

	public enum InputActions { Click };
	public Action<InputActions> OnInput;

	void Update() {
		if (Input.GetMouseButton(0))
		{
			SendInput(InputActions.Click);
		}
	}

	private void SendInput(InputActions inputActions)
	{
		if (OnInput != null)
		{
			OnInput(inputActions);
		}
	}
}
