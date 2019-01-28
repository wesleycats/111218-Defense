using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the overall data and the logic of the difficulty of the enemies
/// </summary>
public class EnemyManager : MonoBehaviour {

	public GameData gameData;
	public BaseData baseData;
	public EnemySpawner spawner;

	//TODO change all enemy stats to the forms in enemyData
	[Header("Warrior Stats")]
	[Tooltip("[0]=health, [1]=damage, [2]=move speed, [3]=attack speed, [4]=attack distance, [5]=coin value, [6]=projectile speed")]
	[SerializeField] private List<float> warriorStats = new List<float>();
	[Tooltip("[0]=health, [1]=damage, [2]=move speed, [3]=attack speed, [4]=attack distance, [5]=coin value, [6]=projectile speed")]
	[SerializeField] private List<float> archerStats = new List<float>();

	[Header("Precentages of increased difficulty")]
	[Tooltip("[0]=Easy, [1]=Normal, [2]=Hard, [3]=Extreme")]
	[SerializeField] private List<float> waveDiffIncreaser = new List<float>();

	[Tooltip("[0]=Easy, [1]=Normal, [2]=Hard, [3]=Extreme")]
	[SerializeField] private List<float> dayDiffIncreaser = new List<float>();

	[Header("Percentages of chosen difficulty level")]
	[Tooltip("[0]=Easy, [1]=Normal, [2]=Hard, [3]=Extreme")]
	[SerializeField] private List<float> difficultyIncreaser = new List<float>();

	[Header("Enemy colors")]
	[Tooltip("[0]=Warrior, [1]=Archer")]
	[SerializeField] private List<Color> enemyColors = new List<Color>();

	private int distanceIndex = 4;
	private int coinIndex = 5;

	private void Awake()
	{
		IncreaseDifficulty(true, false, true);
	}

	private void Start()
	{
		if (warriorStats.Count < 1)
		{
			warriorStats.Add(5f);
			warriorStats.Add(5f);
			warriorStats.Add(1f);
			warriorStats.Add(1.7f);
			warriorStats.Add(1f);
			warriorStats.Add(5f);
		}
	}

	public void AddCoins(int amount)
	{
		baseData.Coins += amount;
	}


	public int GetEnemyTypeAmount()
	{
		return spawner.GetEnemyTypeAmount();
	}


