using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Gameplay: MonoBehaviour
{
		public GameObject tilePrefab;
		public float distanceBetweenTiles = 2.0f;
		private Sprite tileTree;
		private Sprite tileFire;
		private Sprite tileOil;
		private Sprite tileDoor;
		protected int score = 0;
		protected int moveCount = 0;
		public bool isWin = false;
		public Text scoreText;
		private float countdown;
		public GameObject popupGameOver;

		public enum State
		{
				Animate = 0,
				Normal = 1,
				Check = 2,
				Lose = 3,
				Win = 4
		}

		public int state;
		private int xIndex;
		private int yIndex;
		private int xTempIndex;
		private int yTempIndex;
		private Dictionary<string,GameObject> _tiles = new Dictionary<string,GameObject> ();
		private Dictionary<string,GameObject> _boxes = new Dictionary<string,GameObject> ();
		// Use this for initialization
		void Start ()
		{	
				countdown = Config.timeGamePlay [GameEngine.Instance.gameStage - 1];
				scoreText.text = score.ToString ();
		tileTree = Resources.Load <Sprite> ("Image/UI_GamePlay/leaft");
		tileFire = Resources.Load <Sprite> ("Image/UI_GamePlay/fire");
		tileOil = Resources.Load <Sprite> ("Image/UI_GamePlay/wood");
		tileDoor = Resources.Load <Sprite> ("Image/UI_GamePlay/block_tree_new");
				
				CreateTiles ();
				state = (int)State.Normal;

			

		}
	
		// Update is called once per frame
		void Update ()
		{

				if (state == (int)State.Normal) {
						countdown -= Time.deltaTime;
						if (countdown < 0) {
								state = (int)State.Lose;
								GameObject go = (GameObject)Instantiate (popupGameOver, transform.position, transform.rotation);
								PopupGameOver popupScript = go.GetComponentInChildren<PopupGameOver> ();
								popupScript.gameOver ();
								Debug.Log ("You Lose +++++++++++++++++++");	
						}
				}
	
		}

		void CreateTiles ()
		{
		
				float xOffset = 0.0f;
				float yOffset = 0.0f;


				TileModel[,] _allTiles = GameEngine.RandomTilesListWithStage (GameEngine.Instance.gameStage);

				for (int rows = 0; rows < Config.SIZE_OF_GRID; rows++) {
		
						for (int cols = 0; cols < Config.SIZE_OF_GRID; cols++) {


								xOffset += distanceBetweenTiles;

								GameObject _tileObject = GameObject.Instantiate (tilePrefab, new Vector3 (transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z), transform.rotation) as GameObject;
								Tile _tile = _tileObject.GetComponent<Tile> ();
								SpriteRenderer _sprite = _tileObject.GetComponent<SpriteRenderer> ();
								if (_allTiles [cols, rows].type == 1)
										_sprite.sprite = tileTree;
								else if (_allTiles [cols, rows].type == 2)
										_sprite.sprite = tileFire;
								else if (_allTiles [cols, rows].type == 3)
										_sprite.sprite = tileOil;
								_tile.x = _allTiles [cols, rows].x;
								_tile.y = _allTiles [cols, rows].y;
								_tile.type = _allTiles [cols, rows].type;

								if (_tile.type == 0) {
										xIndex = _allTiles [cols, rows].x;
										yIndex = _allTiles [cols, rows].y;
										_sprite.sprite = null;
								}

								_tiles.Add (cols.ToString () + rows.ToString (), _tileObject);
						}
						yOffset -= distanceBetweenTiles;
						xOffset = 0;
				}

				int[,] boxList = Config.boxTileStage [GameEngine.Instance.gameStage];

				for (int i =0; i<=boxList.GetUpperBound(0); i++) {
						GameObject _tileObject = GameObject.Instantiate (tilePrefab, new Vector3 (_tiles [boxList [i, 0].ToString () + boxList [i, 1].ToString ()].gameObject.transform.position.x, _tiles [boxList [i, 0].ToString () + boxList [i, 1].ToString ()].gameObject.transform.position.y, transform.position.z), transform.rotation) as GameObject;
						Tile _tile = _tileObject.GetComponent<Tile> ();
						_tile.type = 4;
						SpriteRenderer _sprite = _tileObject.GetComponent<SpriteRenderer> ();
						_sprite.sprite = tileDoor;
						_boxes.Add (boxList [i, 0].ToString () + boxList [i, 1].ToString (), _tileObject);
			
				}

//				foreach (TileModel _box in _allBox) {
//				
//						GameObject _tileObject = GameObject.Instantiate (tilePrefab, new Vector3 (_tiles [_box.x.ToString () + _box.y.ToString ()].gameObject.transform.position.x, _tiles [_box.x.ToString () + _box.y.ToString ()].gameObject.transform.position.y, transform.position.z), transform.rotation) as GameObject;
//						Tile _tile = _tileObject.GetComponent<Tile> ();
//						_tile.type = _box.type;
//						SpriteRenderer _sprite = _tileObject.GetComponent<SpriteRenderer> ();
//						_sprite.sprite = tileDoor;
//						
//						_boxes.Add (_box.x.ToString () + _box.y.ToString (), _tileObject);
//
//				}

		}

		public void checkMoveAble (int direction)
		{
				
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



				if (_tiles.ContainsKey (xTempIndex.ToString () + yTempIndex.ToString ())) {

						moveTile (xTempIndex, yTempIndex, xIndex, yIndex);

				}
		
		
		
		}

		void moveTile (int x1, int y1, int x2, int y2)
		{

				state = (int)State.Animate;

				Vector3 _previousMovePosition = _tiles [x1.ToString () + y1.ToString ()].transform.position;
				GameObject _moveTileObject = _tiles [x1.ToString () + y1.ToString ()];
				GameObject _blankTileObject = _tiles [x2.ToString () + y2.ToString ()];
//				_moveTileObject.transform.position = _blankTileObject.transform.position;
				
				Hashtable ht = new Hashtable ();
				ht.Add ("x", _blankTileObject.transform.position.x);
				ht.Add ("y", _blankTileObject.transform.position.y);
				ht.Add ("time", 0.3);
				ht.Add ("onComplete", "tweenComplete");
				ht.Add ("onCompleteTarget", gameObject);
				iTween.MoveTo (_moveTileObject, ht);

				_blankTileObject.transform.position = _previousMovePosition;

				xIndex = x1;
				yIndex = y1;
				_tiles [x1.ToString () + y1.ToString ()] = _blankTileObject;
				_tiles [x2.ToString () + y2.ToString ()] = _moveTileObject;
				moveCount++;
				checkTileInBox ();
		

		}

		void checkTileInBox ()
		{
				state = (int)State.Check;
				score = 0;
				for (int rows = 0; rows < Config.SIZE_OF_GRID; rows++) {
			
						for (int cols = 0; cols < Config.SIZE_OF_GRID; cols++) {
								Tile _checkTile = _tiles [cols.ToString () + rows.ToString ()].GetComponent<Tile> ();
								if (_checkTile.type == 1) {
										if (_boxes.ContainsKey (cols.ToString () + rows.ToString ()))
												score++;
								}


						}
				}
				state = (int)State.Normal;
				scoreText.text = score.ToString ();
				if (score == Config.SIZE_OF_BOX) {
						state = (int)State.Win;
						isWin = true;
						GameObject go = (GameObject)Instantiate (popupGameOver, transform.position, transform.rotation);
						PopupGameOver popupScript = go.GetComponentInChildren<PopupGameOver> ();
						popupScript.gameWin (getStarFromTime (countdown));
						//add nextStage
						if (!PlayerPrefs.HasKey (Config.STAR_OF_STATE + (GameEngine.Instance.gameStage + 1))) {
								PlayerPrefs.SetInt (Config.STAR_OF_STATE + (GameEngine.Instance.gameStage + 1), 0);
								PlayerPrefs.Save ();
						}
						//add star
						if (getStarFromTime (countdown) > PlayerPrefs.GetInt (Config.STAR_OF_STATE + (GameEngine.Instance.gameStage))) {
								PlayerPrefs.SetInt (Config.STAR_OF_STATE + GameEngine.Instance.gameStage, getStarFromTime (countdown));
								PlayerPrefs.Save ();
						}

						Debug.Log ("You Win +++++++++++++++++++++");
				}
				
				
		}

		private int getStarFromTime (float time)
		{
				int star = 0;
				int maxTime = Config.timeGamePlay [GameEngine.Instance.gameStage - 1];
				int percentage = (int)time * 100 / maxTime;
				if (percentage > 60) {
						star = 3;
				} else if (percentage > 40) {
						star = 2;
				} else if (percentage > 20) {
						star = 1;
				}
				return star;
		}

		void tweenComplete ()
		{
//				Debug.Log("aaaa");
				state = (int)State.Normal;
		}

		public float GetTimeLeft {
				get {
						return countdown;
				}
		}
}

