using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gameplay: MonoBehaviour
{
		public GameObject tilePrefab;
		public float distanceBetweenTiles = 1.0f;
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
		private Dictionary<string,GameObject> _tilesBox = new Dictionary<string,GameObject> ();

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
		
				float xOffset = 0.0f;
				float yOffset = 0.0f;


				TileModel[,] _allTiles = GameEngine.RandomTilesList ();

				for (int rows = 0; rows < Config.SIZE_OF_GRID; rows++) {
		
						for (int cols = 0; cols < Config.SIZE_OF_GRID; cols++) {

								Debug.Log (_allTiles [cols, rows]);

								xOffset += distanceBetweenTiles;

								GameObject _tileObject = GameObject.Instantiate (tilePrefab, new Vector3 (transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z), transform.rotation) as GameObject;
								Tile _tile = _tileObject.GetComponent<Tile> ();
								SpriteRenderer _sprite = _tileObject.GetComponent<SpriteRenderer> ();
								_sprite.sprite = myTile;
								_tile.x = _allTiles [cols, rows].x;
								_tile.y = _allTiles [cols, rows].y;
								_tile.type = _allTiles [cols, rows].type;

								if (_tile.type == 0) {
										xIndex = _allTiles [cols, rows].x;
										yIndex = _allTiles [cols, rows].y;
					_sprite.sprite = null;
								}

								_tilesBox.Add (cols.ToString () + rows.ToString (), _tileObject);
						}
						yOffset -= distanceBetweenTiles;
						xOffset = 0;
				}

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



				if (_tilesBox.ContainsKey (xTempIndex.ToString () + yTempIndex.ToString ())) {

						moveTile (xTempIndex, yTempIndex, xIndex, yIndex);

				}
		
		
		
		}

		void moveTile (int x1, int y1, int x2, int y2)
		{

				state = (int)State.Prepare;

				Vector3 _previousMovePosition = _tilesBox [x1.ToString () + y1.ToString ()].transform.position;
				GameObject _moveTileObject = _tilesBox [x1.ToString () + y1.ToString ()];
				GameObject _blankTileObject = _tilesBox [x2.ToString () + y2.ToString ()];
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
				_tilesBox [x1.ToString () + y1.ToString ()] = _blankTileObject;
				_tilesBox [x2.ToString () + y2.ToString ()] = _moveTileObject;
		

		}

		void tweenComplete ()
		{
//				Debug.Log("aaaa");
				state = (int)State.Ready;
		}
}

