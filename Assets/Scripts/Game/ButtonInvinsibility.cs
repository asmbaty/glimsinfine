using UnityEngine;
using System.Collections;

public class ButtonInvinsibility : MonoBehaviour {

	void OnClick()
	{
		TrailRunner.Instance.player.Invinsibility = !TrailRunner.Instance.player.Invinsibility;
	}
}
