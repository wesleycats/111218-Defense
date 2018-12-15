using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles all the debug features
/// </summary>
public class DebugBase : MonoBehaviour {

	public BaseData baseData;
	public GameData gameData;
	public Base baseClass;

	[SerializeField] private bool godmode;
	[SerializeField] private bool resetCoins;

	void Update() {
		if (godmode)
		{
			baseClass.IncreaseHealth(999999999);
			baseClass.IncreaseDamage(999999999);
			baseClass.IncreaseAttackSpeed(999999999);
			godmode = false;
		}
		
		if (resetCoins)
		{
			baseData.Coins = 0;
			resetCoins = false;
		}
	}

	public bool Godmode { get { return godmode; } }
}
