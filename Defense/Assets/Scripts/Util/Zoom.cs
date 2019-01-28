using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {

	public InputManager input;

	[SerializeField] private Vector3 minScale;
	[SerializeField] private Vector3 maxScale;

	void Start () {
		input.OnInput += StartZoom;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartZoom(InputManager.InputActions action, float axis)
	{
		if (action != InputManager.InputActions.Zoom || (transform.localScale.x <= minScale.x && axis < 0) || (transform.localScale.x >= maxScale.x && axis > 0)) return;

		transform.localScale = new Vector3(transform.localScale.x + axis, transform.localScale.y + axis);
	}
}
