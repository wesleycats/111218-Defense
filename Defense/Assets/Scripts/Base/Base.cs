using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles all the base logic
/// </summary>
public class Base : MonoBehaviour
{
	public BaseData baseData;

	private int currentHealth;

	private int maxHealth;

	void Start()
	{
		maxHealth = baseData.MaxHealth;
		currentHealth = maxHealth;
	}

	public void DecreaseHealth(int amount)
	{
		currentHealth -= amount;
	}

	public int MaxHealth { get { return maxHealth; } }
	public int CurrentHealth { get { return currentHealth; } }
}