using UnityEngine;
using System.Collections;

public class PlayerSession {

	private static PlayerSession instance = null;

	public static PlayerSession GetInstance() {

		if(instance == null) {
			instance = new PlayerSession();
		}

		return instance;
	}

	// Local Implementations ----------------------------------------------------

	public int selectedLevel = 0;
	public int farthestLevel = 0;


	private PlayerSession() {

		selectedLevel = 0;
		farthestLevel = 0;
	}
}
