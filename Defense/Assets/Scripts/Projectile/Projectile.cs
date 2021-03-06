﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the arrow logic and data
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour {

	[SerializeField] private float lifeTime = 5f;

	private float moveSpeed = 1f;
	private float damage = 1f;
	private string shooterTag;
	private Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Start ()
	{
		StartCoroutine(DestroyAfter(lifeTime));
	}
	
	void FixedUpdate ()
	{
		rb.velocity = transform.up * moveSpeed;

		if (Camera.main.WorldToViewportPoint(transform.position).y > 1 || Camera.main.WorldToViewportPoint(transform.position).x < 0 || Camera.main.WorldToViewportPoint(transform.position).x > 1) Destroy(gameObject);
	}

	public void SetProjectileAttributes(Projectile projectile, float damage, float speed, string shooterTag)
	{
		this.damage = damage;
		this.moveSpeed = speed;
		this.shooterTag = shooterTag;
	}

	IEnumerator DestroyAfter(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		Destroy(gameObject);
	}

	public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
	public float Damage { get { return damage; } set { damage = value; } }
	public string ShooterTag { get { return shooterTag; } set { shooterTag = value; } }
}
