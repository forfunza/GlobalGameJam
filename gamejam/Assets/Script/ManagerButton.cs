using UnityEngine;
using System.Collections;

public class ManagerButton : MonoBehaviour {

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
	public void QuitGame (){
		Application.Quit();
	}
}
