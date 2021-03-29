using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	#region Parameters
	
	public float speed = 30;
	public float rotspeed = 10f;
	public float movingWidth=3.5f;
	
	public float jumpForce;
	public Vector3 cubeForce;

	public TrailRenderer trail;
	
	#endregion
	
	#region Update
	void Update ()
	{			
		if(TrailRunner.Instance.state != GameState.Play)
			return;

		transform.rotation = Quaternion.identity;
		
		var curspeed = (1f+(float)distance/25000f)*speed;
		var vec = new Vector3(rotspeed*GameEnvironment.InputAxis.x,0f,curspeed);
		transform.Translate(vec*Time.deltaTime);
		
		if(transform.position.z<0) return;
		
		vec = transform.position;
		vec.x = Mathf.Clamp(vec.x,-movingWidth,movingWidth);
		transform.position = vec;
				
		if( transform.position.y < 0.5f )
		{
			GetComponent<Rigidbody>().isKinematic = true;
			
			vec = transform.position;
			vec.y = 0.5f;
			transform.position = vec;
		}

		if(!trail.enabled&&transform.position.z>-4f)
			trail.enabled=true;
		
		if(Input.GetKeyDown(KeyCode.Space) || Input.touchCount==1&&Input.touches[0].phase == TouchPhase.Began && Input.touches[0].position.y <= Screen.height*0.8f)
		{
			if(GetComponent<Rigidbody>().velocity.y==0f)
			{
				GetComponent<Rigidbody>().isKinematic = false;
				GetComponent<Rigidbody>().AddForce(0f,jumpForce,0f);
				LevelInfo.Audio.sound.PlayOneShot(LevelInfo.Audio.clipJump);
			}
		}
		
		TrailRunner.Instance.labelDistance.text = "" + distance + " m";
	}

	#endregion
	
	#region Collision Detection

	public bool Invinsibility=false;
	
	void OnCollisionEnter(Collision col)
	{	
		if( TrailRunner.Instance.state != GameState.Play) return;

		if( col.gameObject.tag == "cube")
		{
			LevelInfo.Audio.sound.PlayOneShot(LevelInfo.Audio.clipCubeCollide);
			col.gameObject.GetComponent<Rigidbody>().AddForce(cubeForce);
		}
		
		if(Invinsibility) return;
		
		if( col.gameObject.tag == "obstacle")
		{
			Destroy(this.GetComponent<Rigidbody>());
			TrailRunner.Instance.state = GameState.Lose;
		}
	}
	
	void OnTriggerEnter(Collider col)
	{
		if( TrailRunner.Instance.state != GameState.Play) return;

		if(Invinsibility) return;
		if( col.gameObject.tag == "obstacle")
		{
			Destroy(this.GetComponent<Rigidbody>());
			TrailRunner.Instance.state = GameState.Lose;
		}		
	}
	
	#endregion

	#region Coins

	private int _coins=-1;
	public int coins{
		get{
			if(_coins==-1)
				_coins = PlayerPrefs.GetInt("player_coins",0);
			return _coins;
		}
		set{
			_coins = value;
			PlayerPrefs.SetInt("player_coins",_coins);
		}
	}

	#endregion

	#region Methods
	
	public void Reset()
	{
		trail.enabled=false;
		transform.position = new Vector3(0f,0.5f,-20f);
		if(GetComponent<Rigidbody>() == null) gameObject.AddComponent<Rigidbody>();
		GetComponent<Rigidbody>().isKinematic = true;
	}
	
	#endregion
	
	#region Properties
	
	public int distance{ get{ return Mathf.Max(0,Mathf.FloorToInt(transform.position.z)); }}
	
	#endregion
}
