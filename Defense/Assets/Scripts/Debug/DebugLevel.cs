using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLevel : MonoBehaviour {

	public GameData gameData;
	public GameData.DifficultyLevel difficulty;

	private void Start()
	{
		difficulty = gameData.Difficulty;
	}

	void Update () {
		gameData.Difficulty = difficulty;
	}
}
