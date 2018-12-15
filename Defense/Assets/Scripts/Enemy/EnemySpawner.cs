using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Handles all the spawn logic of the enemies
/// </summary>
public class EnemySpawner : MonoBehaviour {

	public GameObject spawnField;
	public EnemyManager enemyManager;
	public Enemy enemyPrefab;
	public Canvas canvas;
	public Camera cam;

	[SerializeField] private float spawnTime;
	[SerializeField] private List<Transform> targets = new List<Transform>();
	
	//TODO get area by spawnfield object
	[Header("Spawn area: x=minX, y=maxX, z=minY, w=maxY")]
	[SerializeField] private Vector4 spawnCoords = new Vector4(-8.5f, 4.8f, 5.5f, 8f);

	[SerializeField] private bool spawn = true;
	[SerializeField] private List<Enemy> enemies = new List<Enemy>();

	[Header("Spawn percentage per enemy type")]
	[Tooltip("[0]=Warrior, [1]=Archer")]
	[SerializeField] private List<float> spawnChance;

	// For customizable spawning randomness
	private int randomTypePercentage = 100;

	void Start () {
		spawn = true;
		enemies.Clear();
		StartCoroutine(SpawnEnemy(spawnTime, spawnField));
	}

	public IEnumerator SpawnEnemy(float waitTime, GameObject spawnField)
	{
		if (!spawn) yield break;

		SpawnEnemy(GetRandomEnemyType(GetEnemyTypeAmount()), enemyManager, GetRandomSpawnPos(spawnField));

		yield return new WaitForSeconds(waitTime);
		StartCoroutine(SpawnEnemy(waitTime, spawnField));
	}

	public void SpawnEnemy(EnemyType type, EnemyManager manager, Vector3 spawnPos)
	{
		// Sets the attributes of the enemy type
		switch (type)
		{
			case EnemyType.Warrior:
				enemyPrefab.SetStats(type, manager.WarriorStats[0], manager.WarriorStats[1], manager.WarriorStats[2], manager.WarriorStats[3], manager.WarriorStats[4], manager.WarriorStats[5], GetClosest(targets), manager.EnemyColors[0], manager.WarriorStats[6]);

				break;
			case EnemyType.Archer:
				enemyPrefab.SetStats(type, manager.ArcherStats[0], manager.ArcherStats[1], manager.ArcherStats[2], manager.ArcherStats[3], manager.ArcherStats[4], manager.ArcherStats[5], GetClosest(targets), manager.EnemyColors[1], manager.ArcherStats[6]);

				break;
			default:
				enemyPrefab.SetStats(type, manager.WarriorStats[0], manager.WarriorStats[1], manager.WarriorStats[2], manager.WarriorStats[3], manager.WarriorStats[4], manager.WarriorStats[5], GetClosest(targets), manager.EnemyColors[0], manager.WarriorStats[6]);

				break;
		}
#pragma warning disable
		Enemy enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity) as Enemy;
#pragma warning restore
		enemies.Add(enemy);
	}

	public Vector2 GetRandomSpawnPos(GameObject spawnField)
	{
		Vector2 spawnPos = new Vector2(0,0);

		// TODO get position from playfield

		float pixelRatio = (cam.orthographicSize * 2) / cam.pixelHeight;
		float orthoWidthSizeRatio = (cam.orthographicSize * 2) / spawnField.GetComponent<SpriteRenderer>().sprite.bounds.max.x;
		SpriteRenderer renderer = spawnField.GetComponent<SpriteRenderer>();

		spawnField.transform.localScale = new Vector3(orthoWidthSizeRatio, spawnField.transform.localScale.y);
	
		spawnField.transform.position = new Vector2(cam.ScreenToWorldPoint(Camera.main.transform.position).x * pixelRatio,
																				(cam.pixelHeight * pixelRatio) / 2 - renderer.sprite.bounds.min.y); //+ cam.ScreenToWorldPoint(Camera.main.transform.position).y);

		float randomX = UnityEngine.Random.Range(renderer.sprite.bounds.min.x * spawnField.transform.localScale.x, renderer.sprite.bounds.max.x * spawnField.transform.localScale.x);
		float randomY = UnityEngine.Random.Range(renderer.sprite.bounds.min.y * spawnField.transform.localScale.y + spawnField.transform.position.y, renderer.sprite.bounds.max.y * spawnField.transform.localScale.y + spawnField.transform.position.y);

		// Manual spawn position
		//float randomX = UnityEngine.Random.Range(spawnCoords[0], spawnCoords[1]);
		//float randomY = UnityEngine.Random.Range(spawnCoords[2], spawnCoords[3]);

		spawnPos.x = randomX;
		spawnPos.y = randomY;

		return spawnPos;
	}

	public EnemyType GetRandomEnemyType(int typeAmount)
	{

		int index = 0;
		index = UnityEngine.Random.Range(0, typeAmount * (randomTypePercentage / typeAmount));
		
		//TODO create customizable random spawner

		if (index < spawnChance[0])
		{
			return EnemyType.Warrior;
		}
		else if (index < spawnChance[1])
		{
			return EnemyType.Archer;
		}

		return EnemyType.Warrior;
	}

	public int GetEnemyTypeAmount()
	{
		int amount = 0;

		foreach (int i in Enum.GetValues(typeof(EnemyType)))
			amount += 1;

		return amount;
	}

	public Transform GetClosest(List<Transform> objects)
	{
		Transform closest = null;
		float minDist = Mathf.Infinity;

		foreach (Transform t in objects)
		{
			float dist = Vector3.Distance(t.position, transform.position);
			if (dist < minDist)
			{
				closest = t;
				minDist = dist;
			}
		}

		return closest;
	}

public bool Spawn { get { return spawn; } set { spawn = value; } }
public List<Enemy> Enemies { get { return enemies; } }
public float SpawnTime { get { return spawnTime; } }

// TEMP
public Vector4 SpawnCoords { get { return spawnCoords; } }
}

