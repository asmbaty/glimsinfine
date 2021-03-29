using UnityEngine;
using System.Collections;

public class ObstacleRotateInPlace : MonoBehaviour {
	public Vector3 speed;
	public bool allowViceversia;
	public float allowSpeedUpTo;
	
	void Awake()
	{
		if(allowViceversia&&Random.Range(0,2)!=Random.Range(0,2)) speed=-speed;
		if(allowSpeedUpTo>0f) speed*=Random.Range(1f,allowSpeedUpTo);
	}
	
	void Update()
	{
		transform.Rotate(speed*Time.deltaTime);
	}
}
