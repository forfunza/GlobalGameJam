using UnityEngine;
using System.Collections;

public class ManagerButton : MonoBehaviour {

	public GameObject popupMap;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void GotoScene (string sceneName)
	{
		Application.LoadLevel(sceneName);
	}
	public void QuitGame (){
		Application.Quit();
	}

	public void selectWorld(){
		GameObject go = (GameObject)Instantiate (popupMap, transform.parent.transform.position, transform.parent.transform.rotation);
		go.transform.parent = transform.parent.transform;
		go.transform.localScale = new Vector3(2.061856f,2.061856f,2.061856f);

		Hashtable ht = new Hashtable ();
		ht.Add ("scale",10.061856f);
		ht.Add ("time", 3);
		ht.Add ("easetype","linear");
//		ht.Add ("onComplete", "tweenComplete");
//		ht.Add ("onCompleteTarget", gameObject);
		iTween.ScaleFrom (this.gameObject, ht);

	}
}
