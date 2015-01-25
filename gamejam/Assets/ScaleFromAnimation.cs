using UnityEngine;
using System.Collections;

public class ScaleFromAnimation : MonoBehaviour {
	public Vector3 gg;
	public float time;
	public iTween.EaseType easeType;
	public iTween.LoopType loopType;
	public GameObject title;
	public float titleTime;
	public Vector3 amount;
	public iTween.EaseType titleEaseType;

	// Use this for initialization
	void Start () {
		gg = new Vector3(0.25f,0.30f);
		ScaleSmooth();
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void ScaleSmooth() {
		iTween.ScaleAdd(this.gameObject,iTween.Hash("amount" ,gg,"time",time,"easeType",easeType.ToString(),"loopType",loopType.ToString()));  
		iTween.MoveAdd(title,iTween.Hash("amount" ,amount,"time",titleTime,"easeType",titleEaseType.ToString())); 

	}

}
