using UnityEngine;
using System.Collections;

public class ColorStream {

	public GAME_COLORS streamColor;
	public MOVE_DIRECTION direction;
	public int startingLine;

	public ColorStream() {

		streamColor = GAME_COLORS.ALL_COLORS;
		direction = MOVE_DIRECTION.MOVE_RIGHT;
		startingLine = 0;
	}

	public void ParseOnlineStreamData(CellContents cellData) {

		char[] stringSeparators = new char[] {'\n'};
		string[] contents = cellData.content.Split(stringSeparators);

		this.streamColor = ConvertToStreamColor(contents[0]);
		this.direction = ConvertToMoveDirection(contents[1]);

		if(this.IsDirectionVertical()) {
			this.startingLine = cellData.colIdx;
		}
		else if (this.IsDirectionHorizontal()) {
			this.startingLine = cellData.rowIdx;
		}
	}

	private GAME_COLORS ConvertToStreamColor(string value) {

		switch(value)
		{
			case "S_BLACK": 	return GAME_COLORS.BLACK;
			case "S_BLUE": 		return GAME_COLORS.BLUE;
			case "S_GREEN": 	return GAME_COLORS.GREEN;
			case "S_ORANGE": 	return GAME_COLORS.ORANGE;
			case "S_RED": 		return GAME_COLORS.RED;
			case "S_VIOLET": 	return GAME_COLORS.VIOLET;
			case "S_WHITE": 	return GAME_COLORS.WHITE;
			case "S_YELLOW": 	return GAME_COLORS.YELLOW;
		}
		
		return GAME_COLORS.ALL_COLORS;
	}

	private MOVE_DIRECTION ConvertToMoveDirection(string value) {

		switch(value) {

			case "MOVE_RIGHT": 		return MOVE_DIRECTION.MOVE_RIGHT;
			case "MOVE_LEFT": 		return MOVE_DIRECTION.MOVE_LEFT;
			case "MOVE_UP": 		return MOVE_DIRECTION.MOVE_UP;
			case "MOVE_DOWN": 		return MOVE_DIRECTION.MOVE_DOWN;
		}

		return MOVE_DIRECTION.MOVE_RIGHT;
	}

	public bool IsDirectionVertical() {

		bool result =  (this.direction == MOVE_DIRECTION.MOVE_DOWN
		                || this.direction == MOVE_DIRECTION.MOVE_UP);
		return result;
	}

	public bool IsDirectionHorizontal() {

		bool result = (this.direction == MOVE_DIRECTION.MOVE_LEFT
		               || this.direction == MOVE_DIRECTION.MOVE_RIGHT);
		return result;
	}
}
