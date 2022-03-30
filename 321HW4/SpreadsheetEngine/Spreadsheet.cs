// <copyright file="Spreadsheet.cs" company="Linh Stitsel">
// Copyright (c) Linh Stitsel. All rights reserved.
// </copyright>
namespace CptS321
{
    using System.ComponentModel;

    /// <summary>
    /// The spreadsheet class thats consists of a 2D array spreadsheet made up of cell objects.
    /// </summary>
    public class Spreadsheet
    {
        private readonly Cell[,] spreadsheetArray; // new spreadsheet array

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="numRows">Number of rows in the sheet.</param>
        /// <param name="numCols"> Number of columns in the sheet.</param>
        public Spreadsheet(int numRows, int numCols)
        {
            this.spreadsheetArray = new Cell[numRows, numCols]; // initialize new array
            this.ColumnCount = numCols; // adjusts ColumnCount to number of columns in spreadsheet
            this.RowCount = numRows; // adjusts ColumnCount to number of columns in spreadsheet

            // forms the 2d array
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    Cell cell = new SpreadsheetCell(i, j); // make new cell

                    cell.PropertyChanged += this.CellText; // subscribe to cell

                    this.spreadsheetArray[i, j] = cell; // add to spreadsheet
                }
            }
        }

        /// <summary>
        /// The CellPropertyChanged event handler. To notify when the cell is modified.
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged = (sender, e) => { }; // event handler

        /// <summary>
        /// Gets or sets columns in spreadsheet.
        /// </summary>
        public int ColumnCount { get; set; }

        /// <summary>
        /// Gets or sets rows in spreadsheet.
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// Gets the cell specified at its coordinate location.
        /// </summary>
        /// <param name="row">The row location of the cell.</param>
        /// <param name="col">The column location of the cell.</param>
        /// <returns>The cell in the spreadsheet array or null when invalid.</returns>
        public Cell GetCell(int row, int col)
        {
            // check if valid cell within bounds
            if (row <= this.RowCount && col <= this.ColumnCount)
            {
                return this.spreadsheetArray[row, col];
            }
            else
            {
                return null; // else return null for invalid
            }
        }

        /// <summary>
        /// Either set the cell value to a text or grabs texts from another cell if starting with '='.
        /// </summary>
        /// <param name="sender"> Reference to object. </param>
        /// <param name="e"> Information about the event. </param>
        public void CellText(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Text")
            {
                Cell cell = sender as SpreadsheetCell;

                // if regular text; does not start with =
                if (cell.Text[0] != '=')
                {
                    cell.Value = cell.Text;
                }
                else
                {
                    // get column coordinate
                    char copyCol = cell.Text[1];
                    int colNum = copyCol - 65;

                    // get row coordinate
                    string copyRow = cell.Text.Substring(2);
                    int rowNum = int.Parse(copyRow);

                    // copy the value
                    string copyValue = this.spreadsheetArray[rowNum, colNum].Value;
                    cell.Value = copyValue;
                }

                // notify change
                this.CellPropertyChanged(sender, new PropertyChangedEventArgs("TextChanged"));
            }
        }
    }
}
