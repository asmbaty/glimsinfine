using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour {

	public UILabel labelDistance;
	public UILabel labelRecordDistance;
	public UILabel labelIQS;
	public UILabel labelTotalIQS;
	public UILabel labelNewRecord;
	public GameObject buttonsT;

	void OnEnable()
	{
		StartCoroutine(ShowStatusScreen());
	}

	IEnumerator ShowStatusScreen()
	{
		labelDistance.gameObject.SetActive(false);
		labelIQS.gameObject.SetActive(false);
		labelTotalIQS.gameObject.SetActive(false);
		labelRecordDistance.gameObject.SetActive(false);
		labelNewRecord.gameObject.SetActive(false);
		buttonsT.SetActive(false);

		int current = TrailRunner.Instance.player.distance;
		int dlvl = TrailRunner.Instance.level;
		if(dlvl>=1&&dlvl<=4) dlvl=1;
		int record = PlayerPrefs.GetInt ("record_distance"+dlvl,0);
		int IQS = current/10;
		int totalIQS = PlayerPrefs.GetInt("total_iqs",0)+IQS;

		bool newrecord = current>record;
		record = Mathf.Max(record,current);

		PlayerPrefs.SetInt("total_iqs",totalIQS);
		PlayerPrefs.SetInt ("record_distance"+dlvl,record);
		
		labelDistance.text = "DISTANCE " + current;
		labelIQS.text = "LEVEL IQ " + IQS;
		labelTotalIQS.text = "TOTAL IQ " + totalIQS;
		labelRecordDistance.text = "RECORD " + record;

		yield return StartCoroutine(WaitTime(0.6f));
		labelDistance.transform.localPosition = new Vector3(0f,1000f,0f);
		LevelInfo.Audio.sound.PlayOneShot(LevelInfo.Audio.clipLabelSwipe);
		labelDistance.gameObject.SetActive(true);
		labelDistance.GetComponent<TweenPosition>().Play(true);

		float deltaTime=0.2f;

		yield return StartCoroutine(WaitTime(deltaTime));
		labelRecordDistance.transform.localPosition = new Vector3(0f,1000f,0f);
		LevelInfo.Audio.sound.PlayOneShot(LevelInfo.Audio.clipLabelSwipe);
		labelRecordDistance.gameObject.SetActive(true);
		labelRecordDistance.GetComponent<TweenPosition>().Play(true);

		yield return StartCoroutine(WaitTime(deltaTime));
		labelIQS.transform.localPosition = new Vector3(0f,1000f,0f);
		LevelInfo.Audio.sound.PlayOneShot(LevelInfo.Audio.clipLabelSwipe);
		labelIQS.gameObject.SetActive(true);
		labelIQS.GetComponent<TweenPosition>().Play(true);

		yield return StartCoroutine(WaitTime(deltaTime));
		labelTotalIQS.transform.localPosition = new Vector3(0f,1000f,0f);
		LevelInfo.Audio.sound.PlayOneShot(LevelInfo.Audio.clipLabelSwipe);
		labelTotalIQS.gameObject.SetActive(true);
		labelTotalIQS.GetComponent<TweenPosition>().Play(true);

		yield return StartCoroutine(WaitTime(1.0f));
		buttonsT.SetActive(true);

		yield return StartCoroutine(WaitTime(0.5f));
		labelNewRecord.gameObject.SetActive(newrecord);
	}

	IEnumerator WaitTime(float seconds)
	{
		while(seconds>0)
		{
			seconds -= 0.016f;
			yield return null;
		}
	}
}
