using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public GameData gameData;
	public GameObject continueButton;
	public DifficultyButton difficultyButton;

	void Start()
	{
		if (gameData.CurrentDay == 0) continueButton.SetActive(false);
		else continueButton.SetActive(true);

		if (gameData.Difficulty != GameData.DifficultyLevel.Normal) difficultyButton.ChangeText(difficultyButton.CurrentIndex);
	}
}
