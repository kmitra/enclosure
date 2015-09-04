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
		for( int i = 0; i < 1; i++) {

			sheetLink = spQuery.sheetLinks[i];
			Debug.Log(sheetLink);
			query = new WWW(sheetLink);

			yield return query;

			reader = new JsonReader(query.text, readerSettings);
			WorksheetQuery wkQuery = (WorksheetQuery) reader.Deserialize<WorksheetQuery>();

			Debug.Log("Parse Success: " + wkQuery.title);
		}


		if(spQuery != null)
			Debug.Log("Read Success!");
		else
			Debug.Log("Read Failed!");
	}
}
