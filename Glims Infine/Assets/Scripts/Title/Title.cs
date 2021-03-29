using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {
	
	public GameObject guiMain;
	public GameObject guiLevels;
	public GameObject guiBonusLevels;
	
	public UILabel labelTitle;
	public UIButton button1;
	public UIButton button2;
	public UIButton button3;
	
	void Awake()
	{
		TrailRunner.Instance.title.guiMain.SetActive(true);
		TrailRunner.Instance.title.guiLevels.SetActive(false);
		TrailRunner.Instance.title.guiBonusLevels.SetActive(false);
		
		labelTitle.gameObject.transform.localScale = new Vector3(1f,1f,1f);
		
		button1.gameObject.transform.localScale = new Vector3(0.01f,0.01f,1f);
		button2.gameObject.transform.localScale = new Vector3(0.01f,0.01f,1f);
		button3.gameObject.transform.localScale = new Vector3(0.01f,0.01f,1f);
		
		button1.isEnabled=false;
		button2.isEnabled=false;
		button3.isEnabled=false;
	}
	
	IEnumerator Start()
	{
		iTween.ScaleAdd(labelTitle.gameObject,new Vector3(200f,200f,1f),15f);
		yield return new WaitForSeconds(0.5f);//5f
		iTween.ScaleAdd(button1.gameObject,new Vector3(1f,1f,0f),1f);
		yield return new WaitForSeconds(0.5f);
		iTween.ScaleAdd(button2.gameObject,new Vector3(1f,1f,0f),1f);
		yield return new WaitForSeconds(0.5f);
		iTween.ScaleAdd(button3.gameObject,new Vector3(1f,1f,0f),1f);
		yield return new WaitForSeconds(0.5f);
		
		button1.isEnabled=true;
		button2.isEnabled=true;
		button3.isEnabled=true;
	}
}
