using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Warrior } //, Archer, ArmoredArcher, Giant, Boss }
public class Enemy : MonoBehaviour {

	[SerializeField] private EnemyType type;
	[SerializeField] private float health;
	[SerializeField] private float damage;
	[SerializeField] private float speed;
	[SerializeField] private float distance;
	[SerializeField] private Transform target;

	public void SetAttributes(EnemyType enemyType, float healthPoints, float damageOutput, float moveSpeed, float attackDistance, Transform enemyTarget)
	{
		type = enemyType;
		health = healthPoints;
		damage = damageOutput;
		speed = moveSpeed;
		distance = attackDistance;
		target = enemyTarget;
	}

	public void DecreaseHealth(int amount)
	{
		health -= amount;
	}

	// TODO clean up all getter/setters
	public EnemyType Type { get { return type; } }
	public float Health { get { return health; } }
	public float Damage
	{
		get
		{
			return damage;
		}
	}
	public float Speed
	{
		get
		{
			return speed;
		}
	}
	public float Distance
	{
		get
		{
			return distance;
		}
	}
	public Transform Target { get { return target; } }
}
