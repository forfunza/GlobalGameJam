using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroButton : MonoBehaviour {
	private Gameplay _gameplay;
	private Button _button;
	public GameObject _popup;
	// Use this for initialization
	void Start () {
		_gameplay = GameObject.Find ("Gameplay").GetComponent<Gameplay> ();
	}


	public void OnButtonClick(){
		_gameplay.state = (int)Gameplay.State.Normal;
		Destroy(_popup);

	}
}
