using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameEngine {

	public static List<TileModel> CheckListTileHasBroke(TileModel[,] tiles)
	{
		int tempType = 0;
		List<TileModel> tileDuplicatesTemp = new List<TileModel>();
		List<TileModel> tileDuplicates = new List<TileModel>();
		// X
		for(int i=0;i<Config.SIZE_OF_GRID;i++){
			tileDuplicatesTemp.Clear();
			tempType = 0;
			for(int j=0;j<Config.SIZE_OF_GRID;j++){
				TileModel tile = tiles[j,i] as TileModel;
				if(tile.type==tempType){
					tileDuplicatesTemp.Add(tile);
					if(j==Config.SIZE_OF_GRID-1&&tileDuplicatesTemp.Count>2){
						foreach(TileModel _tile in tileDuplicatesTemp){
							tileDuplicates.Add(_tile);
						}
					}
				}else{
					if(tileDuplicatesTemp.Count>2){
						foreach(TileModel _tile in tileDuplicatesTemp){
							tileDuplicates.Add(_tile);
						}
					}
					tileDuplicatesTemp.Clear();
					tempType = tile.type;
				}
			}
		}
		//Y
		for(int i=0;i<Config.SIZE_OF_GRID;i++){
			tileDuplicatesTemp.Clear();
			tempType = 0;
			for(int j=0;j<Config.SIZE_OF_GRID;j++){
				TileModel tile = tiles[i,j] as TileModel;
				if(tile.type==tempType){
					tileDuplicatesTemp.Add(tile);
					if(j==Config.SIZE_OF_GRID-1&&tileDuplicatesTemp.Count>2){
						foreach(TileModel _tile in tileDuplicatesTemp){
							tileDuplicates.Add(_tile);
						}
					}
				}else{
					if(tileDuplicatesTemp.Count>2){
						foreach(TileModel _tile in tileDuplicatesTemp){
							tileDuplicates.Add(_tile);
						}
					}
					tileDuplicatesTemp.Clear();
					tempType = tile.type;
				}
			}
		}
		return tileDuplicates;
	}

	public static TileModel[,] RandomTilesList(){
		TileModel[,] tiles = new TileModel[Config.SIZE_OF_GRID,Config.SIZE_OF_GRID];
		List<TileModel> tilesTemp = new List<TileModel>();
		List<int> types = new List<int>();
		int tileAllCount = Config.SIZE_OF_GRID*Config.SIZE_OF_GRID;
		int tilePlayCount = tileAllCount-1;
		int fractionTile = tilePlayCount%Config.TYPE_LIST.Length;

		for(int i=0;i<Config.SIZE_OF_GRID;i++){
			for(int j=0;j<Config.SIZE_OF_GRID;j++){
				tilesTemp.Add(new TileModel(0,j,i));
			}
		}
		for(int i=0;i<Config.TYPE_LIST.Length;i++){
			for(int j=0;j<(tilePlayCount-fractionTile)/Config.TYPE_LIST.Length;j++){
				types.Add(Config.TYPE_LIST[i]);
			}
		}
		for(int i =0;i<fractionTile;i++){
			int card = Random.Range(0,Config.TYPE_LIST.Length-1);
			types.Add(Config.TYPE_LIST[card]);
		}

		//Add Type 0
		int rndTypeZeroIndex = Random.Range(0,types.Count-1);
		TileModel tileZero = tilesTemp[rndTypeZeroIndex];
		tiles[tileZero.x,tileZero.y] = new TileModel(0,tileZero.x,tileZero.y);
		tilesTemp.RemoveAt(rndTypeZeroIndex);

		int counttimpTile = 0;
		foreach(TileModel tile_ in tilesTemp){
			tile_.type = types[counttimpTile];
			counttimpTile++;
		}
		//Add Other
		int[] randomNumbers = new int[tilesTemp.Count];
		List<TileModel> _tilesTempIndex = new List<TileModel>(tilesTemp);
		for (int i = 0; i < randomNumbers.Length; i++) {
			int thisNumber = Random.Range(0, tilesTemp.Count);
			TileModel tileOther = tilesTemp[thisNumber];
			TileModel _tileOther = _tilesTempIndex[i];
			tiles[_tileOther.x,_tileOther.y] = new TileModel(tileOther.type,_tileOther.x,_tileOther.y);
			tilesTemp.RemoveAt(thisNumber);
		}
		string logTest = "";
		for(int i=0;i<Config.SIZE_OF_GRID;i++){
			logTest+="\n";
			for(int j=0;j<Config.SIZE_OF_GRID;j++){
				TileModel tileLog = tiles[j,i];
				logTest+=" "+tileLog.type;
			}
		}
		for(int i=0;i<Config.SIZE_OF_GRID;i++){
			logTest+="\n";
			for(int j=0;j<Config.SIZE_OF_GRID;j++){
				TileModel tileLog = tiles[j,i];
				logTest+="[x:"+tileLog.x+" y:"+tileLog.y+"]";
			}
		}

		Debug.Log(logTest);
		Debug.Log("*******************************************************");
		List<TileModel> tilesCheck = CheckListTileHasBroke(tiles);
		Debug.Log("tilesCheck.Count = "+tilesCheck.Count);
		if(tilesCheck.Count>0){
			RandomTilesList();
		}

		return tiles;
	}
}
