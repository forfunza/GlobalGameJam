using UnityEngine;
using System.Collections;

public class SoundManager : Singleton<SoundManager> {
	protected SoundManager () {}
	public AudioSource bgm;
	public bool checkRun;

	// Use this for initialization
	void Awake(){
		gameObject.AddComponent<AudioSource>();
		gameObject.AddComponent<AudioListener>();
		DontDestroyOnLoad(this.gameObject);

	}
	void Start () {;

	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName.Equals("MainScreen") && !checkRun  || Application.loadedLevelName.Equals("WorldMap") && !checkRun){
			bgm = gameObject.AddComponent<AudioSource>();
			bgm.clip = (AudioClip) Resources.Load(Config.SOUND+Config.BGM_MAIN_MENU, typeof(AudioClip));
			bgm.loop = true;
			bgm.Play ();
			checkRun = true;
		}
		else if (Application.loadedLevelName == "Gameplay" && !checkRun)
		{
			bgm = gameObject.AddComponent<AudioSource>();
			bgm.clip = (AudioClip) Resources.Load(Config.SOUND+Config.GAMEPLAY_BGM, typeof(AudioClip));
			bgm.loop = true;
			bgm.Play ();
			checkRun = true;
		}
	}

	public void PlaySound(AudioClip clip)
	{
		audio.clip = clip;
		audio.Play();
	}
	public void ChangeScene() {
		checkRun = false;
	}
	public void AutoRunManager() {

	}


}
