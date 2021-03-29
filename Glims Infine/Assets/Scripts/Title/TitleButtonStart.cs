using UnityEngine;
using System.Collections;

public class TitleButtonStart : MonoBehaviour {

	void OnClick()
	{
		TrailRunner.Instance.title.guiMain.SetActive(false);
		TrailRunner.Instance.title.guiLevels.SetActive(true);
		TrailRunner.Instance.popup.gameObject.SetActive(false);
	}
}
