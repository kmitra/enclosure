using UnityEngine;
using System.Collections;

using JsonFx.Json;

public class SampleScript : MonoBehaviour {
	

	// Use this for initialization
	void Start () {

		Debug.Log("Start");
	}

	public void onButtonClick() {

		this.StartCoroutine(this.TestQuery());
	}

	private IEnumerator TestQuery() {

		Debug.Log("TestQuery");
		WWW query = new WWW("https://spreadsheets.google.com/feeds/worksheets/1viaHzqpQBe8DIz9OAsdTHyHHl0tjxoaxOZ9UySiLesg/public/basic?alt=json");

		yield return query;
	
		JsonReaderSettings readerSettings = new JsonReaderSettings();
		readerSettings.AddTypeConverter(new SpreadsheetJsonConverter());
		readerSettings.AddTypeConverter(new WorksheetJsonConverter());

		JsonReader reader = new JsonReader(query.text, readerSettings);
		SpreadsheetQuery spQuery = (SpreadsheetQuery) reader.Deserialize<SpreadsheetQuery>();

		// No worksheet parsed.
		if(spQuery == null)
			yield break;

		int maxSheets = spQuery.sheetLinks.Count;
		string sheetLink = "";

		// parse each sheet
		for( int i = 0; i < maxSheets; i++) {

			sheetLink = spQuery.sheetLinks[i];
			Debug.Log(sheetLink);
			query = new WWW(sheetLink);

			yield return query;

			reader = new JsonReader(query.text, readerSettings);
			WorksheetQuery wkQuery = (WorksheetQuery) reader.Deserialize<WorksheetQuery>();

			spQuery.AddWorksheetQuery(wkQuery);
			Debug.Log("Parse Success: " + wkQuery.title);
		}

		if(spQuery != null)
			Debug.Log("Read Success!");
		else
			Debug.Log("Read Failed!");

		InitializeGameLevelsFromOnlineData(spQuery);
		ChangeScene();
	}

	private void InitializeGameLevelsFromOnlineData(SpreadsheetQuery spQuery) {

		int maxLevels = spQuery.GetWorksheetCount();

		// we start parsing at worksheet index 1;
		for(int i = 1; i < maxLevels; i++) {

			WorksheetQuery wkQuery = spQuery.GetWorkseetQueryAtIndex(i);
			GameLevelData.GetInstance().ParseLevelFromOnlineData(wkQuery);
		}
		 
	}

	private void ChangeScene() {

		Application.LoadLevel("Ingame");
	}
}
