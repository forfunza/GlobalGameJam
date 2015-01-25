using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class okButton : MonoBehaviour {

	Button okButtont;
	public GameObject popupMap;
//	private Gameplay _gameplay;

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


		Debug.Log ("Onclick");
		GameObject go = (GameObject)Instantiate (popupMap, new Vector3 (transform.parent.transform.position.x,transform.parent.transform.position.y-300), transform.parent.transform.rotation);
		go.transform.parent = transform.parent.transform;
		go.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
//		GameObject.Destroy(transform.parent.gameObject);

//		_gameplay = GameObject.Find ("Gameplay").GetComponent<Gameplay> ();
//
//		StartCoroutine (distroyObject ());
	}

//	IEnumerator distroyObject ()
//	{
//		yield return new WaitForSeconds (0.3f);
//		GameObject.Destroy(gameObject);
//	}
}
