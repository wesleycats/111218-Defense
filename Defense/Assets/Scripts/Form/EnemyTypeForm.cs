using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyTypeForm
{
	[SerializeField] private EnemyStatsForm warriorStatsForm;
	[SerializeField] private EnemyStatsForm archerStatsForm;

	public void IncreaseAttribute(float attribute, float amount)
	{
		attribute += amount;
	}
	public void DecreaseAttribute(float attribute, float amount)
	{
		attribute -= amount;
	}
	public void MultiplyAttribute(float attribute, float amount)
	{
		attribute *= amount;
	}
	public void DivideAttribute(float attribute, float amount)
	{
		attribute /= amount;
	}

	public void InitDefaultStats(EnemyStatsForm enemyStatsForm)
	{
		enemyStatsForm.InitDefaultStats();
	}

public EnemyStatsForm WarriorStatsForm { get { return warriorStatsForm; } }
public EnemyStatsForm ArcherStatsForm { get { return archerStatsForm; } }
}
