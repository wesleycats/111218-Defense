using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the overall data and the logic of the difficulty of the enemies
/// </summary>
public class EnemyManager : MonoBehaviour {
	
	public GameData gameData;

	[Header("Warrior Stats")]
	[Tooltip("[0]=health, [1]=damage, [2]=move speed, [3]=attack distance, [4]=coin value")]
	[SerializeField] private List<float> warriorAttributes = new List<float>();

	[Header("Archer Stats")]
	[Tooltip("[0]=health, [1]=damage, [2]=move speed, [3]=attack distance, [4]=coin value")]
	[SerializeField] private List<float> archerAttributes = new List<float>();

	[Header("Precentages of increased difficulty")]
	[SerializeField] private float waveDiffIncreaser;
	[SerializeField] private float dayDiffIncreaser;

	[Header("Percentages of chosen difficulty level")]
	[Tooltip("[0]=Easy, [1]=Normal, [2]=Hard, [3]=Extreme")]
	[SerializeField] private List<float> difficultyIncreaser = new List<float>();

	private void Start()
	{
		if (warriorAttributes.Count < 1)
		{
			warriorAttributes.Add(5f);
			warriorAttributes.Add(5f);
			warriorAttributes.Add(1f);
			warriorAttributes.Add(1.8f);
			warriorAttributes.Add(5f);
		}
	}

	public void AddCoins(int amount)
	{
		gameData.Coins += amount;
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
						attributes[i] = attributes[i] * difficultyIncreaser[0];
					}
					break;
				case GameData.DifficultyLevel.Normal:
					for (int i = 0; i < attributes.Count; i++)
					{
						attributes[i] = attributes[i] * difficultyIncreaser[1];
					}
					break;
				case GameData.DifficultyLevel.Hard:
					for (int i = 0; i < attributes.Count; i++)
					{
						attributes[i] = attributes[i] * difficultyIncreaser[2];
					}
					break;
				case GameData.DifficultyLevel.Extreme:
					for (int i = 0; i < attributes.Count; i++)
					{
						attributes[i] = attributes[i] * difficultyIncreaser[3];
					}
					break;
				default:
					for (int i = 0; i < attributes.Count; i++)
					{
						attributes[i] = attributes[i] * difficultyIncreaser[1];
					}
					break;
			}
		}
		else if (wave)
		{
			for (int i = 0; i < attributes.Count; i++)
			{
				attributes[i] = attributes[i] * waveDiffIncreaser;
			}
		} 
		else if (day)
		{
			for (int i = 0; i < attributes.Count; i++)
			{
				attributes[i] = attributes[i] * dayDiffIncreaser;
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
		IncreaseDifficulty(warriorAttributes, diff, wave, day);
	}

	public List<float> WarriorAttributes { get { return warriorAttributes; } }
	public List<float> ArcherAttributes { get { return archerAttributes; } }
}
