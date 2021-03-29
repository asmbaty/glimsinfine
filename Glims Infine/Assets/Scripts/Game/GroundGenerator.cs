using UnityEngine;
using System.Collections.Generic;

public class GroundGenerator : MonoBehaviour {
	
	public int groundLenght;
	public Texture[] levelTextures;
	public GameObject groundPrefab,closerPrefab;
	private GameObject[] ground;
	private GameObject groundCloser;
	private int index=-1;
	
	void Awake()
	{
		ground = new GameObject[groundLenght];
	}
	
	public void Reset(int level)
	{
		// remove old objects
		foreach(Transform child in transform) Destroy(child.gameObject);
		
		for(int i=0;i<groundLenght;i++)
		{
			ground[i] = (GameObject)Instantiate(groundPrefab);
			ground[i].transform.position = new Vector3(0f,0f,10*i);
			ground[i].transform.parent = transform;
		
			foreach(Transform m in ground[i].transform)
				m.GetComponent<Renderer>().material.mainTexture = levelTextures[level-1];
		}
		
		groundCloser = (GameObject)Instantiate(closerPrefab);
		groundCloser.transform.position = new Vector3(0f,5f,10*groundLenght-5f);
		groundCloser.transform.parent = transform;
		
		index=0;
	}
	
	void Update () 
	{
		if(index==-1) return;
		if(TrailRunner.Instance.player.transform.position.z>ground[index].transform.position.z+10f)
		{
			ground[index].transform.localPosition += new Vector3(0f,0f,10*groundLenght);
			groundCloser.transform.localPosition += new Vector3(0f,0f,10);
			if(++index==groundLenght) index=0;
		}
	}
}
