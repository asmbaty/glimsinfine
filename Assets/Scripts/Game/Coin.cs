using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	//public float rotateSpeed=100f;
	public AudioClip clipCollect;
	private Player player;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	void Update()
	{
		//transform.Rotate(0f,0f,rotateSpeed*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		AudioSource.PlayClipAtPoint(clipCollect,transform.position);
		player.coins++;
		gameObject.SetActive(false);
	}
}
