using UnityEngine;
using System.Collections;

public enum TILE_TYPE {

	BLANK,
	BLOCK,
	CAPTURE,
	GOAL
}

public class LevelTile {

	public TILE_TYPE tileType;
	public GAME_COLORS tileColor;

	public int gridX;
	public int gridY;

	public LevelTile() {

		tileType = TILE_TYPE.BLANK;
		tileColor = GAME_COLORS.ALL_COLORS;
	}

	public void ParseOnlineTileData(CellContents cellData) {

		gridX = cellData.colIdx - 2;
		gridY = cellData.rowIdx - 2;

		char[] stringSeparators = new char[] {'\n'};
		string[] contents = cellData.content.Split(stringSeparators);
		tileType = this.ConvertToTileType(contents[0]);

		if(tileType == TILE_TYPE.GOAL) {

			tileColor = this.ConvertToGoalColor(contents[1]);
		}

	}

	public TILE_TYPE ConvertToTileType(string value) {

		switch(value) {

			case "T_BLOCK": 	return TILE_TYPE.BLOCK;
			case "T_CAPTURE": 	return TILE_TYPE.CAPTURE;
			case "T_GOAL":		return TILE_TYPE.GOAL;
		}

		return TILE_TYPE.BLOCK;
	}

	public GAME_COLORS ConvertToGoalColor(string value) {

		switch(value) {

			case "BLACK": 		return GAME_COLORS.BLACK;
			case "BLUE": 		return GAME_COLORS.BLUE;
			case "GREEN": 		return GAME_COLORS.GREEN;
			case "ORANGE": 		return GAME_COLORS.ORANGE;
			case "RED": 		return GAME_COLORS.RED;
			case "VIOLET": 		return GAME_COLORS.VIOLET;
			case "WHITE": 		return GAME_COLORS.WHITE;
			case "YELLOW": 		return GAME_COLORS.YELLOW;
		}
		
		return GAME_COLORS.BLACK;
	}

}
