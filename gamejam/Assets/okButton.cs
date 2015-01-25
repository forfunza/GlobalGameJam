using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class okButton : MonoBehaviour {

	Button okButtont;
	public GameObject popupMap;

	// Use this for initialization
	void Start () {
		okButtont = GetComponent<Button>();
		okButtont.onClick.AddListener(() => { OnClick(); });
	}
	
	// Update is called once per frame
	void Update () {

	}
	

	void OnClick(){
//		Application.LoadLevel("MainScreen");
		GameObject go = (GameObject)Instantiate (popupMap, transform.parent.transform.position, transform.parent.transform.rotation);
		go.transform.parent = transform.parent.transform;
		go.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
//		GameObject.Destroy(transform.parent.gameObject);
	}
}
