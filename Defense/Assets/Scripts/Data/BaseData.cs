using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseData", menuName = "Data/BaseData", order = 1)]
public class BaseData : ScriptableObject {

	[Header("Current")]
	[SerializeField] private int coins = 0;
	[SerializeField] private int maxHealth = 100;
	[SerializeField] private float damageOutput = 5;
	[SerializeField] private float attackSpeed = 1;
	[SerializeField] private float projectileSpeed = 1;

	[Header("Default")]
	[SerializeField] private int beginMaxHealth;
	[SerializeField] private float beginDamageOutput;
	[SerializeField] private float beginAttackSpeed;
	[SerializeField] private float beginProjectileSpeed;

	public int Coins { get { return coins; } set { coins = value; } }
	public int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
	public float DamageOutput { get { return damageOutput; } set { damageOutput = value; } }
	public float AttackSpeed { get { return attackSpeed; } set { attackSpeed = value; } }
	public float ProjectileSpeed { get { return projectileSpeed; } set { projectileSpeed = value; } }

	public int BeginMaxHealth { get { return beginMaxHealth; } }
	public float BeginDamageOutput { get { return beginDamageOutput; } }
	public float BeginAttackSpeed { get { return beginAttackSpeed; } }
	public float BeginProjectileSpeed { get { return beginProjectileSpeed; } }
}
