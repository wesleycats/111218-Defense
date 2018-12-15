using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores all the data of the enemy and the handles the logic of editing that data
/// </summary>
public enum EnemyType { Warrior, Archer }//, ArmoredArcher, Giant, Boss }
public class Enemy : MonoBehaviour {

	[SerializeField] private EnemyType type;
	[SerializeField] private Transform target;

	// Stats
	[SerializeField] private float health;
	[SerializeField] private float damage;
	[SerializeField] private float mSpeed;
	[SerializeField] private float aSpeed;
	[SerializeField] private float pSpeed;
	[SerializeField] private float aDistance;
	[SerializeField] private float cValue;
	[SerializeField] private Color color;
	
	public void SetStats(EnemyType enemyType, float healthPoints, float damageOutput, float moveSpeed, float attackSpeed, float attackDistance, float coinValue, Transform enemyTarget, Color color, float projectileSpeed)
	{
		type = enemyType;
		health = healthPoints;
		damage = damageOutput;
		mSpeed = moveSpeed;
		aSpeed = attackSpeed;
		pSpeed = projectileSpeed;
		aDistance = attackDistance;
		cValue = coinValue;
		target = enemyTarget;
		this.color = color;
	}

	public void DecreaseHealth(float amount)
	{
		health -= amount;
	}

	public float GetDistance(Transform t)
	{
		float distance = Vector3.Distance(t.position, transform.position);

		return distance;
	}

	public EnemyType Type { get { return type; } }
	public float Health { get { return health; } }
	public float Damage { get { return damage; } }
	public float MoveSpeed { get { return mSpeed; } }
	public float AttackSpeed { get { return aSpeed; } }
	public float ProjectileSpeed { get { return pSpeed; } }
	public float AttackDistance { get { return aDistance; } }
	public float CoinValue { get { return cValue; } }
	public Transform Target { get { return target; } }
	public Color Color { get { return color; } }
}
