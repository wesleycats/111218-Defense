using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles all data and logic of the main scene / level
/// </summary>
public class LevelManager : MonoBehaviour {

	public GameObject dayCompletePanel;
	public GameObject losePanel;
	public GameObject pausePanel;
	public GameData gameData;
	public EnemySpawner spawner;
	public EnemyManager enemyManager;

	[Tooltip("Wave time in seconds")]
	[SerializeField] float waveTime;
	[SerializeField] private int maxWave = 5;
	[SerializeField] private int minWave = 0;
	[SerializeField] private int currentWave;
	[SerializeField] bool resetCoins;
	[SerializeField] float waveTimer;

	private int deltaTime;
	private int coinsBeginAmount;

	void Start () {
		currentWave = minWave;
		coinsBeginAmount = gameData.Coins;

		if (resetCoins)
		{
			gameData.Coins = 0;
			resetCoins = false;
		}
	}

	private void Update()
	{
		if (!spawner.Spawn && spawner.Enemies.Count == 0) currentWave = NextWave(currentWave, minWave, maxWave);

		if (!spawner.Spawn) return;

		waveTimer += 1 * Time.deltaTime;

		deltaTime = (int)waveTimer;

		if (deltaTime % waveTime == 0 && deltaTime != 0) spawner.Spawn = false;
	}

	public int NextWave(int currentWave, int minWave, int maxWave)
	{
		currentWave += 1;
		waveTimer = 0;

		if (currentWave > maxWave)
		{
			DayComplete();

			return minWave;
		}

		spawner.Spawn = true;
		enemyManager.IncreaseDifficulty(false, true, false);
		StartCoroutine(spawner.SpawnEnemy(spawner.SpawnTime, spawner.spawnField));

		return currentWave;
	}

	public void DayComplete()
	{
		enemyManager.IncreaseDifficulty(false, false, true);
		dayCompletePanel.SetActive(true);
		Time.timeScale = 0;
	}
	
	public int MaxWave { get { return maxWave; } }
	public int CurrentWave { get { return currentWave; } }
	public int CoinsBeginAmount { get { return coinsBeginAmount; } }
}
