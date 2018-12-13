using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class DifficultyButton : MonoBehaviour {

	private int index;
	private GameData.DifficultyLevel difficulty;
	
	void Start() {
		index = 0;
		ChangeText(-1, transform.GetChild(0).GetComponent<Text>());
	}

	public void IncreaseIndex()
	{
		int difficultyAmount = 0;

		index += 1;

		foreach (int i in Enum.GetValues(typeof(GameData.DifficultyLevel)))
			difficultyAmount += 1;

		if (index >= difficultyAmount)
		{
			index = 0;
		}
	}

	public void ChangeText(int currentIndex, Text text)
	{
		switch(currentIndex)
		{
			case 0:
				text.text = "Easy";
				difficulty = GameData.DifficultyLevel.Easy;
				break;
			case 1:
				text.text = "Normal";
				difficulty = GameData.DifficultyLevel.Normal;
				break;
			case 2:
				text.text = "Hard";
				difficulty = GameData.DifficultyLevel.Hard;
				break;
			case 3:
				text.text = "Extreme";
				difficulty = GameData.DifficultyLevel.Extreme;
				break;
			default:
				text.text = "Difficulty";
				difficulty = GameData.DifficultyLevel.Easy;
				break;
		}
	}

	public int CurrentIndex { get { return index; } set { index = value; } }
	public GameData.DifficultyLevel Difficulty { get { return difficulty; } }
}
