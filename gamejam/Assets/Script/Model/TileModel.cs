using UnityEngine;
using System.Collections;

public class TileModel {
	public int type;
	public int x;
	public int y;
	public TileModel(int type = 0,int x = 0,int y = 0){
		this.type = type;
		this.x = x;
		this.y = y;
	}
}
