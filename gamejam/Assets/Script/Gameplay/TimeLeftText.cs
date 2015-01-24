using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeLeftText : MonoBehaviour {

	private Gameplay _gameplay;
	private Text _time;
	// Use this for initialization
	void Awake(){
		_gameplay = GameObject.Find ("Gameplay").GetComponent<Gameplay> ();
	}

	void Start () {
		_time = GetComponent<Text>();
		Debug.Log ("xxxxx");
		Debug.Log (_time);

	}

	void Update(){
		if(_gameplay.GetTimeLeft > 0){
			_time.text = _gameplay.GetTimeLeft.ToString();
		}
	}

}
