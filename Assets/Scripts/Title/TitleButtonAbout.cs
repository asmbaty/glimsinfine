using UnityEngine;
using System.Collections;

public class TitleButtonAbout : MonoBehaviour {
	
	void OnClick()
	{
		TrailRunner.Instance.title.guiMain.SetActive(false);
		TrailRunner.Instance.guiAbout.gameObject.SetActive(true);
		TrailRunner.Instance.popup.gameObject.SetActive(false);
	}
}
