using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Config
{

		public static int SIZE_OF_GRID = 4;
		public static int[] TYPE_LIST = new int[]{1,2,3};
		public static int SIZE_OF_BOX = 4;
		public static string STAR_OF_STATE = "STAR_OF_STATE";

	public static TileModel[] stage1 = new TileModel[]{
		new TileModel(4,0,0),
		new TileModel(4,0,1),
		new TileModel(4,0,2),
		new TileModel(4,0,3)};
	public static Dictionary<int, int[,]> boxTileStage = new Dictionary<int, int[,]> ()
	{
		{1,new [,]{{0,0},{0,1},{0,2},{0,3}}}
	};


		public const string ALARM = "Alarm";
		public const string BGM_MAIN_MENU = "BgmMainMenu";
		public const string TILE_MISSION = "TileMission";
		public const string TILE_MOVE = "TileMove";
		public const string PRESS_BUTTON = "PressButton";
		public const string OPEN_POPUP = "OpenPopup";
		public const string ERROR_MOVE = "ErrorMove";
		public const string WIN_GAME = "WinGame";
		public const string CLOSE_POPUP = "ClosePopup";
		public const string GAMEOVER = "Gameover";
		public const string GAMEPLAY_BGM = "GameplayBgm";
		public static float TIME_GAMEPLAY = 10.0F;
		public const string SOUND = "Sound/";


}
