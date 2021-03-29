using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	public AudioSource music,sound;

	public AudioClip clipJump;
	public AudioClip clipCubeCollide;
	public AudioClip clipGameOver;
	public AudioClip clipLabelSwipe;

	public void PlayMusic(){
		music.Play();
	}

	public void PauseMusic(){
		music.Pause();
	}

	public void StopMusic(){
		music.Stop();
	}

	public void StopSound(){
		sound.Stop();
	}

	public void PauseAll(){
		PauseMusic();
		StopSound();
	}

	public void StopAll(){
		StopMusic();
		StopSound();
	}

	void Update()
	{
		if(TrailRunner.Instance.state == GameState.Paused && music.isPlaying)
			PauseAll();
	}
}
