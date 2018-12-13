using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// Handles all logic and data of the player controlled archers
/// </summary>
public class PlayerArcher : MonoBehaviour {

	public Arrow arrowPrefab;
	public Transform spawnObject;

	[SerializeField] private int damageOutput = 1;
	[Tooltip("Attack speed in seconds")]
	[SerializeField] private float attackSpeed = 1f;
	[SerializeField] private float arrowSpeed = 1f;
	[SerializeField] private float attackTimer = 0f;

	private InputManager input;

	public int DamageOutput
	{
		get
		{
			return damageOutput;
		}
		set
		{
			damageOutput = value;
		}
	}
	public float AttackSpeed
	{
		get
		{
			return attackSpeed;
		}
		set
		{
			attackSpeed = value;
		}
	}
	public float ArrowSpeed
	{
		get
		{
			return arrowSpeed;
		}
		set
		{
			arrowSpeed = value;
		}
	}

	private void Awake()
	{
		input = FindObjectOfType<InputManager>();
	}

	void Start () {
		input.OnInput += Shoot;
	}
	
	void Update ()
	{
		LookAtMouse();
	}

	public void LookAtMouse()
	{
		if (Input.mousePosition.y > Camera.main.WorldToScreenPoint(transform.position).y);
		Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	private void Shoot(InputManager.InputActions action)
	{
		if (action != InputManager.InputActions.Click) return;

		attackTimer += 1f;

		if (attackTimer % (60 / attackSpeed) == 0 || attackTimer == 0)
		{
			Vector3 spawnLocation = spawnObject.transform.position;

			// TODO fix rotation of arrows
			Arrow arrow = Instantiate(arrowPrefab, spawnObject.position, spawnObject.rotation) as Arrow;
			arrow.transform.rotation = new Quaternion(arrow.transform.rotation.x, arrow.transform.rotation.y, arrow.transform.rotation.z, arrow.transform.rotation.w);
			arrow.ArrowSpeed = arrowSpeed;

			SetArrowAttributes(arrow, damageOutput, arrowSpeed);
		}

		if (attackTimer >= 60)
		{
			attackTimer = 0;
		}
	}

	private void SetArrowAttributes(Arrow arrow, float damage, float speed)
	{
		arrow.ArrowDamage = damage;
		arrow.ArrowSpeed = speed;
	}
}
