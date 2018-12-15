using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles all data and logic of the main scene / level
/// </summary>
public class LevelManager : MonoBehaviour {

	public GameObject dayCompletePanel;
	public GameObject pausePanel;
	public GameObject losePanel;
	public GameObject winPanel;
	public GameData gameData;
	public BaseData baseData;
	public EnemySpawner spawner;
	public EnemyManager enemyManager;

	[Tooltip("Wave time in seconds")]
	[SerializeField] float waveTime;
	[SerializeField] private int lastWave = 5;
	[SerializeField] private int firstWave = 0;
	[SerializeField] private int currentWave;
	[SerializeField] float waveTimer;

	private int deltaTime;
	private int coinsBeginAmount;

	private List<float> warriorStatsBuffer;

	void Start () {
		Time.timeScale = 1f;
		currentWave = firstWave;
		coinsBeginAmount = baseData.Coins;

		// Fills buffer
		warriorStatsBuffer = enemyManager.WarriorStats;
	}

	private void Update()
	{
		if (!spawner.Spawn && spawner.Enemies.Count == 0 && currentWave < lastWave)
		{
			currentWave = NextWave(currentWave, firstWave, lastWave);
		}

		if (!spawner.Spawn) return;

		waveTimer += 1 * Time.deltaTime;

		deltaTime = (int)waveTimer;

		if (deltaTime % waveTime == 0 && deltaTime != 0) spawner.Spawn = false;
	}

	public int NextWave(int currentWave, int firstWave, int lastWave)
	{
		currentWave += 1;
		waveTimer = 0;

		if (currentWave >= lastWave)
		{
			gameData.CurrentDay = DayComplete();

			return currentWave;
		}

		spawner.Spawn = true;
		enemyManager.IncreaseDifficulty(false, true, false);
		StartCoroutine(spawner.SpawnEnemy(spawner.SpawnTime, spawner.spawnField));

		return currentWave;
	}

	public int DayComplete()
	{
		Time.timeScale = 0;
		gameData.CurrentDay += 1;
		
		if (gameData.CurrentDay >= gameData.LastDay)
		{
			winPanel.SetActive(true);
			return gameData.CurrentDay;
		}

		enemyManager.WarriorStats = warriorStatsBuffer;
		enemyManager.IncreaseDifficulty(false, false, true);
		dayCompletePanel.SetActive(true);

		return gameData.CurrentDay;
	}

	public void Defeated()
	{
		Time.timeScale = 0;
		losePanel.SetActive(true);
	}
	
	public int LastWave { get { return lastWave; } }
	public int CurrentWave { get { return currentWave; } }
	public int CoinsBeginAmount { get { return coinsBeginAmount; } }
}
