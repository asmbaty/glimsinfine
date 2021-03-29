using UnityEngine;
using System.Collections;

public class Obstacle : TrailObject {
	
	void Awake()
	{
		tag = "obstacle";
	}
	
	protected override void Start()
	{
		base.Start();
	}
	
	protected override void Update()
	{
		base.Update();
	}
}
