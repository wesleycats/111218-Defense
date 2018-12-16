using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Changes the color of the enemy
/// </summary>
[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(SpriteRenderer))]
public class ChangeColor : MonoBehaviour {
	
	void Start () {
		GetComponent<SpriteRenderer>().color = GetComponent<Enemy>().Color;
	}
}
