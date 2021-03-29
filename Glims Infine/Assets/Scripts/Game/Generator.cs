using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
	
	private enum ObstacleState
	{
		WhiteStar,
		RedStar,
		SkyLand,
		GroundRise,
		ElectroRise,
		None
	}
	
	public GameObject[] cube1;
	public GameObject[] cube2;
	public GameObject[] cube3;
	public GameObject[] cube4;
	public GameObject[] cube5;
	
	public GameObject[] whiteStars1;
	public GameObject[] redStars1;
	public GameObject[] skyLand;
	public GameObject[] groundRise1;
	
	public GameObject[] groundRise2;
	
	float startobstacle=50f;
	float forwardDistance=140f;
	
	float nextObstacle;
	
	void Update()
	{
		if(TrailRunner.Instance.state != GameState.Play) return;
		if(TrailRunner.Instance.player.transform.position.z > nextObstacle)
		{
			SpawnObstacle();
		}
	}
	
	#region Methods
	
	private void Spawn(float nextObstacleMin,float nextObstacleMax,params GameObject[][] array)
	{
		int index = Random.Range(0,array.Length);
		var obj = (GameObject)Instantiate(array[index][Random.Range(0,array[index].Length)]);
		obj.transform.localPosition = new Vector3(obj.transform.localPosition.x,obj.transform.localPosition.y,nextObstacle+forwardDistance);
		obj.transform.parent = transform;
		
		
		nextObstacle += Random.Range(nextObstacleMin,nextObstacleMax);
		//if(nextObstacle%1000>800f) nextObstacle+=200f;
	}
	
	private ObstacleState state = ObstacleState.None;
	private float stateDistance=0f;
	
	private void SpawnObstacle()
	{
		int level = TrailRunner.Instance.level;
		int distance = TrailRunner.Instance.player.distance;
		
		if(distance<=stateDistance)
		{
			switch(state)
			{
			case ObstacleState.ElectroRise:
				Spawn(15f,35f,groundRise2);
				break;
			case ObstacleState.GroundRise:
				Spawn(5f,25f,groundRise1);
				break;
			case ObstacleState.RedStar:
				Spawn(15f,70f,redStars1);
				break;
			case ObstacleState.WhiteStar:
				Spawn(15f,60f,whiteStars1);
				break;
			case ObstacleState.SkyLand:
				Spawn(5f,15f,skyLand);
				break;
			}
			return;
		}
		if(state != ObstacleState.None)
		{
			state = ObstacleState.None;
			nextObstacle += 100f;
			return;
		}
		
		if(distance>1000f&&Random.Range(0,15)==1)
		{
			state = (ObstacleState)Random.Range(0,4);
			Debug.Log("new State " + state);
			stateDistance = distance+600f;
			nextObstacle += 100f;
			return;
		}
		
		if(distance<=2000)
			Spawn(10f,40f,cube1);
		else if(distance<=4000f)
			Spawn(10f,40f,cube1,cube2);
		else if(distance<=6000f)
			Spawn(10f,40f,cube1,cube2,cube3);
		else if(distance<=8000f)
			Spawn(10f,40f,cube1,cube2,cube3,cube4);
		else
			Spawn(10f,40f,cube1,cube2,cube3,cube4,cube5);
		
		/*if(level==1)// Common Cube
		{
			Spawn(10f,40f,cube1,electroCube1);
			return;
			
			if(distance<=1000)
				Spawn(10f,25f,cube1,electroCube1);
			else if(distance<=2000)
				Spawn(5f,25f,groundRise1);
			else if(distance<=3000)
				Spawn(15f,60f,whiteStars1);
			else if(distance<=4000)
				Spawn(5f,15f,skyLand);
			else if(distance<=5000)
				Spawn(15f,70f,redStars1);
			else if(distance<=6000)
				Spawn(5f,20f,electroCube1,groundRise1);
			else if(distance<=7000)
				Spawn(8f,40f,whiteStars1,redStars1);
			else if(distance<=8000)
				Spawn(5f,15f,whiteStars1,skyLand);
			else if(distance<=9000)
				Spawn(5f,15f,redStars1,groundRise1);
			else if(distance<=15000)
				Spawn(5f,20f,electroCube1,redStars1,whiteStars1,groundRise1,skyLand);
			else if(distance<=20000)
				Spawn(5f,15f,electroCube1,redStars1,whiteStars1,groundRise1,skyLand);
			else if(distance<=25000)
				Spawn(5f,10f,electroCube1,redStars1,whiteStars1,groundRise1,skyLand);
		}
		
		if(level==2)
		{
			if(distance<=1000)
				Spawn(20f,50f,cube2,electroCube2);
			else if(distance<=2000)
				Spawn(15f,35f,groundRise2);
			else if(distance<=3000)
				Spawn(15f,35f,electroCube2);
			else if(distance<=4000)
				Spawn(10f,30f,cube2,groundRise2,electroCube1);					
			else if(distance<=5000)
				Spawn(10f,30f,groundRise2,electroCube2);
			else if(distance<=6000)
				Spawn(5f,25f,electroCube2,electroCube1);
			else if(distance<=7000)
				Spawn(5f,25f,groundRise2);
			else if(distance<=8000)
				Spawn(5f,15f,cube2,electroCube2);
			else if(distance<=10000)
				Spawn(5f,15f,groundRise2,electroCube2);
			else if(distance<=15000)
				Spawn(5f,10f,groundRise2,electroCube2,electroCube1);
		}*/

		
	}
	
	public void Reset()
	{
		foreach(Transform child in transform) Destroy(child.gameObject);
		nextObstacle = startobstacle;
		state = ObstacleState.None;
		stateDistance=0f;

		int level = TrailRunner.Instance.level;
		if(level==5) state = ObstacleState.WhiteStar;
		if(level==6) state = ObstacleState.RedStar;
		if(level==7) state = ObstacleState.GroundRise;
		if(level==8) state = ObstacleState.SkyLand;
		if(level>=5&&level<=8) stateDistance = float.PositiveInfinity;
	}
	
	#endregion
}
