using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyAttack : MonoBehaviour {

	Enemy enemy;
	Base baseClass;

	private void Awake()
	{
		enemy = GetComponent<Enemy>();
		baseClass = FindObjectOfType<Base>();
	}

	public IEnumerator StartAttack()
	{
		Attack();
		yield return new WaitForSeconds(1 / enemy.AttackSpeed);
		StartCoroutine(StartAttack());
	}

	private void Attack()
	{
		switch (enemy.Type)
		{
			case EnemyType.Warrior:
				baseClass.DecreaseHealth((int)enemy.Damage);
				break;
			default:
				Debug.Log("No enemy type was given");
				break;
		}
	}
}
