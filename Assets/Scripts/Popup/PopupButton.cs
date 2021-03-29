using UnityEngine;
using System.Collections;

public class PopupButton : MonoBehaviour {

	public bool feedback;
	public Popup popup;

	void OnClick()
	{
		popup.Answer(feedback);
	}
}
