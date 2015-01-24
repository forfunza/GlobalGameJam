using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Config {

	public static int SIZE_OF_GRID = 4;
	public static int[] TYPE_LIST = new int[]{1,2,3};


	public static string STAR_OF_STATE = "STAR_OF_STATE";
	public static Dictionary<int, TileModel[]> boxTileStage = new Dictionary<int, TileModel[]>()
	{
		{1,new TileModel[]{new TileModel(4,0,0),new TileModel(4,1,1),new TileModel(4,2,2),new TileModel(4,3,3)}},
		{2,new TileModel[]{new TileModel(4,0,0),new TileModel(4,1,1),new TileModel(4,2,2),new TileModel(4,3,3)}}
	};
}
