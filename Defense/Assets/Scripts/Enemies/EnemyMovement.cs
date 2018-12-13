using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles all the enemy movement logic
/// </summary>
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {
	
	//private EnemyHandler handler;
	private Enemy enemy;
	private Transform target;
	private float speed;

	private void Awake()
	{
		//handler = FindObjectOfType<EnemyHandler>();
		enemy = GetComponent<Enemy>();
	}

	private void Start()
	{
		//handler.enemyAction += Move;
		target = enemy.Target;
		speed = enemy.Speed;
	}

	private void Update()
	{
		MoveTo(target, speed);
	}

	/*public void Move(EnemyAction action)
	{
		if (action == EnemyAction.Move)
		{
			MoveTo(target, speed);
		}
	}*/

	public void LookAt(Transform target, bool look)
	{
		Vector3 direction = target.transform.position - Camera.main.WorldToScreenPoint(transform.position);
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	public void MoveTo(Transform target, float moveSpeed)
	{
		if (GetDistance(target) < enemy.Distance) return; 

		float step = moveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}

	public float GetDistance(Transform t)
	{
		float distance = Vector3.Distance(t.position, transform.position);

		return distance;
	}
}
