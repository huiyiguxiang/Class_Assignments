// <copyright file="Form1.cs" company="Linh Stitsel 11779841">
// Copyright (c) Linh Stitsel 11779841. All rights reserved.
// </copyright>

namespace _321HW3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Main implementation of program.
    /// It can load from a file and save to a file.
    /// It can also output the Fibonacci sequence up to 50 or 100.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Default Form 1 Load Event Function.
        /// </summary>
        /// <param name="sender">Contains reference to object.</param>
        /// <param name="e">Contains event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Default TextBox1 Event Function.
        /// </summary>
        /// <param name="sender">Contains reference to object.</param>
        /// <param name="e">Contains event data.</param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Prompts an open file dialog and uses Loadtext to read a txt file through the StreamReader.
        /// </summary>
        /// <param name="sender">Contains reference to object.</param>
        /// <param name="e">Contains event data.</param>
        private void loadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create load file
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName); // stream to open file
                this.LoadText(sr); // load text to textbox
                sr.Close(); // close stream
            }
        }

        /// <summary>
        /// Uses ReadToEnd to read text from a stream then output it in the textbox.
        /// </summary>
        /// <param name="sr">Input stream.</param>
        private void LoadText(TextReader sr)
        {
            string text = sr.ReadToEnd(); // string to hold text from file
            this.textBox1.Text = text; // display to textbox
        }

        /// <summary>
        /// Uses the FibonnaciTextReader class to output the Fibonacci sequence up to 50.
        /// It then uses LoadText to output to the textbox.
        /// </summary>
        /// <param name="sender">Contains reference to object.</param>
        /// <param name="e">Contains event data.</param>
        private void loadFibonacciNumbersfirst50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader fr = new FibonacciTextReader(50);
            this.LoadText(fr);
        }

        /// <summary>
        /// Uses the FibonnaciTextReader class to output the Fibonacci sequence up to 100.
        /// It then uses LoadText to output to the textbox.
        /// </summary>
        /// <param name="sender">Contains reference to object.</param>
        /// <param name="e">Contains event data.</param>
        private void loadFibonacciNumbersfirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader fr = new FibonacciTextReader(100);
            this.LoadText(fr);
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create save file
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName + ".txt"); // add .txt after filename to make txt file
                sw.WriteLine(this.textBox1.Text); // copy lines from textbox to file
                sw.Close(); // close stream
            }
        }
    }
}
