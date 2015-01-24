using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameEngine
{

		public static List<TileModel> CheckListTileHasBroke (TileModel[,] tiles)
		{
				int tempType = 0;
				List<TileModel> tileDuplicatesTemp = new List<TileModel> ();
				List<TileModel> tileDuplicates = new List<TileModel> ();
				// X
				for (int i=0; i<Config.SIZE_OF_GRID; i++) {
						tileDuplicatesTemp.Clear ();
						tempType = 0;
						for (int j=0; j<Config.SIZE_OF_GRID; j++) {
								TileModel tile = tiles [j, i] as TileModel;
								tileDuplicatesTemp.Add (tile);
								if (tile.type == tempType) {
										if (j == Config.SIZE_OF_GRID - 1 && tileDuplicatesTemp.Count > 2) {
												foreach (TileModel _tile in tileDuplicatesTemp) {
														tileDuplicates.Add (_tile);
												}
										}
								} else {
										if (tileDuplicatesTemp.Count > 1 && tileDuplicatesTemp.Count < 3)
												tileDuplicatesTemp.RemoveAt (0);
										if (tileDuplicatesTemp.Count > 2) {
												tileDuplicatesTemp.RemoveAt (tileDuplicatesTemp.Count - 1);
												foreach (TileModel _tile in tileDuplicatesTemp) {
														tileDuplicates.Add (_tile);
												}
												tileDuplicatesTemp.Clear ();
										}
										if (tileDuplicatesTemp.Count > 1)
												tileDuplicatesTemp.Clear ();
										tempType = tile.type;
								}
						}
				}
				//Y
				for (int i=0; i<Config.SIZE_OF_GRID; i++) {
						tileDuplicatesTemp.Clear ();
						tempType = 0;
						for (int j=0; j<Config.SIZE_OF_GRID; j++) {
								TileModel tile = tiles [i, j] as TileModel;
								tileDuplicatesTemp.Add (tile);
								if (tile.type == tempType) {
										if (i == Config.SIZE_OF_GRID - 1 && tileDuplicatesTemp.Count > 2) {
												foreach (TileModel _tile in tileDuplicatesTemp) {
														tileDuplicates.Add (_tile);
												}
										}
								} else {
										if (tileDuplicatesTemp.Count > 1 && tileDuplicatesTemp.Count < 3)
												tileDuplicatesTemp.RemoveAt (0);
										if (tileDuplicatesTemp.Count > 2) {
												tileDuplicatesTemp.RemoveAt (tileDuplicatesTemp.Count - 1);
												foreach (TileModel _tile in tileDuplicatesTemp) {
														tileDuplicates.Add (_tile);
												}
												tileDuplicatesTemp.Clear ();
										}
										if (tileDuplicatesTemp.Count > 1)
												tileDuplicatesTemp.Clear ();
										tempType = tile.type;
								}
						}
				}
				foreach (TileModel _tile in tileDuplicates) {
						Debug.Log (_tile.type);
				}
				return tileDuplicates;
		}

		public static TileModel[,] RandomTilesList ()
		{
				TileModel[,] tiles = new TileModel[Config.SIZE_OF_GRID, Config.SIZE_OF_GRID];
				List<TileModel> tilesTemp = new List<TileModel> ();
				List<int> types = new List<int> ();
				int tileAllCount = Config.SIZE_OF_GRID * Config.SIZE_OF_GRID;
				int tilePlayCount = tileAllCount - 1;
				int fractionTile = tilePlayCount % Config.TYPE_LIST.Length;

				for (int i=0; i<Config.SIZE_OF_GRID; i++) {
						for (int j=0; j<Config.SIZE_OF_GRID; j++) {
								tilesTemp.Add (new TileModel (0, j, i));
						}
				}
				for (int i=0; i<Config.TYPE_LIST.Length; i++) {
						for (int j=0; j<(tilePlayCount-fractionTile)/Config.TYPE_LIST.Length; j++) {
								types.Add (Config.TYPE_LIST [i]);
						}
				}
				for (int i =0; i<fractionTile; i++) {
						int card = Random.Range (0, Config.TYPE_LIST.Length - 1);
						types.Add (Config.TYPE_LIST [card]);
				}

				//Add Type 0
				int rndTypeZeroIndex = Random.Range (0, types.Count - 1);
				TileModel tileZero = tilesTemp [rndTypeZeroIndex];
				tiles [tileZero.x, tileZero.y] = new TileModel (0, tileZero.x, tileZero.y);
				tilesTemp.RemoveAt (rndTypeZeroIndex);

				int counttimpTile = 0;
				foreach (TileModel tile_ in tilesTemp) {
						tile_.type = types [counttimpTile];
						counttimpTile++;
				}
				//Add Other
				int[] randomNumbers = new int[tilesTemp.Count];
				List<TileModel> _tilesTempIndex = new List<TileModel> (tilesTemp);
				for (int i = 0; i < randomNumbers.Length; i++) {
						int thisNumber = Random.Range (0, tilesTemp.Count);
						TileModel tileOther = tilesTemp [thisNumber];
						TileModel _tileOther = _tilesTempIndex [i];
						tiles [_tileOther.x, _tileOther.y] = new TileModel (tileOther.type, _tileOther.x, _tileOther.y);
						tilesTemp.RemoveAt (thisNumber);
				}
				string logTest = "";
				for (int i=0; i<Config.SIZE_OF_GRID; i++) {
						logTest += "\n";
						for (int j=0; j<Config.SIZE_OF_GRID; j++) {
								TileModel tileLog = tiles [j, i];
								logTest += " " + tileLog.type;
						}
				}
				for (int i=0; i<Config.SIZE_OF_GRID; i++) {
						logTest += "\n";
						for (int j=0; j<Config.SIZE_OF_GRID; j++) {
								TileModel tileLog = tiles [j, i];  
								logTest += "[x:" + tileLog.x + " y:" + tileLog.y + "]";
						}
				}

				Debug.Log (logTest);
				return tiles;
		}

		public static List<TileModel> RandomBox (int numBox)
		{                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
				List<TileModel> listBox = new List<TileModel> ();
				List<TileModel> listBoxTemp = new List<TileModel> ();
				for (int i=0; i<Config.SIZE_OF_GRID; i++) {
						for (int j=0; j<Config.SIZE_OF_GRID; j++) {
								listBoxTemp.Add (new TileModel (0, j, i));
						}
				}

				int[] randomNumbers = new int[numBox];
				for (int i = 0; i < randomNumbers.Length; i++) {
						int thisNumber = Random.Range (0, listBoxTemp.Count);
						TileModel tileOther = listBoxTemp [thisNumber];
						listBox.Add (new TileModel (tileOther.type, tileOther.x, tileOther.y));
						listBoxTemp.RemoveAt (thisNumber);
				}
				foreach (TileModel tileModel_ in listBox) {
						Debug.Log ("X : " + tileModel_.x + ",Y : " + tileModel_.y);
				}
				return listBox;
		}

		public static TileModel[,] RandomTilesListWithStage (int stage)
		{
				int[,] tileStageList = Config.boxTileStage [stage];
				TileModel[,] tiles = new TileModel[Config.SIZE_OF_GRID, Config.SIZE_OF_GRID];
				List<TileModel> tilesTemp = new List<TileModel> ();
				List<int> types = new List<int> ();
				int tileAllCount = Config.SIZE_OF_GRID * Config.SIZE_OF_GRID;
				int tilePlayCount = tileAllCount - 1;
				int fractionTile = tilePlayCount % Config.TYPE_LIST.Length;
		
				for (int i=0; i<Config.SIZE_OF_GRID; i++) {
						for (int j=0; j<Config.SIZE_OF_GRID; j++) {
								tilesTemp.Add (new TileModel (0, j, i));
						}
				}
				for (int i=0; i<Config.TYPE_LIST.Length; i++) {
						for (int j=0; j<(tilePlayCount-fractionTile)/Config.TYPE_LIST.Length; j++) {
								types.Add (Config.TYPE_LIST [i]);
						}
				}
				for (int i =0; i<fractionTile; i++) {
						int card = Random.Range (0, Config.TYPE_LIST.Length - 1);
						types.Add (Config.TYPE_LIST [card]);
				}
		
				//Add Type 0
				int rndTypeZeroIndex = Random.Range (0, types.Count - 1);
				TileModel tileZero = tilesTemp [rndTypeZeroIndex];
				tiles [tileZero.x, tileZero.y] = new TileModel (0, tileZero.x, tileZero.y);
				tilesTemp.RemoveAt (rndTypeZeroIndex);
		
				int counttimpTile = 0;
				foreach (TileModel tile_ in tilesTemp) {
						tile_.type = types [counttimpTile];
						counttimpTile++;
				}
//				//Add random
//				foreach (int tilestage in tileStageList) {
				for (int i = 0; i<=tileStageList.GetUpperBound(0); i++) {
						int[] randomNumberStages = new int[tilesTemp.Count];
						List<TileModel> _tilesTempStageIndex = new List<TileModel> (tilesTemp);
						for (int l = 0; l < randomNumberStages.Length; l++) {
								int thisNumber = Random.Range (0, tilesTemp.Count);
								TileModel tileOther = tilesTemp [thisNumber];
								TileModel _tileOther = _tilesTempStageIndex [l];
								if (tileOther.type != 1) {
										if (tileZero.x == tileStageList [i, 0] && tileZero.y == tileStageList [i, 1])
												break;
										tiles [tileStageList [i, 0], tileStageList [i, 1]] = new TileModel (tileOther.type, tileStageList [i, 0], tileStageList [i, 1]);

										int k = 0;
										foreach (TileModel tiledump in _tilesTempStageIndex) {
												if (tiledump.x == tileStageList [i, 0] && tiledump.y == tileStageList [i, 1]) {
														if (tiledump.type == 1) {
																foreach (TileModel tiledump_ in tilesTemp) {
																		if (tiledump_.x == tileOther.x && tiledump_.y == tileOther.y) {
																				tiledump_.type = 1;
																				break;
																		}
																}
														}
														tilesTemp.RemoveAt (k);
														break;
												}
												k++;
										}
									
										
										break;
								}
						}
				}
				//Add Other
				int[] randomNumbers = new int[tilesTemp.Count];
				List<TileModel> _tilesTempIndex = new List<TileModel> (tilesTemp);
				for (int i = 0; i < randomNumbers.Length; i++) {
						int thisNumber = Random.Range (0, tilesTemp.Count);
						TileModel tileOther = tilesTemp [thisNumber];
						TileModel _tileOther = _tilesTempIndex [i];
						tiles [_tileOther.x, _tileOther.y] = new TileModel (tileOther.type, _tileOther.x, _tileOther.y);
						tilesTemp.RemoveAt (thisNumber);
				}

				string logTest = "";
				for (int i=0; i<Config.SIZE_OF_GRID; i++) {
						logTest += "\n";
						for (int j=0; j<Config.SIZE_OF_GRID; j++) {
								TileModel tileLog = tiles [j, i];
								logTest += " " + tileLog.type;
						}
				}
				for (int i=0; i<Config.SIZE_OF_GRID; i++) {
						logTest += "\n";
						for (int j=0; j<Config.SIZE_OF_GRID; j++) {
								TileModel tileLog = tiles [j, i];  
								logTest += "[x:" + tileLog.x + " y:" + tileLog.y + "]";
						}
				}
		
				Debug.Log (logTest);
				return tiles;
		}
}