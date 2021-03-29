using UnityEngine;
using System.Collections;

public class ObstacleMoveForward : MonoBehaviour {

	public float speed = 100f;
	void Update () 
	{
		transform.localPosition += new Vector3(0f,0f,-speed*Time.deltaTime);
	}
}
