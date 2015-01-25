using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Config
{

		public static int SIZE_OF_GRID = 4;
		public static int[] TYPE_LIST = new int[]{1,2,3};
		public static int SIZE_OF_BOX = 4;
		public static string STAR_OF_STATE = "STAR_OF_STATE";
	
	public static Dictionary<int, int[,]> boxTileStage = new Dictionary<int, int[,]> ()
	{
		{1,new [,]{{0,0}}},
		{2,new [,]{{0,0},{3,0}}},
		{3,new [,]{{1,1},{2,2}}},
		{4,new [,]{{0,0},{1,1},{2,2}}},
		{5,new [,]{{0,0},{0,1},{0,2}}},
		{6,new [,]{{0,0},{0,3},{3,0}}},
		{7,new [,]{{0,0},{0,1},{0,2},{0,3}}},
		{8,new [,]{{0,0},{1,2},{2,1},{3,3}}},
		{9,new [,]{{1,1},{1,2},{2,1},{2,2},{0,0}}}
	};

	public static int[] timeGamePlay = new int[]{30,30,25,40,35,30,45,40,50};
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
		
		public const string SOUND = "Sound/";


}
