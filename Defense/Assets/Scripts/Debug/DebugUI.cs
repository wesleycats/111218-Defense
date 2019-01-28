using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugUI : MonoBehaviour {

	public GameObject features;
	public BaseData baseData;
	public DebugBase debugBase;
	public Text clock;

	[SerializeField] private bool isShown = false;

	private int seconds;
	private int minutes;
	private int hours;

	void Start () {
		features.SetActive(isShown);

		StartCoroutine(Clock());
	}

	IEnumerator Clock()
	{
		seconds++;

		if (seconds > 59)
		{
			seconds = 0;
			minutes++;
		}

		if (minutes > 59)
		{
			minutes = 0;
			hours++;
		}

		clock.text = hours.ToString() + "\"\"" + minutes.ToString() + "\"\"" + seconds.ToString();

		// adds a zero before the time unit so it is a double digit
		if (hours < 10)
		{
			if (minutes < 10)
			{
				if (seconds < 10)
				{
					clock.text = "0" + hours.ToString() + "\"\"0" + minutes.ToString() + "\"\"0" + seconds.ToString();
				}
				else
				{
					clock.text = "0" + hours.ToString() + "\"\"0" + minutes.ToString() + "\"\"" + seconds.ToString();
				}
			}
			else
			{
				if (seconds < 10)
				{
					clock.text = "0" + hours.ToString() + "\"\"" + minutes.ToString() + "\"\"0" + seconds.ToString();
				}
				else
				{
					clock.text = "0" + hours.ToString() + "\"\"" + minutes.ToString() + "\"\"" + seconds.ToString();
				}
			}
		} else
		{
			if (minutes < 10)
			{
				if (seconds < 10)
				{
					clock.text = hours.ToString() + "\"\"0" + minutes.ToString() + "\"\"0" + seconds.ToString();
				}
				else
				{
					clock.text = hours.ToString() + "\"\"0" + minutes.ToString() + "\"\"" + seconds.ToString();
				}
			}
			else
			{
				if (seconds < 10)
				{
					clock.text = hours.ToString() + "\"\"" + minutes.ToString() + "\"\"0" + seconds.ToString();
				}
				else
				{
					clock.text = hours.ToString() + "\"\"" + minutes.ToString() + "\"\"" + seconds.ToString();
				}
			}
		}



		yield return new WaitForSeconds(1);
		StartCoroutine(Clock());
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
