using UnityEngine;
using System.Collections;

public class ButtonLevel : MonoBehaviour {

	public int level=0;
	
	void OnClick()
	{
		TrailRunner.Instance.StartGame(level);
	}
}
