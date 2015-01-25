using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestGenarate : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GenarateTileLog(){
		GameEngine.RandomBox(4);
//		GameEngine.RandomTilesList();
		GameEngine.RandomTilesListWithStage(1);
	}
}
