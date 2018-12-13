using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseData", menuName = "Data/BaseData", order = 1)]
public class BaseData : ScriptableObject {

	[SerializeField] private int maxHealth = 100;
	[SerializeField] private int damageOutput = 5;
	[SerializeField] private int attackSpeed = 1;

	private int beginMaxHealth = 100;
	private int	beginDamageOutput = 5;
	private int beginAttackSpeed = 1;

	public int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
	public int DamageOutput { get { return damageOutput; } set { damageOutput = value; } }
	public int AttackSpeed { get { return attackSpeed; } set { attackSpeed = value; } }

	public int BeginMaxHealth { get { return beginMaxHealth; } }
	public int BeginDamageOutput { get { return beginDamageOutput; } }
	public int BeginAttackSpeed { get { return beginAttackSpeed; } }
}
