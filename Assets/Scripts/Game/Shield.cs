using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {
	
	public float yStart=-1f,yEnd=0f;
	public float speed = 2f;
	
	private bool rise = false;
	
	void Awake()
	{
		tag = "obstacle";
		transform.position = new Vector3(transform.position.x,yStart,transform.position.z);
	}
	
	void Update () 
	{
		if(rise)
		{
			var y = Mathf.Clamp(transform.position.y+speed*Time.deltaTime,yStart,yEnd);
			transform.position = new Vector3(transform.position.x,y,transform.position.z);
		}
		else if(transform.position.z-TrailRunner.Instance.player.transform.position.z<50f)
			rise = true;
	}
}
