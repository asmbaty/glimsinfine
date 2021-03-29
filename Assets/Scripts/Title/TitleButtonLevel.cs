using UnityEngine;
using System.Collections;

public class TitleButtonLevel : MonoBehaviour {

	public int level;
	public string levelName;
	public bool locked=true;
	public int cost;

	private UISprite lockedLabel;

	void Awake()
	{
		lockedLabel = transform.FindChild("Locked").GetComponent<UISprite>();
		if(locked) locked = PlayerPrefs.GetInt("level_locked_"+level,0)==0;
		lockedLabel.gameObject.SetActive(locked);
	}

	void OnClick()
	{
		if(!locked)
		{
			TrailRunner.Instance.popup.gameObject.SetActive(false);
			TrailRunner.Instance.StartGame(level);
		}
		else
		{
			TrailRunner.Instance.popup.ShowPopup(this,levelName,cost);
		}
	}

	public void Unlock()
	{
		locked=false;
		PlayerPrefs.SetInt("level_locked_"+level,1);
		lockedLabel.gameObject.SetActive(false);
	}
}
