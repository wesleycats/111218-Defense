using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Handles all logic of the upgrades
/// </summary>
public class UpgradeManager : MonoBehaviour {

	public BaseData baseData;
	public GameData gameData;
	public UpgradeData upgradeData;
	public Text hp;
	public Text hpCost;
	public Text damage;
	public Text damageCost;
	public Text attackSpeed;
	public Text attackSpeedCost;
	public Text coinsAmount;

	void Update ()
	{
		hp.text = "HP: " + baseData.MaxHealth + " + " + upgradeData.HpUpgradeAmount;
		hpCost.text = "Cost: " + upgradeData.HpUpgradeCost + " coins";

		damage.text = "Damage: " + baseData.DamageOutput + " + " + upgradeData.DamageUpgradeAmount;
		damageCost.text = "Cost: " + upgradeData.DamageUpgradeCost + " coins";

		attackSpeed.text = "Attack speed: " + baseData.AttackSpeed + " + " + upgradeData.AttackSpeedUpgradeAmount;
		attackSpeedCost.text = "Cost: " + upgradeData.AttackSpeedUpgradeCost + " coins";

		coinsAmount.text = baseData.Coins.ToString();
	}

	public void UpgradeHealth()
	{
		if (baseData.Coins < upgradeData.HpUpgradeCost) return;
		baseData.MaxHealth += upgradeData.HpUpgradeAmount;
		baseData.Coins -= upgradeData.HpUpgradeCost;
		upgradeData.HpUpgradeCost = IncreaseUpgradeCost(upgradeData.HpUpgradeCost, upgradeData.HpUpgradeIncremental);
	}

	public void UpgradeDamage()
	{
		if (baseData.Coins < upgradeData.DamageUpgradeCost) return;
		baseData.DamageOutput += upgradeData.DamageUpgradeAmount;
		baseData.Coins -= upgradeData.DamageUpgradeCost;
		upgradeData.DamageUpgradeCost = IncreaseUpgradeCost(upgradeData.DamageUpgradeCost, upgradeData.DamageUpgradeIncremental);
	}

	public void UpgradeAttackSpeed()
	{
		if (baseData.Coins < upgradeData.AttackSpeedUpgradeCost) return;
		baseData.AttackSpeed += upgradeData.AttackSpeedUpgradeAmount;
		baseData.Coins -= upgradeData.AttackSpeedUpgradeCost;
		upgradeData.AttackSpeedUpgradeCost = IncreaseUpgradeCost(upgradeData.AttackSpeedUpgradeCost, upgradeData.AttackSpeedUpgradeIncremental);
	}

	public int IncreaseUpgradeCost(int upgradeCost, float percentage)
	{
		upgradeCost = (int)(upgradeCost * percentage);

		return upgradeCost;
	}
}
