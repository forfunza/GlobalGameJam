using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class StatusUserBar : MonoBehaviour {

	public float maxHp;
	public float currentHp;
	private Slider userBar;

	// Use this for initialization
	void Start () {
		userBar = GetComponent<Slider>();
		userBar.maxValue = maxHp;
		userBar.value = currentHp;
//		InvokeRepeating("removeHealth", 3f, 3f);
//		userBar.value = currentHp;
//		setMaxHp(10f);
//		removeHealth(5f);
	}

//	void removeHealth(){
//		if(userBar.value > currentHp)
//			userBar.value -= 1f;
//	}

	// Update is called once per frame
	void Update () {

	}

//	void setMaxHp(float maxHp){
//		userBar.maxValue = maxHp;
//	}
//
//	void removeHealth(float health){
//		userBar.value = health;
//	}
}
