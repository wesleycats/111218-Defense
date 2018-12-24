using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public GameData gameData;
	public GameObject continueButton;
	public EnemyData enemyData;
	
	void Start()
	{
		if (gameData.CurrentDay == 0)
		{
			continueButton.SetActive(false);
			InitEnemyDefaultStats();
		}
		else
		{
			continueButton.SetActive(true);
		}
	}

	private void InitEnemyDefaultStats()
	{
		// Also adds the EnemyStatsForm to the list enemyStatsForms in EnemyData
		enemyData.InitDefaultStats(enemyData.EnemyTypeForm.WarriorStatsForm);
		enemyData.InitDefaultStats(enemyData.EnemyTypeForm.ArcherStatsForm);
	}
}
