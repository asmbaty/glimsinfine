using UnityEngine;
using System.Collections;

public class ObstacleHorizontalHitch : MonoBehaviour {
	
	public float speed=10f;
	public float allowSpeedUpTo;
	public float delta=4.5f;
		
	void Awake()
	{
		if(Random.Range(0,2)!=Random.Range(0,2)) speed=-speed;
		if(allowSpeedUpTo>0f) speed*=Random.Range(1f,allowSpeedUpTo);
	}
	
	void Update () 
	{
		var xpos = transform.localPosition.x;
		xpos += speed*Time.deltaTime;
		xpos = Mathf.Clamp(xpos,-delta,delta);
		if(xpos==delta||xpos==-delta) speed=-speed;
		transform.localPosition = new Vector3(xpos,transform.localPosition.y,transform.localPosition.z);
	}
}
