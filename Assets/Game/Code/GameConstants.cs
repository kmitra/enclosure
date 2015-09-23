using UnityEngine;
using System.Collections;

public class GameConstants {

	public const int MAX_TILE_WIDTH = 100;
	public const int MAX_TILE_HEIGHT = 100;
	public const int TILE_SPACING = 50;

	public const float EDGE_LEFT = -1000;
	public const float EDGE_RIGHT = 1000;
	public const float EDGE_TOP = 700;
	public const float EDGE_DOWN = -700;

	public static Color GetColor(GAME_COLORS gameColor) {

		Color outputColor = Color.cyan;
		Color.TryParseHexString("#000000", out outputColor);

		switch(gameColor) {

		case GAME_COLORS.BLACK:		Color.TryParseHexString("#000000", out outputColor); break;
		case GAME_COLORS.BLUE:		Color.TryParseHexString("#0099ff", out outputColor); break;
		case GAME_COLORS.GREEN:		Color.TryParseHexString("#33cc00", out outputColor); break;
		case GAME_COLORS.ORANGE:	Color.TryParseHexString("#ff9900", out outputColor); break;
		case GAME_COLORS.RED:		Color.TryParseHexString("#ff3300", out outputColor); break;
		case GAME_COLORS.VIOLET:	Color.TryParseHexString("#9900ff", out outputColor); break;
		case GAME_COLORS.WHITE:		Color.TryParseHexString("#ffffff", out outputColor); break;
		case GAME_COLORS.YELLOW:	Color.TryParseHexString("#ffff00", out outputColor); break;
		}

		return outputColor;
	}
}
