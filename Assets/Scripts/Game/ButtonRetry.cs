using UnityEngine;
using System.Collections;

public class ButtonRetry : MonoBehaviour {

	void OnClick()
	{
		TrailRunner.Instance.Retry();
	}
}
