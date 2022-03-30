// <copyright file="Form1.cs" company="Linh Stitsel">
// Copyright (c) Linh Stitsel. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>
    /// The class Form1 for the GUI.
    /// </summary>
    public partial class Form1 : Form
    {
        private Spreadsheet sheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.sheet = new Spreadsheet(50, 26);
            this.sheet.CellPropertyChanged += this.CellPropertyChangedHandler;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // variables
            int letter = 0; // for column count
            this.dataGridView1.ColumnCount = 26; // for column count
            this.dataGridView1.RowCount = 50; // for row count

            // make cols a to z
            for (int i = 65; i < 91; i++)
            {
                this.dataGridView1.Columns[letter].Name = ((char)i).ToString();
                ++letter;
            }

            // make rows 1 to 50
            for (int i = 1; i <= 50; i++)
            {
                // make sure row index 0 is labelled as 1 and so on then convert to string and add
                this.dataGridView1.Rows[i - 1].HeaderCell.Value = i.ToString();
            }
        }

        private void CellPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "TextChanged")
            {
                // get cell to update
                Cell updatedCell = sender as Cell;

                // only change if cell is changed
                if (updatedCell != null)
                {
                    int row = updatedCell.RowIndex;
                    int column = updatedCell.ColumnIndex;
                    this.dataGridView1.Rows[row].Cells[column].Value = updatedCell.Value;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // variables for random
            Random rnd = new Random();

            // add text to 50 random cells
            for (int i = 0; i < 50; i++)
            {
                int randRow = rnd.Next(0, 50);
                int randCol = rnd.Next(0, 26);

                Cell cell = this.sheet.GetCell(randRow, randCol);
                cell.Text = "Hello World!";
            }

            // add text to column B
            for (int i = 0; i < this.sheet.RowCount; i++)
            {
                Cell cell = this.sheet.GetCell(i, 1);
                cell.Text = "This is cell B" + (i + 1);
            }

            // add text to column A
            for (int i = 0; i < this.sheet.RowCount; i++)
            {
                Cell cell = this.sheet.GetCell(i, 0);
                cell.Text = "=B" + i;
            }
        }
    }
}
