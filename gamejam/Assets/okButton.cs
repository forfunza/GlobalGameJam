using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class okButton : MonoBehaviour {

	Button okButtont;

	// Use this for initialization
	void Start () {
		okButtont = GetComponent<Button>();
		okButtont.onClick.AddListener(() => { OnClick(); });
	}
	
	// Update is called once per frame
	void Update () {

	}
	

	void OnClick(){
		Application.LoadLevel("MainScreen");
	}
}
