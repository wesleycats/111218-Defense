using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles all the base logic
/// </summary>
public class Base : MonoBehaviour
{
	public BaseData baseData;
	public LevelManager levelManager;
	
	// Attributes
	[SerializeField] private float currentHealth;
	[SerializeField] private float damageOutput;
	[SerializeField] private float attackSpeed;
	[SerializeField] private float projectileSpeed;

	void Start()
	{
		InitAttributes();
	}

	public void ResetHealth()
	{
		currentHealth = baseData.MaxHealth;
	}

	public void ResetAttackspeed()
	{
		attackSpeed = baseData.AttackSpeed;
	}

	public void ResetDamage()
	{
		damageOutput = baseData.DamageOutput;
	}

	public void IncreaseHealth(float amount)
	{
		if (!FindObjectOfType<DebugBase>()) return;

		currentHealth += amount;
	}

	public void IncreaseAttackspeed(float amount)
	{
		if (!FindObjectOfType<DebugBase>()) return;

		attackSpeed += amount;
	}

	public void IncreaseDamage(float amount)
	{
		if (!FindObjectOfType<DebugBase>()) return;

		damageOutput += amount;
	}

	public void DecreaseHealth(float amount)
	{
		currentHealth -= amount;

		if (currentHealth <= 0) levelManager.Defeated();
	}

	private void InitAttributes()
	{
		currentHealth = baseData.MaxHealth;
		damageOutput = baseData.DamageOutput;
		attackSpeed = baseData.AttackSpeed;
		projectileSpeed = baseData.ProjectileSpeed;
	}
	
	public float CurrentHealth { get { return currentHealth; } }
	public float DamageOutput { get { return damageOutput; } }
	public float AttackSpeed { get { return attackSpeed; } }
	public float ProjectileSpeed { get { return projectileSpeed; } }
}