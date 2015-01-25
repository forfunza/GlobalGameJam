using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopupGameOver : MonoBehaviour {

	private RectTransform rectTranform;
	public Image messageText;
	public Image starImage1;
	public Image starImage2;
	public Image starImage3;

	// Use this for initialization
	void Start () {
		rectTranform = GetComponent<RectTransform>();
		Debug.Log(rectTranform.transform.position.x + " " + rectTranform.transform.position.y + " " + rectTranform.transform.position.z );
//		rectTranform.position = new Vector3(rectTranform.transform.position.x,168,0);

//		Hashtable ht = new Hashtable ();
//		ht.Add ("x", rectTranform.transform.position.x);
//		ht.Add ("y", 270);
//		ht.Add ("time", 1);
//		ht.Add ("easetype","spring");
//		ht.Add ("onComplete", "tweenComplete");
//		ht.Add ("onCompleteTarget", gameObject);
//		iTween.MoveTo (this.gameObject, ht);

//		gameOver();
//		gameWin(2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void gameOver(){
//		messageText.text = "GameOver !!";
//		Sprite sprite = Resources.Load<Sprite>("Image/UI_PopUp/PopUp_Lose");
		messageText.sprite = Resources.Load<Sprite>("Image/UI_PopUp/PopUp_Lose");
		starImage1.sprite = Resources.Load<Sprite>("Image/UI_PopUp/Star_BG");
		starImage2.sprite = Resources.Load<Sprite>("Image/UI_PopUp/Star_BG");
		starImage3.sprite = Resources.Load<Sprite>("Image/UI_PopUp/Star_BG");
	}

	public void gameWin(int star){
//		messageText.text = "You Win !!";
		starImage1.sprite = Resources.Load<Sprite>("Image/UI_PopUp/Star_BG");
		starImage2.sprite = Resources.Load<Sprite>("Image/UI_PopUp/Star_BG");
		starImage3.sprite = Resources.Load<Sprite>("Image/UI_PopUp/Star_BG");
		if(star == 1){
			starImage1.sprite = Resources.Load<Sprite>("Image/UI_PopUp/Star");
		}else if(star == 2){
			starImage1.sprite = Resources.Load<Sprite>("Image/UI_PopUp/Star");
			starImage2.sprite = Resources.Load<Sprite>("Image/UI_PopUp/Star");
		}else if(star == 3){
			starImage1.sprite = Resources.Load<Sprite>("Image/UI_PopUp/Star");
			starImage2.sprite = Resources.Load<Sprite>("Image/UI_PopUp/Star");
			starImage3.sprite = Resources.Load<Sprite>("Image/UI_PopUp/Star");
		}
	}
}
