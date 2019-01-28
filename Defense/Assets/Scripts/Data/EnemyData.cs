using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/EnemyData", order = 1)]
public class EnemyData : ScriptableObject {
	[SerializeField] private EnemyTypeForm enemyTypeForm;
	[SerializeField] private List<EnemyStatsForm> enemyStatsForms = new List<EnemyStatsForm>();

	public void InitDefaultStats(EnemyStatsForm enemyStatsForm)
	{
		enemyTypeForm.InitDefaultStats(enemyStatsForm);
		
		enemyStatsForms.Add(enemyStatsForm);

		for (int i = 0; i < enemyStatsForms.Count; i++)
		{
			if (enemyStatsForm == enemyStatsForms[i]) i++;

			if (i >= enemyStatsForms.Count) return;

		}
	}

public EnemyTypeForm EnemyTypeForm { get { return enemyTypeForm; } }
public List<EnemyStatsForm> EnemyStatsForms { get { return enemyStatsForms; } }
}
