using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpreadsheetQuery {

	public string title;
	public List<string> sheetLinks;
	private List<WorksheetQuery> worksheets;

	public SpreadsheetQuery() {

		sheetLinks = new List<string>();
		worksheets = new List<WorksheetQuery>();
	}

	public void AddWorksheetQuery(WorksheetQuery wkQuery) {

		worksheets.Add(wkQuery);
	}

	public int GetWorksheetCount() {
		return worksheets.Count;
	}

	public WorksheetQuery GetWorkseetQueryAtIndex(int idx) {

		WorksheetQuery wkQuery = worksheets[idx];
		return wkQuery;
	}
}
