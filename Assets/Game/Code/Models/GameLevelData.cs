using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLevelData {

	private static GameLevelData instance = null;

	public static GameLevelData GetInstance() {

		if(instance == null) {
			instance = new GameLevelData();
		}

		return instance;
	}

	// Local Decralrations -------------------------------------------------------------
		
	private List<GameLevel> levelList;

	private GameLevelData() {

		levelList = new List<GameLevel>();
	}

	public void ParseLevelFromOnlineData(WorksheetQuery wkQuery) {

		GameLevel tmpGameLevel = new GameLevel();
		tmpGameLevel.InitLevelFromOnlineData(wkQuery);
		levelList.Add(tmpGameLevel);

		Debug.Log("Max Levels: " + levelList.Count);
	}

	public GameLevel GetGameLevel(int levelIdx) {

		if(levelIdx >= levelList.Count)
			return null;

		GameLevel gameLevel = levelList[levelIdx];
		return gameLevel;
	}
}
