using UnityEngine;
using System.Collections;

public class RotateControl : MonoBehaviour {
	public float degree = 0;
	public float time = 0;
	public string loopType = "none";
	public string easetype = "linear";
	// Use this for initialization
	void Start () {
		PlayRotate();
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void PlayRotate(){
		iTween.RotateAdd(gameObject, iTween.Hash("amount", new Vector3(0, 0, degree) , "time",time,"looptype",loopType,"easetype",easetype));
	}
}
