using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour {
	private Gameplay _gameplay;
	private Slider _slider;
	// Use this for initialization

	void Awake ()
	{
		_gameplay = GameObject.Find ("Gameplay").GetComponent<Gameplay> ();
		_slider = GetComponent<Slider>();


	}
	void Start () {
		_slider.maxValue = Config.timeGamePlay[GameEngine.Instance.gameStage - 1];
	}
	
	// Update is called once per frame
	void Update () {
		if(_gameplay.GetTimeLeft > 0){
			_slider.value = _gameplay.GetTimeLeft;
		}
	}
}
