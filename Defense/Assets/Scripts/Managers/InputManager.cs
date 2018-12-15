using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles all the input
/// </summary>
public class InputManager : MonoBehaviour {

	public enum InputActions { Click, Reset };
	public Action<InputActions> OnInput;

	private bool attackReset = true;

	void Update() {
		if (Input.GetMouseButton(0))
		{
			SendInput(InputActions.Click);
			attackReset = true;
		}
		else if (attackReset)
		{
			SendInput(InputActions.Reset);
			attackReset = false;
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
