using UnityEngine;
using System.Collections;

public class ButtonResume : MonoBehaviour {

	void OnClick()
	{
		TrailRunner.Instance.state = GameState.Play;
	}
}
