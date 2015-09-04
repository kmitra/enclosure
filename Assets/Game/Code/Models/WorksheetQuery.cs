using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorksheetQuery {
	
	public string title;
	private Dictionary<string, string> cellContents;
	
	public WorksheetQuery(int maxX = 10, int maxY = 10) {

		cellContents = new Dictionary<string, string>();
	}

	public void AddCellContent(string key, string value) {

		cellContents.Add(key, value);
	}
}