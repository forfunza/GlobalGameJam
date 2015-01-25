using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroButton : MonoBehaviour {

	private Button _button;
	// Use this for initialization
	void Start () {
		_button = GetComponent<Button>();
		_button.onClick.AddListener(() => { OnClick(); });
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){



	}

	public void OnButtonClick(){
		Debug.Log ("Onclick");
	}
}
