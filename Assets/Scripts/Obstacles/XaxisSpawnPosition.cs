using UnityEngine;
using System.Collections;

public class XaxisSpawnPosition : MonoBehaviour {
	
	public float xMaxDistanceOfCenter = 0f;
	
	void Start()
	{
		transform.position = new Vector3(Random.Range(-xMaxDistanceOfCenter,xMaxDistanceOfCenter),transform.position.y,transform.position.z);
	}
}
