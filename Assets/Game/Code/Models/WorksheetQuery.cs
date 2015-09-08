using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CellContents {

	public int rowIdx = 0;
	public int colIdx = 0;

	public string content = "";

	public CellContents(int rowIdx, int colIdx, string content) {

		this.rowIdx = rowIdx;
		this.colIdx = colIdx;
		this.content = content;
	}
}


public class WorksheetQuery {
	
	public string title;
	public List<CellContents> listCells;

	public int maxRowIndex;
	public int maxColIndex;

	public WorksheetQuery(int maxX = 10, int maxY = 10) {

		listCells = new List<CellContents>();
		maxRowIndex = 0;
		maxColIndex = 0;
	}

	public void AddCellContent(int rowIdx, int colIdx, string content) {

		CellContents cell = new CellContents(rowIdx, colIdx, content);
		listCells.Add(cell);

		if(rowIdx > maxRowIndex)
			maxRowIndex = rowIdx;

		if(colIdx > maxColIndex) 
			maxColIndex = colIdx;
	}
}