﻿using UnityEngine;
using System.Collections;

public class ManagerButton : MonoBehaviour {

	public GameObject popupMap;

	public GameObject title;
	public GameObject button;
	public Vector3 amount;
	public float time;
	public float waitTime;

	// Use this for initialization
	void Start () {
		if(!PlayerPrefs.HasKey(Config.STAR_OF_STATE+1)){
			PlayerPrefs.SetInt(Config.STAR_OF_STATE+1,0);
			PlayerPrefs.Save();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void GotoScene (string sceneName)
	{
		Application.LoadLevel(sceneName);
	}
	public void TitleOut () {
		//StartCoroutine(WaitASec(waitTime));
		iTween.MoveAdd(title,iTween.Hash("amount" ,amount,"time",time)); 
	}
	IEnumerator WaitASec(float waitTime){
		yield return new WaitForSeconds(waitTime);

		//iTween.MoveAdd(button,iTween.Hash("amount" ,amount,"time",time));

		Debug.Log ("Waited a sec");
	}
	public void QuitGame (){
		Application.Quit();
	}
	
	public void selectWorld(){
		GameObject go = (GameObject)Instantiate (popupMap, transform.parent.transform.position, transform.parent.transform.rotation);
		go.transform.parent = transform.parent.transform;
		go.transform.localScale = new Vector3(2.061856f,2.061856f,2.061856f);

//		Hashtable ht = new Hashtable ();
//		ht.Add ("x", popupMap.transform.position.x);
//		ht.Add ("y", 175);
//		ht.Add ("time", 1);
//		ht.Add ("easetype","spring");
//		ht.Add ("onComplete", "tweenComplete");
//		ht.Add ("onCompleteTarget", gameObject);
//		iTween.MoveTo (popupMap, ht);

	}

}
