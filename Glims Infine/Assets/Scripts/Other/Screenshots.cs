using UnityEngine;
using System.Collections;

public class Screenshots : MonoBehaviour {
	public float rate;
	public string filename;

	int index=0;

	IEnumerator Start()
	{
		while(true)
		{
			yield return new WaitForSeconds(rate);
			index++;
			Application.CaptureScreenshot("D:\\"+filename+index+".png");
		}
	}
}
