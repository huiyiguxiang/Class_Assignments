// <copyright file="Cell.cs" company="Linh Stitsel">
// Copyright (c) Linh Stitsel. All rights reserved.
// </copyright>

namespace CptS321
{
    using System.ComponentModel;

    /// <summary>
    /// Cell class that inherits INotifyPropertyChanged and represents cells in the spreadsheet.
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        private string text; // text in cell
        private string value; // evaluated value of cell

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="row">Row coordinate of cell.</param>
        /// <param name="col">Column coordinate of cell.</param>
        public Cell(int row, int col)
        {
            this.text = string.Empty;
            this.value = string.Empty;
            this.RowIndex = row;
            this.ColumnIndex = col;
        }

        /// <summary>
        /// Notifies that the cell is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets row index.
        /// </summary>
        public int RowIndex { get; } // no setter so read only

        /// <summary>
        /// Gets column index.
        /// </summary>
        public int ColumnIndex { get; } // no setter so read only

        /// <summary>
        /// Gets or sets text contained in the cell.
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                // ignore if text unchanged
                if (value == this.text)
                {
                    return;
                }

                this.text = value; // else change text

                // notify that text is changed
                this.PropertyChanged(this, new PropertyChangedEventArgs("Text"));
            }
        }

        /// <summary>
        /// Gets or sets value of cell.
        /// </summary>
        public string Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }
    }
}
