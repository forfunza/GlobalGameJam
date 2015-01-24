using UnityEngine;
using System.Collections;

public class RotateSample : MonoBehaviour
{	public float delay;
	public float speed;
	void Start(){

	}
	public void TurnRight(float delay) {
	this.delay = 	delay ;
	this.speed =	speed ;
	iTween.RotateBy(gameObject, iTween.Hash("y", .25, "easeType", "easeOutBounce", "loopType","none", "pingpong",1,"delay",delay));
	}
}

