using UnityEngine;
using System.Collections;

public class ManagerButton : MonoBehaviour {
	public GameObject title;
	public GameObject button;
	public Vector3 amount;
	public float time;
	public float waitTime;
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
	public void TitleOut () {
		StartCoroutine(WaitASec(waitTime));
	}
	IEnumerator WaitASec(float waitTime){
		yield return new WaitForSeconds(waitTime);
		iTween.MoveAdd(title,iTween.Hash("amount" ,amount,"time",time)); 
		iTween.MoveAdd(button,iTween.Hash("amount" ,amount,"time",time));

		Debug.Log ("Waited a sec");
	}
	public void QuitGame (){
		Application.Quit();
	}


}
