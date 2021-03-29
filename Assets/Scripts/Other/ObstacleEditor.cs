using UnityEngine;
using System.Collections;

public class ObstacleEditor : MonoBehaviour {

	public float size1=0.9f;
	public int emmisionRate1=1;
	public float size2=0.05f;
	public int emmisionRate2=5;
	
	public void Action()
	{
		foreach(Transform obj in transform.GetComponentsInChildren<Transform>())
		{
			Debug.Log(obj.name);
			if(obj.name == "Hit Effect")
			{
				obj.GetComponent<ParticleSystem>().startSize = size1;
				obj.GetComponent<ParticleSystem>().emissionRate=emmisionRate1;
			}
			if(obj.name == "HitEffect1Beams")
			{
				obj.GetComponent<ParticleSystem>().startSize = size2;
				obj.GetComponent<ParticleSystem>().emissionRate=emmisionRate2;
			}
		}
	}
}
