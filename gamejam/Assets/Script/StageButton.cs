using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class StageButton : MonoBehaviour {

	public int stage;
	public Image star1;
	public Image star2;
	public Image star3;
	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey(Config.STAR_OF_STATE+stage)){
			setStar(PlayerPrefs.GetInt(Config.STAR_OF_STATE+stage));
		}else{
			setStar(0);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setStar(int star){
		star1.enabled = false;
		star2.enabled = false;
		star3.enabled = false;
		if(star==1){
			star1.enabled = true;
		}else if(star==2){
			star1.enabled = true;
			star2.enabled = true;
		}else if(star==3){
			star1.enabled = true;
			star2.enabled = true;
			star3.enabled = true;
		}
	}

	public void PlayGame(){
		GameEngine.Instance.gameStage = stage;
		Application.LoadLevel ("Gameplay");
	}
}
