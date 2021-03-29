using UnityEngine;
using System.Collections;

public class ButtonPause : MonoBehaviour {

	void OnClick()
	{
		if(TrailRunner.Instance.state == GameState.Paused)
			TrailRunner.Instance.state = GameState.Play;
		else if(TrailRunner.Instance.state == GameState.Play)
			TrailRunner.Instance.state = GameState.Paused;
	}

	void Update()
	{
		if( Input.GetKeyDown(KeyCode.Escape))
			OnClick();
	}

	void OnApplicationPause(bool pause)
	{
		if(pause && TrailRunner.Instance.state == GameState.Play)
		{
			TrailRunner.Instance.state = GameState.Paused;
		}
	}
}
