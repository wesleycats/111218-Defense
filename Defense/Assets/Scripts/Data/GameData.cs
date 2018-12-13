using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is a data storage for all the data of the game
/// </summary>
[CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData", order = 1)]
public class GameData : ScriptableObject {

	public enum DifficultyLevel { Easy, Normal, Hard, Extreme }

#pragma warning disable
	[SerializeField] private int coins = 0;
	[SerializeField] private int daysLeft = 3;
	[SerializeField] private DifficultyLevel difficulty = DifficultyLevel.Normal;

	[SerializeField] private int beginDaysLeft = 3;

	public int Coins { get { return coins; } set { coins = value; } }
	public int DaysLeft { get { return daysLeft; } set { daysLeft = value; } }
	public DifficultyLevel Difficulty { get { return difficulty; } set { difficulty = value; } }

	public int BeginDaysLeft { get { return beginDaysLeft; } }
}
