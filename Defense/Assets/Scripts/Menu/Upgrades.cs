using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Upgrades : MonoBehaviour {

	public BaseData baseData;
	public GameData gameData;
	public Text hp;
	public Text hpCost;
	public Text damage;
	public Text damageCost;
	public Text attackSpeed;
	public Text attackSpeedCost;
	public Text coinsAmount;

	[SerializeField] private int hpUpgrade = 50;
	[SerializeField] private int hpUpgradeCost = 50;
	[SerializeField] private int damageUpgrade = 5;
	[SerializeField] private int damageUpgradeCost = 50;
	[SerializeField] private int attackSpeedUpgrade = 1;
	[SerializeField] private int attackSpeedUpgradeCost = 50;

	void Update ()
	{
		hp.text = "HP: " + baseData.MaxHealth + " + " + hpUpgrade;
		hpCost.text = "Cost: " + hpUpgradeCost + " coins";

		damage.text = "Damage: " + baseData.DamageOutput + " + " + damageUpgrade;
		damageCost.text = "Cost: " + damageUpgradeCost + " coins";

		attackSpeed.text = "Attack speed: " + baseData.AttackSpeed + " + " + attackSpeedUpgrade;
		attackSpeedCost.text = "Cost: " + attackSpeedUpgradeCost + " coins";

		coinsAmount.text = gameData.Coins.ToString();
	}

	public void UpgradeHealth()
	{
		if (gameData.Coins < hpUpgradeCost) return;
		baseData.MaxHealth += hpUpgrade;
		gameData.Coins -= hpUpgradeCost;
	}

	public void UpgradeDamage()
	{
		if (gameData.Coins < damageUpgradeCost) return;
		baseData.DamageOutput += damageUpgrade;
		gameData.Coins -= damageUpgradeCost;
	}

	public void UpgradeAttackSpeed()
	{
		if (gameData.Coins < attackSpeedUpgradeCost) return;
		baseData.AttackSpeed += attackSpeedUpgrade;
		gameData.Coins -= attackSpeedUpgradeCost;
	}
}
