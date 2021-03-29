using UnityEngine;
using System.Collections;

public class RateAppButton : MonoBehaviour {

	public enum Target{Google,Amazon};
	public Target target;

	string urlGoogle = @"https://play.google.com/store/apps/details?id=com.dfbeat.trailrunner";
	string urlAmazon = @"http://www.amazon.com/gp/mas/dl/android?p=com.dfbeat.trailrunner";

	void OnClick()
	{
		switch(target)
		{
		case Target.Google:
			Application.OpenURL(urlGoogle);
			break;
		case Target.Amazon:
			Application.OpenURL(urlAmazon);
			break;
		}
	}
}
