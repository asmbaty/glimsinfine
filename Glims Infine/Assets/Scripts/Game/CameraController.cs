using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public float distance = 10f;
	
	void Update () 
	{
		if(TrailRunner.Instance.player.transform.position.z>=0)
		{
			var pos = transform.position;
			pos.z = TrailRunner.Instance.player.transform.position.z - distance;
			transform.position = pos;
		}
		else
			transform.position = new Vector3(0f,3f,-5f);
	}
}
