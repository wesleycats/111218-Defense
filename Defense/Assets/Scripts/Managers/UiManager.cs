using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// This class manages all the UI elements
/// </summary>
public class UiManager : MonoBehaviour {

	public LevelManager levelManager;
	public GameData gameData;
	public Base baseClass;

	public Text healthAmount;
	public Text daysAmount;
	public Text wavesAmount;
	public Text coinsAmount;
	
	void Update () {
		healthAmount.text = baseClass.CurrentHealth.ToString();
		daysAmount.text = gameData.DaysLeft.ToString();
		wavesAmount.text = (levelManager.MaxWave - levelManager.CurrentWave).ToString();
		coinsAmount.text = gameData.Coins.ToString();
	}
}
