﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{

	
		public GameObject tilePrefab;
		public int numberOfTiles = 16;
		public int tilesPerRow = 4;
		public float distanceBetweenTiles = 1.0f;
//	public int numberOfMines = 10;
		private Sprite myTile;
		public enum State
		{
				Prepare = 0,
				Ready = 1
		}



		public int state;
		private int xIndex;
		private int yIndex;
		private int xTempIndex;
		private int yTempIndex;
		private GameObject[,] _tiles;
		private Dictionary<string,GameObject> _tilesBox = new Dictionary<string,GameObject> ();
//	
//	static Tile[] tilesAll;
//	static Array tilesMined;
//	static Array tilesUnmined;
		// Use this for initialization
		void Start ()
		{
				myTile = Resources.Load ("Image/tree", typeof(Sprite)) as Sprite;
				CreateTiles ();
				state = (int)State.Ready;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void CreateTiles ()
		{
//		tilesAll = new Tile[numberOfTiles];
//		tilesMined = new Array();
//		tilesUnmined = new Array();
		
				float xOffset = 0.0f;
				float yOffset = 0.0f;

				_tiles = new GameObject[4, 4];
				for (int rows = 0; rows < 4; rows++) {
		
						for (int cols = 0; cols < 4; cols++) {

			

								xOffset += distanceBetweenTiles;

								GameObject _tileObject = GameObject.Instantiate (tilePrefab, new Vector3 (transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z), transform.rotation) as GameObject;
								Tile _tile = _tileObject.GetComponent<Tile> ();
								SpriteRenderer _sprite = _tileObject.GetComponent<SpriteRenderer> ();
								_sprite.sprite = myTile;
								_tile.x = cols;
								_tile.y = rows;
								_tile.type = 1;
								if (rows == 2 && cols == 1) {
										_tile.type = 0;
										_sprite.sprite = null;
								}

								if (_tile.type == 0) {
										xIndex = cols;
										yIndex = rows;
								}
							

								_tilesBox.Add (cols.ToString () + rows.ToString (), _tileObject);
		

						}
						yOffset -= distanceBetweenTiles;
						xOffset = 0;
				}




		}

		public void checkMoveAble (int direction)
		{

				// 0: up, 1: right, 2:down, 3: left
				//Debug.Log (direction);

//		Debug.Log("Old : "+ xIndex + " " + yIndex);
		
				if (direction == 0) {
						xTempIndex = xIndex;
						yTempIndex = yIndex + 1;
						Debug.Log ("UP");
				} else if (direction == 1) {
						xTempIndex = xIndex - 1;
						yTempIndex = yIndex;
						Debug.Log ("RIGHT");
				} else if (direction == 2) {
						xTempIndex = xIndex;
						yTempIndex = yIndex - 1;
						Debug.Log ("DOWN");
				} else if (direction == 3) {
						xTempIndex = xIndex + 1;
						yTempIndex = yIndex;
						Debug.Log ("LEFT");
				}

//		Debug.Log("New : "+ xTempIndex + " " + yTempIndex);

				if (_tilesBox.ContainsKey (xTempIndex.ToString () + yTempIndex.ToString ())) {

						moveTile (xTempIndex, yTempIndex, xIndex, yIndex);
//
//						Debug.Log ("From X : " + xTempIndex + " Y : " + yTempIndex);
//						Debug.Log ("To X : " + xIndex + " Y : " + yIndex);
				}
		
		
		
		}

		void moveTile (int x1, int y1, int x2, int y2)
		{

				state = (int)State.Prepare;

				Vector3 _previousMovePosition = _tilesBox [x1.ToString () + y1.ToString ()].transform.position;
				GameObject _moveTileObject = _tilesBox [x1.ToString () + y1.ToString ()];
				GameObject _blankTileObject = _tilesBox [x2.ToString () + y2.ToString ()];
//				_moveTileObject.transform.position = _blankTileObject.transform.position;
				
				Hashtable ht = new Hashtable();
				ht.Add("x",_blankTileObject.transform.position.x);
				ht.Add("y",_blankTileObject.transform.position.y);
				ht.Add("time",0.3);
				ht.Add("onComplete","tweenComplete");
				ht.Add("onCompleteTarget",gameObject);
				iTween.MoveTo(_moveTileObject,ht);

				_blankTileObject.transform.position = _previousMovePosition;

				xIndex = x1;
				yIndex = y1;
				_tilesBox[x1.ToString () + y1.ToString ()] = _blankTileObject;
				_tilesBox[x2.ToString () + y2.ToString ()] = _moveTileObject;
		

		}

		void tweenComplete(){
//				Debug.Log("aaaa");
				state = (int)State.Ready;
		}
}

