using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RevmobManager : MonoBehaviour,IRevMobListener {

	public bool showdebuggui=false;
	private string message = "revmod feedback";
	
	private static readonly Dictionary<System.String, System.String> REVMOB_APP_IDS = new Dictionary<System.String, System.String>() {
		{ "Android", "52ab186ddf65675d38000059"}, // google
		//{ "Android", "52ab719204b4a54d98000003"}, // amazon
		{ "IOS", "529263c56c42a75c7f000003" } // real another app
    };
    private RevMob revmob;
	private RevMobFullscreen fullscreenAd = null;
	private RevMobPopup popupAd = null;

    void Awake() {
        revmob = RevMob.Start(REVMOB_APP_IDS, gameObject.name);
    }
	
	void Start() {
		fullscreenAd = revmob.CreateFullscreen();
		popupAd = revmob.CreatePopup();
		StartCoroutine(CheckAddLoaded());
	}
	
	IEnumerator CheckAddLoaded()
	{
		while(true)
		{
			yield return new WaitForSeconds(5f);
			if( fullscreenAd == null ) fullscreenAd = revmob.CreateFullscreen();
			if( popupAd == null ) popupAd = revmob.CreatePopup();
		}
	}
	
	public void ShowFullScreenAd()
	{
		if(fullscreenAd != null )
		{
			fullscreenAd.Show();
		}
		else
		{
			message = "fullscreen is null";
			if( popupAd != null )
				popupAd.Show();
			popupAd = revmob.CreatePopup();
		}
		fullscreenAd = revmob.CreateFullscreen();
	}
	void OnGUI()
	{
		if(showdebuggui)
			GUI.Label(new Rect(5f,5f,1000f,100f),message);
	}
	
	#region IRevMobListener implementation

    public void AdDidReceive (string revMobAdType) {
        Debug.Log("Ad did receive.");
		message = "Ad did receive: " + revMobAdType;
    }

    public void AdDidFail (string revMobAdType) {
        Debug.Log("Ad did fail.");
		message = "AdDidFail: " + revMobAdType;
    }

    public void AdDisplayed (string revMobAdType) {
        Debug.Log("Ad displayed.");
		message = "AdDisplayed: " + revMobAdType;
    }

    public void UserClickedInTheAd (string revMobAdType) {
        Debug.Log("Ad clicked.");
		message = "Ad clicked: " + revMobAdType;
    }

    public void UserClosedTheAd (string revMobAdType) {
        Debug.Log("Ad closed.");
		message = "Ad closed: " + revMobAdType;
    }
	public void InstallDidReceive (string message)
	{
		 Debug.Log("InstallDidReceive.");
		this.message = "InstallDidReceive: " + message;
	}

	public void InstallDidFail (string message)
	{
		Debug.Log("InstallDidFail.");
		this.message = "InstallDidFail: " + message;
	}
    #endregion
	
	#region Static Instance
	
	// Multithreaded Safe Singleton Pattern
    // URL: http://msdn.microsoft.com/en-us/library/ms998558.aspx
    private static readonly object _syncRoot = new Object();
    private static volatile RevmobManager _staticInstance;	
    public static RevmobManager Instance 
	{
        get {
            if (_staticInstance == null) {				
                lock (_syncRoot) {
                    _staticInstance = FindObjectOfType (typeof(RevmobManager)) as RevmobManager;
                    if (_staticInstance == null) {
                       Debug.LogError("The RevmobManager instance was unable to be found, if this error persists please contact support.");						
                    }
                }
            }
            return _staticInstance;
        }
    }
	
	#endregion
}
