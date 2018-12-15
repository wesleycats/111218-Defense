using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the logic of the collision of the enemy
/// </summary>
public class EnemyCollision : MonoBehaviour {

	private EnemyManager enemyManager;
	private Enemy enemy;
	private Base baseClass;

	private bool hit;

	private void Awake()
	{
		enemyManager = FindObjectOfType<EnemyManager>();
		enemy = GetComponent<Enemy>();
		baseClass = FindObjectOfType<Base>();
	}

	private void OnTriggerEnter2D(Collider2D c)
	{
		if (c.tag == "Arrow")
		{
			if (c.GetComponent<Projectile>().ShooterTag == transform.tag) return;

			Destroy(c.gameObject);
			StartCoroutine(HitAnimation());
			enemy.DecreaseHealth(baseClass.DamageOutput);

			if (enemy.Health <= 0)
			{
				FindObjectOfType<EnemySpawner>().Enemies.Remove(this.gameObject.GetComponent<Enemy>());
				enemyManager.AddCoins((int)enemyManager.WarriorStats[enemyManager.CoinIndex]);
				Destroy(gameObject);
			}
		}
	}

	private IEnumerator HitAnimation()
	{
		hit = true;
		Color buffer = GetComponent<SpriteRenderer>().color;
		GetComponent<SpriteRenderer>().color *= 0.5f;
		if (!hit)
		{
			yield return new WaitForSeconds(0.3f);
			GetComponent<SpriteRenderer>().color = buffer;
			hit = false;
			yield break;
		}
		yield return new WaitForSeconds(0.3f);
		hit = false;
	}
}
