using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	
	public GameObject tilePrefab;
	public int numberOfTiles = 16;
	public int tilesPerRow = 4;
	public float distanceBetweenTiles = 1.0f;
//	public int numberOfMines = 10;
	private Sprite myTile;
	public enum State
	{
		Ready = 1
	}



	public int state;
	private int xIndex;
	private int yIndex;

	private GameObject [,] _tiles;
//	
//	static Tile[] tilesAll;
//	static Array tilesMined;
//	static Array tilesUnmined;
	// Use this for initialization
	void Start () {
		myTile = Resources.Load("Image/tree", typeof(Sprite)) as Sprite;
		CreateTiles();
		state = (int)State.Ready;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreateTiles()
	{
//		tilesAll = new Tile[numberOfTiles];
//		tilesMined = new Array();
//		tilesUnmined = new Array();
		
		float xOffset = 0.0f;
		float yOffset = 0.0f;

		_tiles = new GameObject[4,4];
		for(int rows = 0; rows < 4 ; rows++ ){
		
			for(int cols = 0; cols < 4; cols++){

			

				xOffset += distanceBetweenTiles;

				GameObject _tileObject  =  GameObject.Instantiate( tilePrefab , new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z), transform.rotation) as GameObject;
				Tile _tile = _tileObject.GetComponent<Tile>();
				SpriteRenderer _sprite = _tileObject.GetComponent<SpriteRenderer>();
				_sprite.sprite = myTile;
				_tile.x = cols;
				_tile.y = rows;
				_tile.type = 1;
				if(rows == 0 && cols == 0){
					_tile.type = 0;
					_sprite.sprite = null;
				}

				if(_tile.type == 0){
					xIndex = cols;
					yIndex = rows;
				}
				_tiles[cols,rows] = _tileObject;


			}
			yOffset -= distanceBetweenTiles;
			xOffset = 0;
		}




	}

	public void move(int direction){
		// 0: up, 1: right, 2:down, 3: left
		Debug.Log(direction);


		GameObject _blankTile = _tiles[1,0];
		_blankTile.transform.position = new Vector3(10,10,10);

		if(direction == 0){

		}
	}
}

