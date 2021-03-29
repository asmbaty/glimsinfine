using UnityEngine;
using System.Collections;

public class ObstacleFall : MonoBehaviour {
	
	public float riseDistance=0f;
	public float fallingTime=0.5f;
	
	IEnumerator Start()
	{
		while(transform.position.z-TrailRunner.Instance.player.transform.position.z>riseDistance)
			yield return null;
		iTween.MoveBy(gameObject,new Vector3(0f,-transform.position.y,0f),fallingTime);
	}
}
