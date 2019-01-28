using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugUI : MonoBehaviour {

	public GameObject features;
	public BaseData baseData;
	public DebugBase debugBase;

	[SerializeField] private bool isShown = false;

	void Start () {
		features.SetActive(isShown);
	}

	public void ActivatePanel()
	{
		features.SetActive(!features.activeSelf);
	}

	public void ActivateGodmode()
	{
		debugBase.ActivateGodmode(features.transform.Find("tgl_Godmode").GetComponent<Toggle>().isOn);
	}

	public void ActivateLaser()
	{
		debugBase.ActivateLaser(features.transform.Find("tgl_Laser").GetComponent<Toggle>().isOn);
	}

	public void SetCoins()
	{
		InputField coinInput = features.GetComponentInChildren<InputField>();

		try
		{
			baseData.Coins = int.Parse(coinInput.text);
		}
		catch
		{
			baseData.Coins = baseData.Coins;
		}
		coinInput.text = "";
	}
}
