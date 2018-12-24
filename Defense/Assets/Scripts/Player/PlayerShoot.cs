using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// Handles all logic and data of the player controlled archers
/// </summary>
public class PlayerShoot : MonoBehaviour {

	public Projectile projectilePrefab;
	public Transform weapon;
	public InputManager input;
	public BaseData baseData;
	
	[SerializeField] private float attackTimer = 0f;
	[SerializeField] private float lastShotTimer = 0f;
	private float cooldown = 0f;
	private int fps = 60;

	void Start () {
		input.OnInput += Shoot;
		input.OnInput += ResetAttackTimer;

		cooldown = fps / baseData.AttackSpeed;
	}

	void Update ()
	{
		if (Time.timeScale < 1) return;

		LookAtMouse();
		lastShotTimer += 1;
	}

	public void LookAtMouse()
	{
		if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < transform.position.y) return; 
		Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	private void Shoot(InputManager.InputActions action, float axis)
	{
		if (action != InputManager.InputActions.Click) return;

		if (attackTimer % cooldown == 0 || lastShotTimer >= cooldown)
		{
			Projectile projectile = Instantiate(projectilePrefab, weapon.position, weapon.rotation) as Projectile;
			projectile.transform.rotation = new Quaternion(projectile.transform.rotation.x, projectile.transform.rotation.y, projectile.transform.rotation.z, projectile.transform.rotation.w);

			projectile.SetProjectileAttributes(projectile, baseData.DamageOutput, baseData.ProjectileSpeed, transform.tag);

			lastShotTimer = 0;
			ResetAttackTimer(InputManager.InputActions.Reset, 0);
		}

		attackTimer += 1f;
	}

	public void ResetAttackTimer(InputManager.InputActions action, float axis)
	{
		if (action != InputManager.InputActions.Reset) return;

		attackTimer = 1f;
	}

	private IEnumerator SinceLastShot()
	{
		lastShotTimer += 1;
		yield return new WaitForSeconds(1);
	}
}
