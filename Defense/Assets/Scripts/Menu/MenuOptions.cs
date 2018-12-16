using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Handles all the logic of the buttons of the menus to navigate between scenes and control the pause menu
/// </summary>
public class MenuOptions : MonoBehaviour {

	public GameData gameData;
	public BaseData baseData;
	public UpgradeData upgradeData;

	public void Pause(GameObject pausePanel)
	{
		pausePanel.SetActive(true);
		Time.timeScale = 0f;
	}

	public void Resume(GameObject pausePanel)
	{
		pausePanel.SetActive(false);
		Time.timeScale = 1f;
	}

	public void LoadScene(string name)
	{
		SceneManager.LoadScene(name);


		if (name == "MainMenu")
		{
			LevelManager levelManager = FindObjectOfType<LevelManager>();
			baseData.Coins = levelManager.CoinsBeginAmount;
		}
	}

	public void ChangeDifficulty(DifficultyButton button)
	{
		if (gameData.CurrentDay != 0) return;
		button.IncreaseIndex();
		button.ChangeText(button.CurrentIndex);
		gameData.Difficulty = button.Difficulty;
	}

	public void Retry()
	{
		LevelManager levelManager = FindObjectOfType<LevelManager>();
		baseData.Coins = levelManager.CoinsBeginAmount;

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Quit()
	{
		ResetGame();

#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
		Application.OpenURL(webplayerQuitURL);
#else
		Application.Quit();
#endif
	}

	public void ResetGame()
	{
		gameData.CurrentDay = 0;

		baseData.Coins = 0;
		baseData.MaxHealth = baseData.BeginMaxHealth;
		baseData.DamageOutput = baseData.BeginDamageOutput;
		baseData.AttackSpeed = baseData.BeginAttackSpeed;
		baseData.ProjectileSpeed = baseData.BeginProjectileSpeed;

		upgradeData.HpUpgradeCost = upgradeData.BeginHpUpgradeCost;
		upgradeData.HpUpgradeAmount = upgradeData.BeginHpUpgradeAmount;
		upgradeData.DamageUpgradeCost = upgradeData.BeginDamageUpgradeCost;
		upgradeData.DamageUpgradeAmount = upgradeData.BeginDamageUpgradeAmount;
		upgradeData.AttackSpeedUpgradeCost = upgradeData.BeginAttackSpeedUpgradeCost;
		upgradeData.AttackSpeedUpgradeAmount = upgradeData.BeginAttackSpeedUpgradeAmount;
	}
}
