using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores all the data of the enemy and the handles the logic of editing that data
/// </summary>
public enum EnemyType { Warrior } //, Archer, ArmoredArcher, Giant, Boss }
public class Enemy : MonoBehaviour {

	[SerializeField] private EnemyType type;
	[SerializeField] private Transform target;

	// Attributes
	[SerializeField] private float health;
	[SerializeField] private float damage;
	[SerializeField] private float speed;
	[SerializeField] private float aSpeed;
	[SerializeField] private float aDistance;
	[SerializeField] private float cValue;

	//TODO create attackspeed

	public void SetAttributes(EnemyType enemyType, float healthPoints, float damageOutput, float moveSpeed, float attackSpeed, float attackDistance, float coinValue, Transform enemyTarget)
	{
		type = enemyType;
		health = healthPoints;
		damage = damageOutput;
		speed = moveSpeed;
		aSpeed = attackSpeed;
		aDistance = attackDistance;
		cValue = coinValue;
		target = enemyTarget;
	}

	public void DecreaseHealth(float amount)
	{
		health -= amount;
	}

	// TODO clean up all getter/setters
	public EnemyType Type { get { return type; } }
	public float Health { get { return health; } }
	public float Damage { get { return damage; } }
	public float Speed { get { return speed; } }
	public float AttackSpeed { get { return aSpeed; } }
	public float AttackDistance { get { return aDistance; } }
	public float CoinValue { get { return cValue; } }
	public Transform Target { get { return target; } }
}
