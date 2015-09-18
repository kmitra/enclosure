using UnityEngine;
using System.Collections;

public class CoreGameController : MonoBehaviour {

	[SerializeField]
	public GameObject parentGameTiles;

	[SerializeField]
	public GameObject tileGameObject;

	private float startPosX = 0;
	private float startPosY = 0;

	// Use this for initialization
	void Start () {
	
	}

	void OnLevelWasLoaded() {

		InitializeLevelTiles();
	}
	
	// Initialization -------------------------------------------


	// Creates Tile prefabs by reading the GameLevel Data
	private void InitializeLevelTiles() {

		int selectedLevel = PlayerSession.GetInstance().selectedLevel;
		GameLevel gameLevel = GameLevelData.GetInstance().GetGameLevel(selectedLevel);

		int maxRow = gameLevel.maxRow;
		int maxCol = gameLevel.maxCol;
		Debug.Log("Row: " + maxRow + " Col:" + maxCol);

		this.CalculateStartPositions(maxRow, maxCol);

		int maxTileCount = gameLevel.listTile.Count;
		for(int i = 0; i < maxTileCount; i++) {

			LevelTile tmpLevelTile = gameLevel.listTile[i];
			GameObject tmpTile = Instantiate(tileGameObject, Vector3.zero, Quaternion.identity) as GameObject;
			tmpTile.transform.parent = parentGameTiles.transform;
			tmpTile.transform.localPosition = new Vector3(this.startPosX + tmpLevelTile.gridX * 150, 
			                                              this.startPosY + tmpLevelTile.gridY * 150);
		}
	}

	private void CalculateStartPositions(int maxRow, int maxCol) {
		 
		this.startPosX = maxCol * (GameConstants.MAX_TILE_WIDTH + GameConstants.TILE_SPACING);
		this.startPosX = this.startPosX - GameConstants.TILE_SPACING + (GameConstants.MAX_TILE_WIDTH * 0.5f);
		this.startPosX = 0 - (this.startPosX * 0.5f);

		this.startPosY = maxRow * (GameConstants.MAX_TILE_HEIGHT + GameConstants.TILE_SPACING);
		this.startPosY = this.startPosY - (GameConstants.MAX_TILE_HEIGHT * 0.5f) + GameConstants.TILE_SPACING;
		this.startPosY = 0 - (this.startPosY * 0.5f);
	}
}
