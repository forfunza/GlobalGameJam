﻿using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
		SoundManager.Instance.AutoRunManager();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
