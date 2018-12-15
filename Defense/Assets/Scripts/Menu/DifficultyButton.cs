using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

/// <summary>
/// Handles all logic of the difficulty button
/// </summary>
public class DifficultyButton : MonoBehaviour {

	private int index;
	private GameData.DifficultyLevel difficulty;
	private Text textHolder;

	private bool clicked;

	private void Awake()
	{
		textHolder = transform.GetChild(0).GetComponent<Text>();
	}

	void Start()
	{
		clicked = false;
		ChangeText(-1);
		index = 1;
	}

	public void IncreaseIndex()
	{
		if (clicked)
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
		else
		{
			clicked = true;
		}
	}

	public void ChangeText(int currentIndex)
	{
		switch(currentIndex)
		{
			case 0:
				textHolder.text = "Easy";
				difficulty = GameData.DifficultyLevel.Easy;
				break;
			case 1:
				textHolder.text = "Normal";
				difficulty = GameData.DifficultyLevel.Normal;
				break;
			case 2:
				textHolder.text = "Hard";
				difficulty = GameData.DifficultyLevel.Hard;
				break;
			case 3:
				textHolder.text = "Extreme";
				difficulty = GameData.DifficultyLevel.Extreme;
				break;
			default:
				textHolder.text = "Difficulty";
				difficulty = GameData.DifficultyLevel.Easy;
				break;
		}
	}

	public int CurrentIndex { get { return index; } set { index = value; } }
	public GameData.DifficultyLevel Difficulty { get { return difficulty; } }
}