	/// <summary>
	/// Increases difficulty based on chosen level and which wave and day the player is on
	/// </summary>
	/// <param name="attributes"></param>
	/// <param name="diff"></param>
	/// <param name="wave"></param>
	/// <param name="day"></param>
	private void IncreaseDifficulty(List<float> attributes, bool diff, bool wave, bool day)
	{
		if (diff)
		{
			switch (gameData.Difficulty)
			{
				case GameData.DifficultyLevel.Easy:
					for (int i = 0; i < attributes.Count; i++)
					{
						// Skips attack distance
						if (i == distanceIndex) i = distanceIndex + 1;

						attributes[i] = attributes[i] * difficultyIncreaser[0];
					}
					break;
				case GameData.DifficultyLevel.Normal:
					for (int i = 0; i < attributes.Count; i++)
					{
						// Skips attack distance
						if (i == distanceIndex) i = distanceIndex + 1;

						attributes[i] = attributes[i] * difficultyIncreaser[1];
					}
					break;
				case GameData.DifficultyLevel.Hard:
					for (int i = 0; i < attributes.Count; i++)
					{
						// Skips attack distance
						if (i == distanceIndex) i = distanceIndex + 1;

						attributes[i] = attributes[i] * difficultyIncreaser[2];
					}
					break;
				case GameData.DifficultyLevel.Extreme:
					for (int i = 0; i < attributes.Count; i++)
					{
						// Skips attack distance
						if (i == distanceIndex) i = distanceIndex + 1;

						attributes[i] = attributes[i] * difficultyIncreaser[3];
					}
					break;
				default:
					for (int i = 0; i < attributes.Count; i++)
					{
						// Skips attack distance
						if (i == distanceIndex) i = distanceIndex + 1;

						attributes[i] = attributes[i] * difficultyIncreaser[1];
					}
					break;
			}
		}

		if (wave)
		{
			switch (gameData.Difficulty)
			{
				case GameData.DifficultyLevel.Easy:
					for (int i = 0; i < attributes.Count; i++)
					{
						// Skips attack distance
						if (i == distanceIndex) i = distanceIndex + 1;

						attributes[i] = attributes[i] * waveDiffIncreaser[0];
					}
					break;
				case GameData.DifficultyLevel.Normal:
					for (int i = 0; i < attributes.Count; i++)
					{
						// Skips attack distance
						if (i == distanceIndex) i = distanceIndex + 1;

						attributes[i] = attributes[i] * waveDiffIncreaser[1];
					}
					break;
				case GameData.DifficultyLevel.Hard:
					for (int i = 0; i < attributes.Count; i++)
					{
						// Skips attack distance
						if (i == distanceIndex) i = distanceIndex + 1;

						attributes[i] = attributes[i] * waveDiffIncreaser[2];
					}
					break;
				case GameData.DifficultyLevel.Extreme:
					for (int i = 0; i < attributes.Count; i++)
					{
						// Skips attack distance
						if (i == distanceIndex) i = distanceIndex + 1;

						attributes[i] = attributes[i] * waveDiffIncreaser[3];
					}
					break;
				default:
					for (int i = 0; i < attributes.Count; i++)
					{
						// Skips attack distance
						if (i == distanceIndex) i = distanceIndex + 1;

						attributes[i] = attributes[i] * waveDiffIncreaser[1];
					}
					break;
			}
		} 

		if (day)
		{
			
			switch (gameData.Difficulty)
			{
				case GameData.DifficultyLevel.Easy:
					for (int j = 0; j < gameData.CurrentDay; j++)
					{
						for (int i = 0; i < attributes.Count; i++)
						{
							// Skips attack distance
							if (i == distanceIndex) i = distanceIndex + 1;

							attributes[i] = attributes[i] * dayDiffIncreaser[0];
						}
					}
					break;
				case GameData.DifficultyLevel.Normal:
					for (int j = 0; j < gameData.CurrentDay; j++)
					{
						for (int i = 0; i < attributes.Count; i++)
						{
							// Skips attack distance
							if (i == distanceIndex) i = distanceIndex + 1;

							attributes[i] = attributes[i] * dayDiffIncreaser[1];
						}
					}
					break;
				case GameData.DifficultyLevel.Hard:
					for (int j = 0; j < gameData.CurrentDay; j++)
					{
						for (int i = 0; i < attributes.Count; i++)
						{
							// Skips attack distance
							if (i == distanceIndex) i = distanceIndex + 1;

							attributes[i] = attributes[i] * dayDiffIncreaser[2];
						}
					}
					break;
				case GameData.DifficultyLevel.Extreme:
					for (int j = 0; j < gameData.CurrentDay; j++)
					{
						for (int i = 0; i < attributes.Count; i++)
						{
							// Skips attack distance
							if (i == distanceIndex) i = distanceIndex + 1;

							attributes[i] = attributes[i] * dayDiffIncreaser[3];
						}
					}
					break;
				default:
					for (int j = 0; j < gameData.CurrentDay; j++)
					{
						for (int i = 0; i < attributes.Count; i++)
						{
							// Skips attack distance
							if (i == distanceIndex) i = distanceIndex + 1;

							attributes[i] = attributes[i] * dayDiffIncreaser[1];
						}
					}
					break;
			}
		}
	}

	/// <summary>
	///	Method to call from other scripts
	/// </summary>
	/// <param name="diff"></param>
	/// <param name="wave"></param>
	/// <param name="day"></param>
	public void IncreaseDifficulty(bool diff, bool wave, bool day)
	{
		IncreaseDifficulty(warriorStats, diff, wave, day);
		IncreaseDifficulty(archerStats, diff, wave, day);

		//TODO increase for all types
	}

	public List<float> WarriorStats { get { return warriorStats; } set { warriorStats = value; } }
	public List<float> ArcherStats { get { return archerStats; } set { archerStats = value; } }
	public List<Color> EnemyColors { get { return enemyColors; } set { enemyColors = value; } }
	public int CoinIndex { get { return coinIndex; } }
}
