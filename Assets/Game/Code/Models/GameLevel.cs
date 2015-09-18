using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GAME_COLORS {

	BLACK,
	BLUE,
	GREEN,
	ORANGE,
	RED,
	VIOLET,
	WHITE,
	YELLOW,
	ALL_COLORS
}

public enum MOVE_DIRECTION {

	MOVE_LEFT,
	MOVE_RIGHT,
	MOVE_UP,
	MOVE_DOWN
}


public class GameLevel {

	// goal color
	// tile types
	// color streams

	public List<LevelTile> listTile;
	public List<ColorStream> listColorStream;

	public int maxRow = 0;
	public int maxCol = 0;

	public GameLevel() {

		listTile = new List<LevelTile>();
		listColorStream = new List<ColorStream>();
	}

	public void InitLevelFromOnlineData(WorksheetQuery wkQuery) {

		int maxCount = wkQuery.listCells.Count;

		for(int i = 0; i < maxCount; i++) {

			CellContents cell = wkQuery.listCells[i];
		
			if(cell.content.IndexOf("T_") == 0) {
			
				// if cell content is Tile, create new tile.
				LevelTile levelTile = new LevelTile();
				levelTile.ParseOnlineTileData(cell);
				listTile.Add(levelTile);

				if(levelTile.gridX > maxCol)
					maxCol = levelTile.gridX;
				
				if(levelTile.gridY > maxRow)
					maxRow = levelTile.gridY;
			}
			else if(cell.content.IndexOf("S_") == 0) {

				// if cell content is stream, create new color stream
				ColorStream colorStream = new ColorStream();
				colorStream.ParseOnlineStreamData(cell);
				listColorStream.Add(colorStream);
			}
		}

		if(maxRow > 0) 
			maxRow = maxRow + 1;

		if(maxCol > 0)
			maxCol = maxCol + 1;
	}
}
