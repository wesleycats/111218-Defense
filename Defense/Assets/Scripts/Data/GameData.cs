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
	[SerializeField] private int currentDay = 0;
	[SerializeField] private int lastDay = 3;
	[SerializeField] private DifficultyLevel difficulty = DifficultyLevel.Normal;

	public int CurrentDay { get { return currentDay; } set { currentDay = value; } }
	public DifficultyLevel Difficulty { get { return difficulty; } set { difficulty = value; } }

	public int LastDay { get { return lastDay; } set { lastDay = value; } }
}
