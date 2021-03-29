using UnityEngine;
using System.Collections;

public enum GameState
{
	Title,
	Menu,
	Play,
	Paused,
	Lose
}

public class TrailRunner : MonoBehaviour 
{
	#region Environments
	
	public Transform guiTitle;
	public Transform guiPlay;
	public Transform guiPause;
	public Transform guiLose;
	public Transform guiAbout;
	public UILabel labelDistance;

	public Camera mainCamera;
	public Player player;
	public Generator generator;
	public Title title;
	public GroundGenerator groundGenerator;
	public CameraController cameraController;
	public Popup popup;
	public GameObject tip;
	
	#endregion

	#region State Machine
	
	public int level{get;private set;}
	
	private GameState _state;
	public GameState state{
		get{
			return _state;
		}
		set{
			_state = value;
			
			guiTitle.gameObject.SetActive(_state == GameState.Title);
			guiPlay.gameObject.SetActive(_state == GameState.Play || _state == GameState.Paused || _state == GameState.Lose);
			guiPause.gameObject.SetActive(_state == GameState.Paused);
			guiLose.gameObject.SetActive(_state == GameState.Lose);

			switch(_state)
			{
			case GameState.Play:
				LevelInfo.Audio.PlayMusic();
				break;
			case GameState.Paused:
				LevelInfo.Audio.PauseAll();
				System.GC.Collect();
				break;
			case GameState.Title:
				LevelInfo.Audio.StopAll();
				break;
			case GameState.Lose:
				LevelInfo.Audio.StopAll();
				LevelInfo.Audio.sound.PlayOneShot(LevelInfo.Audio.clipGameOver);
				break;
			}

			//Debug.Log("game State: " + _state);
			Time.timeScale = _state == GameState.Paused || _state == GameState.Lose ? 0.0f : 1.0f ;
		}
	}
	
	public void StartGame(int level)
	{
		int runs = PlayerPrefs.GetInt("game_run",0);
		runs++;
		PlayerPrefs.SetInt("game_run",runs);
		PlayerPrefs.Save();
		if(runs<3) StartCoroutine(ShowTip());

		this.level = level;
		
		groundGenerator.Reset(level);
		TrailRunner.Instance.player.Reset();
		TrailRunner.Instance.generator.Reset();
		
		state = GameState.Play;
	}

	public void Retry()
	{
		StartGame(level);
	}

	private IEnumerator ShowTip()
	{
		yield return new WaitForSeconds(1f);
		tip.SetActive(true);
		yield return new WaitForSeconds(5f);
		tip.SetActive(false);
	}
	
	void Awake()
	{
		// System settings
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		int launch = PlayerPrefs.GetInt("game_launch",0);
		launch++;
		PlayerPrefs.SetInt("game_launch",launch);
		PlayerPrefs.Save();

		level=0;
		state = GameState.Title;
	}

	void Update()
	{	
		#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.Insert))
		{
			int coins = PlayerPrefs.GetInt("total_iqs",0);
			coins += 100;
			PlayerPrefs.SetInt("total_iqs",coins);
		}
		if(Input.GetKeyDown(KeyCode.Delete))
			PlayerPrefs.DeleteAll();
		#endif

		if(Input.GetKeyUp(KeyCode.Escape))
		{
			switch(state)
			{
			case GameState.Title:
				if(title.guiLevels.activeSelf)
				{
					title.guiMain.SetActive(true);
					title.guiLevels.SetActive(false);
					popup.gameObject.SetActive(false);
				}
				else if(title.guiBonusLevels.activeSelf)
				{
					title.guiMain.SetActive(true);
					title.guiBonusLevels.SetActive(false);
					popup.gameObject.SetActive(false);
				}
				else if(guiAbout.gameObject.activeSelf)
				{
					guiAbout.gameObject.SetActive(false);
					title.guiMain.SetActive(true);
				}
				else
					Application.Quit();
				break;
			}
		}
	}
	
	#endregion
	
	#region Static Instance
	
	// Multithreaded Safe Singleton Pattern
    // URL: http://msdn.microsoft.com/en-us/library/ms998558.aspx
    private static readonly object _syncRoot = new Object();
    private static volatile TrailRunner _staticInstance;	
    public static TrailRunner Instance 
	{
        get {
            if (_staticInstance == null) {				
                lock (_syncRoot) {
                    _staticInstance = FindObjectOfType (typeof(TrailRunner)) as TrailRunner;
                    if (_staticInstance == null) {
                       Debug.LogError("The LevelInfo instance was unable to be found, if this error persists please contact support.");						
                    }
                }
            }
            return _staticInstance;
        }
    }
	
	#endregion
	
}
