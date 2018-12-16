using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles all the enemy movement logic
/// </summary>
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {
	
	private Enemy enemy;
	private Transform target;
	private float speed;

	private void Awake()
	{
		enemy = GetComponent<Enemy>();
	}

	private void Start()
	{
		target = enemy.Target;
		speed = enemy.MoveSpeed;
	}

	private void Update()
	{
		MoveTo(target, speed);
		LookAt(target);
	}
	
	public void LookAt(Transform target)
	{
		Vector3 direction = target.transform.position - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	public void MoveTo(Transform target, float moveSpeed)
	{
		if (enemy.GetDistance(target) <= enemy.AttackDistance) return; 

		float step = moveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
