using UnityEngine;
using System.Collections;

public class animationPopupMap : MonoBehaviour {

	public Vector3 gg;
	public float time;
	public iTween.EaseType easeType;

	// Use this for initialization
	void Start () {
		gg = new Vector3(0.6467881f,0.6467881f);
//		ScaleSmooth();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ScaleSmooth() {
		iTween.ScaleAdd(this.gameObject,iTween.Hash("amount" ,gg,"time",time,"easeType",easeType.ToString()));  
		
	}
}
