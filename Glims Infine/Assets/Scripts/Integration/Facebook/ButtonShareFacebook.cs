using UnityEngine;
using System.Collections;

public class ButtonShareFacebook : MonoBehaviour {

	public UILabel message;

	private bool posted=false;
	private bool working=false;

	void OnEnable()
	{
		StopAllCoroutines ();
		message.text = "";
		posted = false;
	}

	void OnClick()
	{
		if(!working && !posted)
			StartCoroutine (Post ());
	}

	IEnumerator Post()
	{
		working = true;
		message.text = "Sharing...";

		MyFacebook.Instance.Init ();
		//yield return new WaitForSeconds (1f);

		yield return StartCoroutine(MyFacebook.Instance.Login());
		if(MyFacebook.Instance.Result==false)
		{
			message.text = "Error sharing :(";
			Debug.Log("Facebook: Log in Error");
		}
		else
		{
			//message.text = "Reout";
			yield return StartCoroutine(MyFacebook.Instance.ReutorizeWithPublishPermission());
			if(MyFacebook.Instance.Result==false)
			{
				message.text = "Error sharing :(";
				Debug.Log("Facebook: Reout error");
			}
			else
			{
				//message.text = "posting";
				yield return StartCoroutine(MyFacebook.Instance.PostOnWall(TrailRunner.Instance.player.distance));
				if(MyFacebook.Instance.Result==false)
				{
					message.text = "Error sharing :(";
				}
				else
				{
					Debug.Log("Facebook share Successful!");
					posted = true;
					message.text = "Successful!";
				}
			}
		}

		working = false;
	}
}
