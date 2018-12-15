using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyAttack : MonoBehaviour {

	public Projectile projectilePrefab;

	private bool attack = false;

	Enemy enemy;
	Base baseClass;
	GameObject weapon;

	private void Awake()
	{
		enemy = GetComponent<Enemy>();
		baseClass = FindObjectOfType<Base>();
	}

	private void Start()
	{
		weapon = transform.GetChild(0).gameObject;

		if (enemy.Type != EnemyType.Archer)
		{
			weapon.SetActive(false);
			return;
		}
	}

	private void Update()
	{
		if (enemy.GetDistance(enemy.Target) <= enemy.AttackDistance && !attack)
		{
			StartCoroutine(StartAttack());
			attack = true;
		}
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
				baseClass.DecreaseHealth(enemy.Damage);
				break;
			case EnemyType.Archer:
				Projectile projectile = Instantiate(projectilePrefab, weapon.transform.position, weapon.transform.rotation) as Projectile;
				projectile.transform.rotation = new Quaternion(projectile.transform.rotation.x, projectile.transform.rotation.y, projectile.transform.rotation.z, projectile.transform.rotation.w);

				projectile.SetProjectileAttributes(projectile, enemy.Damage, enemy.ProjectileSpeed, transform.tag);

				break;
			default:
				Debug.Log("No enemy type was given");
				break;
		}
	}
}
