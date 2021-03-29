using UnityEngine;
using System.Collections;

public class ButtonMenu : MonoBehaviour {

	void OnClick()
	{
		TrailRunner.Instance.state = GameState.Title;
		RevmobManager.Instance.ShowFullScreenAd();
	}
}
