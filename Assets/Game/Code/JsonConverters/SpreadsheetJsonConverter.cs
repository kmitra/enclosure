using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

using JsonFx.Json;

public class SpreadsheetJsonConverter : JsonConverter {

	public override bool CanConvert (Type t) {

		return t == typeof(SpreadsheetQuery);
	}

	public override Dictionary<string,object> WriteJson (Type type, object value) {

		return null;
	}

	public override object ReadJson (Type type, Dictionary<string,object> value) {
		
		Dictionary<string,object> genObject; // generic object used to read json info
		Dictionary<string,object>[] genObjArray; 
		SpreadsheetQuery spQuery = new SpreadsheetQuery();
		
		try {
			
			Dictionary<string,object> feedDict = value["feed"] as Dictionary<string,object>;
			genObject = feedDict["title"] as Dictionary<string,object>;
			spQuery.title = genObject["$t"] as String;
			
			Dictionary<string,object>[] entryArray = feedDict["entry"] as Dictionary<string,object>[];
			genObject = entryArray[0]["title"] as Dictionary<string,object>;
			
			int maxEntries = entryArray.Length;
			for(int i = 0; i < maxEntries; i++) {
				
				genObjArray = entryArray[i]["link"] as Dictionary<string,object>[];
				
				// cell feed link at idx 1
				genObject = genObjArray[1] as Dictionary<string, object>;
				spQuery.sheetLinks.Add(genObject["href"] + "?alt=json");
			}
		}
		catch(Exception ex) {
			
			Debug.LogError("SpreadsheetJsonConverter: Error deserializing json. \nError: " + ex.Message);
			return null; 
		}
		
		return spQuery;
	}
}
