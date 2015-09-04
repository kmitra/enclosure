using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpreadsheetQuery {

	public string title;
	public List<string> sheetLinks;
	private List<WorksheetQuery> worksheets;

	public SpreadsheetQuery() {

		sheetLinks = new List<string>();
	}

	public void AddWorksheetQuery(WorksheetQuery wkQuery) {

		worksheets.Add(wkQuery);
	}
}
