using UnityEngine;
using System.Collections;

public class TitleButtonBonusLevels : MonoBehaviour {

	void OnClick()
	{
		TrailRunner.Instance.title.guiMain.SetActive(false);
		TrailRunner.Instance.title.guiBonusLevels.SetActive(true);
		TrailRunner.Instance.popup.gameObject.SetActive(false);
	}
}
