using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Data/UpgradeData", order = 1)]
public class UpgradeData : ScriptableObject {

	[Header("Current")]
	[SerializeField] private int hpUpgradeCost;
	[SerializeField] private int hpUpgradeAmount;
	[SerializeField] private int damageUpgradeCost;
	[SerializeField] private float damageUpgradeAmount;
	[SerializeField] private int attackSpeedUpgradeCost;
	[SerializeField] private float attackSpeedUpgradeAmount;
	
	[Tooltip("[0]=TripleHp, [1]=TripleDamage, [2]=TripleAttackSpeed")]
	[SerializeField] private List<bool> startPowerUps;

	[Header("Default")]
	[SerializeField] private int beginHpUpgradeCost;
	[SerializeField] private int beginHpUpgradeAmount;
	[SerializeField] private int beginDamageUpgradeCost;
	[SerializeField] private float beginDamageUpgradeAmount;
	[SerializeField] private int beginAttackSpeedUpgradeCost;
	[SerializeField] private float beginAttackSpeedUpgradeAmount;

	[Header("Upgrade increase percentages")]
	[SerializeField] private float hpUpgradeIncremental;
	[SerializeField] private float damageUpgradeIncremental;
	[SerializeField] private float attackSpeedUpgradeIncremental;

	public int HpUpgradeCost { get { return hpUpgradeCost; } set { hpUpgradeCost = value; } }
	public int HpUpgradeAmount { get { return hpUpgradeAmount; } set { hpUpgradeAmount = value; } }
	public int DamageUpgradeCost { get { return damageUpgradeCost; } set { damageUpgradeCost = value; } }
	public float DamageUpgradeAmount { get { return damageUpgradeAmount; } set { damageUpgradeAmount = value; } }
	public int AttackSpeedUpgradeCost { get { return attackSpeedUpgradeCost; } set { attackSpeedUpgradeCost = value; } }
	public float AttackSpeedUpgradeAmount { get { return attackSpeedUpgradeAmount; } set { attackSpeedUpgradeAmount = value; } }

	public int BeginHpUpgradeCost { get { return beginHpUpgradeCost; } }
	public int BeginHpUpgradeAmount { get { return beginHpUpgradeAmount; } }
	public int BeginDamageUpgradeCost { get { return beginDamageUpgradeCost; } }
	public float BeginDamageUpgradeAmount { get { return beginDamageUpgradeAmount; } }
	public int BeginAttackSpeedUpgradeCost { get { return beginAttackSpeedUpgradeCost; } }
	public float BeginAttackSpeedUpgradeAmount { get { return beginAttackSpeedUpgradeAmount; } }

	public float HpUpgradeIncremental { get { return hpUpgradeIncremental; } }
	public float DamageUpgradeIncremental { get { return damageUpgradeIncremental; } }
	public float AttackSpeedUpgradeIncremental { get { return attackSpeedUpgradeIncremental; } }

	public List<bool> StartPowerUps { get { return startPowerUps; } set { startPowerUps = value; } }

}
