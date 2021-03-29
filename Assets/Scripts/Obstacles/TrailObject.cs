using UnityEngine;
using System.Collections;

public class TrailObject : MonoBehaviour {
	
	virtual protected void Start ()
	{
		
	}
	
	virtual protected void Update () 
	{
		if( transform.position.y < -5f || transform.position.z < TrailRunner.Instance.player.distance-5f)
			Destroy(this.gameObject);
	}
}
