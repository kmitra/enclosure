using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoreGameController : MonoBehaviour {

	[SerializeField]
	public GameObject parentGameTiles;

	[SerializeField]
	public GameObject parentColorStreams;

	[SerializeField]
	public GameObject tileGameObject;

	[SerializeField]
	public GameObject captureTileGameObject;

	[SerializeField]
	public GameObject goalTileObject;

	[SerializeField]
	public GameObject colorStreamObject;

	private GameLevel gameLevel = null;
	private float startPosX = 0;
	private float startPosY = 0;

	public List<ColorStreamController> listColorStreamControllers;

	// Use this for initialization
	void Start () {
	
	}

	void OnLevelWasLoaded() {

		int selectedLevel = PlayerSession.GetInstance().selectedLevel;
		this.gameLevel = GameLevelData.GetInstance().GetGameLevel(selectedLevel);
		
		int maxRow = this.gameLevel.maxRow;
		int maxCol = this.gameLevel.maxCol;
		Debug.Log("Row: " + maxRow + " Col:" + maxCol);
		
		IngameUtils.GetInstance().CalculateStartPositions(maxRow, maxCol);
		this.startPosX = IngameUtils.GetInstance().tileStartPosX;
		this.startPosY = IngameUtils.GetInstance().tileStartPosY;

		InitializeLevelTiles();
		InitializeColorStreams();
	}
	
	// Initialization -------------------------------------------


	// Creates Tile prefabs by reading the GameLevel Data
	private void InitializeLevelTiles() {

		int maxTileCount = gameLevel.listTile.Count;
		for(int i = 0; i < maxTileCount; i++) {

			LevelTile tmpLevelTile = gameLevel.listTile[i];

			// determine if tile type
			GameObject tmpTile = null;
			switch(tmpLevelTile.tileType) {

			case TILE_TYPE.CAPTURE:
				tmpTile = InstantiateCaptureTile(tmpLevelTile); break;

			case TILE_TYPE.GOAL:
				tmpTile = InstantiateGoalTile(tmpLevelTile); break;

			case TILE_TYPE.BLOCK:
				tmpTile = InstantiateBlockTile(tmpLevelTile); break;
			
			case TILE_TYPE.BLANK:
				Debug.Assert(false, "Blank Tile Types should not exist when instantiating tile prefabs. Check level data and try again.");
				break;
			}

			tmpTile.transform.parent = parentGameTiles.transform;
			tmpTile.transform.localPosition = new Vector3(this.startPosX + (tmpLevelTile.gridX * (GameConstants.MAX_TILE_WIDTH + GameConstants.TILE_SPACING)), 
			                                              this.startPosY - (tmpLevelTile.gridY * (GameConstants.MAX_TILE_HEIGHT + GameConstants.TILE_SPACING)));
		}
	}

	private GameObject InstantiateBlockTile(LevelTile LevelTile) {

		GameObject tmpTile = Instantiate(tileGameObject, Vector3.zero, Quaternion.identity) as GameObject;
		return tmpTile;
	}

	private GameObject InstantiateCaptureTile(LevelTile levelTile) {

		GameObject tmpTile = Instantiate(captureTileGameObject, Vector3.zero, Quaternion.identity) as GameObject;
		return tmpTile;
	}

	private GameObject InstantiateGoalTile(LevelTile levelTile) {

		GameObject tmpTile = Instantiate(captureTileGameObject, Vector3.zero, Quaternion.identity) as GameObject;
		SpriteRenderer sprRenderer = tmpTile.GetComponent<SpriteRenderer>();
		sprRenderer.color = GameConstants.GetColor(levelTile.tileColor);

		return tmpTile;
	}

	private void InitializeColorStreams() {

		listColorStreamControllers = new List<ColorStreamController>();

		int maxStreamCount = gameLevel.listColorStream.Count;
		for(int i = 0; i < maxStreamCount; i++) {

			ColorStream colorStream = gameLevel.listColorStream[i];
			GameObject colorStreamObj = Instantiate(colorStreamObject, Vector3.zero, Quaternion.identity) as GameObject;
			colorStreamObj.transform.parent = parentColorStreams.transform;

			ColorStreamController clrStreamController = colorStreamObj.GetComponent<ColorStreamController>();
			clrStreamController.SetColorStreamData(colorStream);
			clrStreamController.StartMoving();
			listColorStreamControllers.Add(clrStreamController);
		}

	}
}












































