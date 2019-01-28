using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStatsForm
{
	public EnemyData enemyData;

	[Header("Current")]
	[SerializeField] private float health;
	[SerializeField] private float damage;
	[SerializeField] private float attackSpeed;
	[SerializeField] private float moveSpeed;
	[SerializeField] private float projectileSpeed;
	[SerializeField] private float attackDistance;
	[SerializeField] private float coinValue;

	[Header("Default")]
	[SerializeField] private float defaultHealth;
	[SerializeField] private float defaultDamage;
	[SerializeField] private float defaultAttackSpeed;
	[SerializeField] private float defaultMoveSpeed;
	[SerializeField] private float defaultProjectileSpeed;
	[SerializeField] private float defaultAttackDistance;
	[SerializeField] private float defaultCoinValue;

	public void InitDefaultStats()
	{
		health = defaultHealth;
		damage = defaultDamage;
		moveSpeed = defaultMoveSpeed;
		attackSpeed = defaultAttackSpeed;
		projectileSpeed = defaultProjectileSpeed;
		attackDistance = defaultAttackDistance;
		coinValue = defaultCoinValue;
	}

public float Health { get { return health; } } 
public float Damage { get { return damage; } } 
public float MoveSpeed { get { return moveSpeed; } } 
public float AttackSpeed { get { return attackSpeed; } } 
public float ProjectileSpeed { get { return projectileSpeed; } }
public float AttackDistance { get { return attackDistance; } }
public float CoinValue { get { return coinValue; } }

public float DefaultHealth { get { return defaultHealth; } }
public float DefaultDamage { get { return defaultDamage; } }
public float DefaultMoveSpeed { get { return defaultMoveSpeed; } }
public float DefaultAttackSpeed { get { return defaultAttackSpeed; } }
public float DefaultProjectileSpeed { get { return defaultProjectileSpeed; } }
public float DefaultAttackDistance { get { return defaultAttackDistance; } }
public float DefaultCoinValue { get { return defaultCoinValue; } }
}
