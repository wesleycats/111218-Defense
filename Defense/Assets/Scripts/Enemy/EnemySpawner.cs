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

	[SerializeField] private Vector2 spawnFieldScale = new Vector2(1,1);
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

	[Header("Unit spawn amount per wave")]
	//Customizable for multiple enemies
	//[SerializeField] private List<List<int>> unitSpawnAmount;
	[SerializeField] private List<int> unitSpawnAmount;

	// For customizable spawning randomness
	private int randomTypePercentage = 100;

#pragma warning disable
	SpriteRenderer renderer;
#pragma warning restore

	private void Awake()
	{
		renderer = spawnField.GetComponent<SpriteRenderer>();
	}

	void Start ()
	{
		InitSpawnField();

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
		Vector2 spawnPos = new Vector2(0, 0);

		// Manual spawn position
		float randomX = UnityEngine.Random.Range(spawnField.transform.position.x - renderer.bounds.extents.x, spawnField.transform.position.x + renderer.bounds.extents.x);
		float randomY = UnityEngine.Random.Range(spawnField.transform.position.y - renderer.bounds.extents.y, spawnField.transform.position.y + renderer.bounds.extents.y);

		spawnPos.x = randomX;
		spawnPos.y = randomY;

		return spawnPos;
	}

	public EnemyType GetRandomEnemyType(int typeAmount)
	{

		int index = 0;
		index = UnityEngine.Random.Range(0, typeAmount * (randomTypePercentage / typeAmount));

		//TODO create a good working customizable random spawner

		spawnChance.Sort();

		if (index < spawnChance[0])
		{
			return EnemyType.Archer;
		}
		else if (index < spawnChance[1])
		{
			return EnemyType.Warrior;
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

	private void InitSpawnField()
	{
		Vector3 cameraWorldSpaceEdges = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
		spawnField.transform.localScale = spawnFieldScale;
		spawnField.transform.position = new Vector2(cam.transform.position.x, cameraWorldSpaceEdges.y + renderer.bounds.extents.y);
	}

public List<Enemy> Enemies { get { return enemies; } }
//public List<List<int>> UnitSpawnAmount { get { return unitSpawnAmount; } }
public List<int> UnitSpawnAmount { get { return unitSpawnAmount; } }
public bool Spawn { get { return spawn; } set { spawn = value; } }
public float SpawnTime { get { return spawnTime; } }

// TEMP
public Vector4 SpawnCoords { get { return spawnCoords; } }
}

