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

	[SerializeField] private float spawnTime;
	[SerializeField] private List<Transform> targets = new List<Transform>();
	
	//TODO get area by spawnfield object
	[Header("Spawn area: x=minX, y=maxX, z=minY, w=maxY")]
	[SerializeField] private Vector4 spawnCoords = new Vector4(-8.5f, 4.8f, 5.5f, 8f);

	[SerializeField] private bool spawn = true;
	[SerializeField] private List<Enemy> enemies = new List<Enemy>();

	void Start () {
		spawn = true;
		enemies.Clear();
		StartCoroutine(SpawnEnemy(spawnTime, spawnField));
	}

	public IEnumerator SpawnEnemy(float waitTime, GameObject spawnLocation)
	{
		if (!spawn) yield break;

		SpawnEnemy(GetRandomEnemyType(GetEnemyTypeAmount()), enemyManager, GetRandomSpawnPos(spawnLocation));

		yield return new WaitForSeconds(waitTime);
		StartCoroutine(SpawnEnemy(waitTime, spawnField));
	}

	public void SpawnEnemy(EnemyType type, EnemyManager manager, Vector3 spawnPos)
	{
		// Sets the attributes of the enemy type
		switch (type)
		{
			case EnemyType.Warrior:
				enemyPrefab.SetAttributes(type, manager.WarriorAttributes[0], manager.WarriorAttributes[1], manager.WarriorAttributes[2], manager.WarriorAttributes[3], GetClosest(targets));

				break;
			default:
				enemyPrefab.SetAttributes(type, manager.WarriorAttributes[0], manager.WarriorAttributes[1], manager.WarriorAttributes[2], manager.WarriorAttributes[3], GetClosest(targets));

				break;
		}
#pragma warning disable
		Enemy enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity) as Enemy;
#pragma warning restore
		enemies.Add(enemy);
	}

	public Vector2 GetRandomSpawnPos(GameObject playField)
	{
		Vector2 spawnPos = new Vector2(0,0);

		// TODO get position from playfield

		/*Debug.Log(Camera.main.ScreenToWorldPoint(playField.GetComponent<RectTransform>().TransformPoint(playField.transform.position)));
		Minimal x position
		Debug.Log(-Camera.main.WorldToScreenPoint(Camera.main.transform.position).x);
		spawnPos.x = -Camera.main.WorldToScreenPoint(Camera.main.transform.position).x;
		spawnPos.x = UnityEngine.Random.Range(playFieldPos.offsetMin.x, playFieldPos.offsetMax.x);*/

		float randomX = UnityEngine.Random.Range(spawnCoords[0], spawnCoords[1]);
		float randomY = UnityEngine.Random.Range(spawnCoords[2], spawnCoords[3]);

		spawnPos.x = randomX;
		spawnPos.y = randomY;

		return spawnPos;
	}

	public EnemyType GetRandomEnemyType(int typeAmount)
	{
		EnemyType type;
		int index = 0;

		index = UnityEngine.Random.Range(0, typeAmount-1);

		switch(index)
		{
			case 0:
				type = EnemyType.Warrior;
				break;
			/*case 1:
				type = EnemyType.Archer;
				break;*/
			default:
				type = EnemyType.Warrior;
			break;
		}

		return type;
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

