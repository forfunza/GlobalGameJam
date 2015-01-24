using UnityEngine;
using System.Collections;

public class SoundManager : Singleton<SoundManager> {
	protected SoundManager () {}
	// Use this for initialization
	void Awake(){
		gameObject.AddComponent<AudioSource>();
		gameObject.AddComponent<AudioListener>();
	}
	void Start () {;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySound(AudioClip clip)
	{
		audio.clip = clip;
		audio.Play();
	}

}
