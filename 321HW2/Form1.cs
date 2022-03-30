// Copyright (c) Linh Stitsel. All rights reserved.

namespace _321HW2
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    ///  Class for the Form UI, main, and output.
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
        ///  This function includes the main implementations and outputs.
        /// </summary>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<int> numList = new List<int>(); // create list
            MakeList.AddToList(ref numList); // add random values to list
            int count1 = DistinctFinder.HSMethod(ref numList); // holds hashset count
            int count2 = DistinctFinder.O1StorageMethod(ref numList); // holds o1 storage count
            int count3 = DistinctFinder.SortedMethod(ref numList); // holds sorted count

            // outputs
            string message1 = "1. HashSet method: " + count1 + " unique numbers.\r\n" + "This method runs in O(1) time because a hash set does not allow duplicates, so distinct integers are already included in the set.\r\n";
            string message2 = "2. O(1) storage method: " + count2 + " unique numbers.\r\n" + "This method's nested loops run in O(n^2) time complexity. The outer loop iterates for O(n) time and as it iterates, the inner loop also goes for O(n) time.\r\n";
            string message3 = "3. Sorted storage method: " + count3 + " unique numbers.\r\n" + "This method runs in O(n) complexity because there is a O(1) if statement inside an O(n) loop.";
            this.textBox1.Text = message1 + message2 + message3;
        }
    }
}
