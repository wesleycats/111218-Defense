using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuOptions : MonoBehaviour {

	public GameData gameData;
	public BaseData baseData;

	public void Pause(GameObject pausePanel)
	{
		pausePanel.SetActive(true);
		Time.timeScale = 0f;
	}

	public void Resume(GameObject pausePanel)
	{
		pausePanel.SetActive(true);
		Time.timeScale = 1f;
	}

	public void LoadScene(string name)
	{
		SceneManager.LoadScene(name);


		if (name == "MainMenu")
		{
			LevelManager levelManager = FindObjectOfType<LevelManager>();
			gameData.Coins = levelManager.CoinsBeginAmount;
		}
	}

	public void ChangeDifficulty(DifficultyButton button)
	{
		if (gameData.DaysLeft != gameData.BeginDaysLeft) return;
		button.IncreaseIndex();
		button.ChangeText(button.CurrentIndex, button.transform.GetChild(0).GetComponent<Text>());
		gameData.Difficulty = button.Difficulty;
	}

	public void NextDay(string name)
	{
		gameData.DaysLeft -= 1;
		SceneManager.LoadScene(name);
	}

	public void Retry()
	{
		LevelManager levelManager = FindObjectOfType<LevelManager>();
		gameData.Coins = levelManager.CoinsBeginAmount;

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Quit()
	{
		gameData.Coins = 0;
		gameData.DaysLeft = gameData.BeginDaysLeft;
		baseData.MaxHealth = baseData.BeginMaxHealth;
		baseData.DamageOutput = baseData.BeginDamageOutput;
		baseData.AttackSpeed = baseData.BeginAttackSpeed;

#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
		// Application.OpenURL(webplayerQuitURL);
#else
		Application.Quit()
#endif
	}
}
