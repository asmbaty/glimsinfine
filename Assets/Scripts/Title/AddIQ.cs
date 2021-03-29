using UnityEngine;
using System.Collections;

public class AddIQ : MonoBehaviour {

	void OnClick()
	{
		int coins = PlayerPrefs.GetInt("total_iqs",0);
		coins += 500;
		PlayerPrefs.SetInt("total_iqs",coins);
	}
}
