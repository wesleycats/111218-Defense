using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Doesn't work with multiple different enemies

public class EnemyHandler : MonoBehaviour
{
	[SerializeField] bool move = true;

	public Action<EnemyAction> enemyAction;

	void Update()
	{
		if (move) SendAction(EnemyAction.Move);
	}

	public void SendAction(EnemyAction action)
	{
		if (enemyAction != null) enemyAction(action);
	}
}
public enum EnemyAction { Move, Attack }
