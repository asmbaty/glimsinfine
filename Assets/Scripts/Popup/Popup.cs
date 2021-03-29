using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {

	public UILabel labelText;
	public GameObject buttonYes,buttonNo,buttonOK;

	private TitleButtonLevel levelButton;
	private int cost;
	private bool haveiqs;

	public void ShowPopup(TitleButtonLevel buttonLevel,string levelName,int cost)
	{
		int totalIQS = PlayerPrefs.GetInt("total_iqs",0);

		bool haveiqs = totalIQS>=cost;
		buttonYes.SetActive(haveiqs);
		buttonNo.SetActive(haveiqs);
		buttonOK.SetActive(!haveiqs);

		this.haveiqs = haveiqs;
		this.cost = cost;
		this.levelButton = buttonLevel;

		if(haveiqs)
		{
			labelText.text = "UNLOCK " + levelName + " LEVEL WITH " + cost + " IQ? YOU HAVE " + totalIQS + ".";
		}
		else
		{
			labelText.text = "REQUIRED " + cost + " IQ. YOU HAVE " + totalIQS + ".";
		}

		gameObject.SetActive(true);
	}

	public void Answer(bool yes)
	{
		if(yes)
		{
			int totalIQS = PlayerPrefs.GetInt("total_iqs",0);
			if(totalIQS>=cost)
			{
				totalIQS -= cost;
				PlayerPrefs.SetInt("total_iqs",totalIQS);
				PlayerPrefs.Save();
				levelButton.Unlock();
			}
		}

		gameObject.SetActive(false);
	}
}
