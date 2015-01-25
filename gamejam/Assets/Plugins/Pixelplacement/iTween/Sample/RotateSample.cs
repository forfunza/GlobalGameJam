using UnityEngine;
using System.Collections;

public class RotateSample : MonoBehaviour {
//{	public float delay;
//	public float speed;
	void Start(){
		iTween.RotateBy(this.gameObject, iTween.Hash("z", -1, "easeType", "linear", "loopType","loop", "time",50,"delay",0));
	}
	public void TurnRight(float delay) {
	
	}
}

