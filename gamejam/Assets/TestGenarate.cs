using UnityEngine;
using System.Collections;

public class TestGenarate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GenarateTileLog(){
		GameEngine.RandomTilesList();
		GameEngine.RandomBox(4);
	}
}
