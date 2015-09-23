using UnityEngine;
using System.Collections;

public class IngameUtils {

	private static IngameUtils instance = null;

	public static IngameUtils GetInstance() {

		if(instance == null) {
			instance = new IngameUtils();
		}

		return instance;
	}


	// Local Implementations ---------------------------------------------------------------------------------------

	public float tileStartPosX = 0;
	public float tileStartPosY = 0;

	public float speedHoriz = 10; 		// seconds

	private IngameUtils() {

		// Constructor
	}

	public void CalculateStartPositions(int maxRow, int maxCol) {
		
		this.tileStartPosX = (maxCol - 1) * (GameConstants.MAX_TILE_WIDTH) * 0.5f * -1;
		this.tileStartPosX = this.tileStartPosX - (GameConstants.TILE_SPACING * (maxCol - 1) * 0.5f);
		
		/*this.tileStartPosY = maxRow * (GameConstants.MAX_TILE_HEIGHT + GameConstants.TILE_SPACING);
		this.tileStartPosY = this.tileStartPosY - (GameConstants.MAX_TILE_HEIGHT * (maxRow % 2) * 0.5f);
		this.tileStartPosY = this.tileStartPosY - (GameConstants.TILE_SPACING * (maxRow - 1) * 0.5f);
		this.tileStartPosY = (this.tileStartPosY * 0.5f);*/

		this.tileStartPosY = (maxRow - 1) * (GameConstants.MAX_TILE_HEIGHT * 0.5f);
		this.tileStartPosY = this.tileStartPosY + (GameConstants.TILE_SPACING * (maxRow - 1) * 0.5f);
	}

	public float GetStreamStartPositionFromLine(int lineNumber, bool isHorizontal) {

		lineNumber = lineNumber - 1; // not zero indexed
		float startPosition = 0;

		if(isHorizontal) {

			startPosition = tileStartPosY - ((GameConstants.MAX_TILE_HEIGHT + GameConstants.TILE_SPACING) * 0.5f);
			//startPosition = startPosition + ((GameConstants.MAX_TILE_HEIGHT + GameConstants.TILE_SPACING) * lineNumber);
		}
		else {

			//startPosition = tileStartPosX - ((GameConstants.MAX_TILE_WIDTH + GameConstants.TILE_SPACING) * 0.5f);
			//startPosition = startPosition + ((GameConstants.MAX_TILE_WIDTH + GameConstants.TILE_SPACING) * lineNumber);
		}

		return startPosition;
	}
}
