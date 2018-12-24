using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour {

	public UpgradeData upgradeData;
	public List<Image> startPowerUpButtons;

	[SerializeField] private float colorOffset;

	private void Start()
	{
		//TODO set powerup color + component button colorOffset + false
	}

	public void PowerUp(Image gameObject)
	{
		for (int i = 0; i < startPowerUpButtons.Count; i++)
		{
			if (i >= startPowerUpButtons.Count) return;
			if (gameObject == startPowerUpButtons[i])
			{
				upgradeData.StartPowerUps[i] = true;
				i++;
			}
			if (i >= startPowerUpButtons.Count || upgradeData.StartPowerUps[i]) return;
			startPowerUpButtons[i].GetComponent<Button>().enabled = false;
			startPowerUpButtons[i].color *= colorOffset;
		}
	}
}
