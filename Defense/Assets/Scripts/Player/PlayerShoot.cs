using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// Handles all logic and data of the player controlled archers
/// </summary>
public class PlayerShoot : MonoBehaviour {

	public Projectile projectilePrefab;
	public Transform spawnPosition;
	public InputManager input;
	public BaseData baseData;
	public Base baseClass;
	
	private float attackTimer = 0f;
	private int fps = 60;

	void Start () {
		input.OnInput += Shoot;
		input.OnInput += ResetAttackTimer;
	}
	
	void Update ()
	{
		if (Time.timeScale > 0)
		{
			LookAtMouse();
		}
	}

	public void LookAtMouse()
	{
		if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < transform.position.y) return; 
		Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	private void Shoot(InputManager.InputActions action)
	{
		if (action != InputManager.InputActions.Click) return;

		if (attackTimer % (fps / baseClass.AttackSpeed) == 0 || attackTimer == 0)
		{
			Vector3 spawnLocation = spawnPosition.transform.position;

			Projectile projectile = Instantiate(projectilePrefab, spawnPosition.position, spawnPosition.rotation) as Projectile;
			projectile.transform.rotation = new Quaternion(projectile.transform.rotation.x, projectile.transform.rotation.y, projectile.transform.rotation.z, projectile.transform.rotation.w);
			projectile.MoveSpeed = baseClass.ProjectileSpeed;

			SetProjectileAttributes(projectile, baseClass.DamageOutput, baseClass.ProjectileSpeed);
		}

		if (attackTimer >= 60)
		{
			ResetAttackTimer(InputManager.InputActions.Reset);
		}
		
		attackTimer += 1f;
	}

	private void SetProjectileAttributes(Projectile projectile, float damage, float speed)
	{
		projectile.Damage = damage;
		projectile.MoveSpeed = speed;
	}

	public void ResetAttackTimer(InputManager.InputActions action)
	{
		if (action != InputManager.InputActions.Reset) return;

		attackTimer = 0;
	}
}
