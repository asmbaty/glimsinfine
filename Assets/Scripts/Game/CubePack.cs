using UnityEngine;
using System.Collections;

public class CubePack : MonoBehaviour {
	
	/*void Awake()
	{
		Texture tex = LevelInfo.Environments.texturesCube[TrailRunner.Instance.level-1];
		foreach(Transform cube in transform)
		{
			if( cube.GetComponent<Cube>() != null)
				cube.renderer.material.mainTexture = tex;
		}
	}*/
	void Update()
	{
		if(transform.childCount==0)
			Destroy(this.gameObject);
	}
}
