using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles all the input
/// </summary>
public class InputManager : MonoBehaviour {

	public enum InputActions { Click, Reset, Zoom };
	public Action<InputActions, float> OnInput;

	private bool attackReset = true;

	void Update() {
		if (Input.GetMouseButton(0))
		{
			SendInput(InputActions.Click, 0);
			attackReset = true;
		}
		else if (attackReset)
		{
			SendInput(InputActions.Reset, 0);
			attackReset = false;
		}

		if (Input.GetAxis("Mouse ScrollWheel") != 0)
		{
			SendInput(InputActions.Zoom, Input.GetAxis("Mouse ScrollWheel"));
		}
	}

	private void SendInput(InputActions inputActions, float axis)
	{
		if (OnInput != null)
		{
			OnInput(inputActions, axis);
		}
	}
}
