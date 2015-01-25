using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class closeButton : MonoBehaviour {

	public GameObject popupMap;
	Button closeButtont;

	// Use this for initialization
	void Start () {
		closeButtont = GetComponent<Button>();
		closeButtont.onClick.AddListener(() => { OnClick(); });
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		GameObject.Destroy(popupMap);
	}
}
