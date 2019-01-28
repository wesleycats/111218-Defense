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
	[SerializeField] private bool laser;

	void Update() {
		if (godmode)
		{
			baseClass.IncreaseHealth(999999999);
			godmode = false;
		}

		if (laser)
		{
			baseClass.IncreaseAttackspeed(999999999);
			baseClass.IncreaseDamage(999999999);
			laser = false;
		}

		if (resetCoins)
		{
			baseData.Coins = 0;
			resetCoins = false;
		}
	}

	public void ActivateGodmode(bool activate)
	{
		godmode = activate;

		if (activate) return;

		baseClass.ResetHealth();
	}

	public void ActivateLaser(bool activate)
	{
		laser = activate;

		if (activate) return;

		baseClass.ResetAttackspeed();
		baseClass.ResetDamage();
	}

	public bool Godmode { get { return godmode; } }
}
