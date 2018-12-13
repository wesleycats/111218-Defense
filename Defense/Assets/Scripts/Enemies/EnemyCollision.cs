using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the logic of the collision of the enemy
/// </summary>
public class EnemyCollision : MonoBehaviour {

	private EnemyManager enemyManager;
	private Enemy enemy;
	
	// TODO make player class for data instead of playerarcher for use of multiple archers
	private PlayerArcher player;

	private void Awake()
	{
		enemyManager = FindObjectOfType<EnemyManager>();
		player = FindObjectOfType<PlayerArcher>();
		enemy = GetComponent<Enemy>();
	}

	private void OnTriggerStay2D(Collider2D c)
	{
		if (c.transform.tag == "Arrow")
		{
			Destroy(c.gameObject);

			enemy.DecreaseHealth(player.DamageOutput);

			if (enemy.Health <= 0)
			{
				FindObjectOfType<EnemySpawner>().Enemies.Remove(this.gameObject.GetComponent<Enemy>());
				enemyManager.AddCoins((int)enemyManager.WarriorAttributes[4]);
				Destroy(gameObject);
			}
		}
	}
}
