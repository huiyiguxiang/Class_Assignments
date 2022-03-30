// Copyright (c) Linh Stitsel. All rights reserved.

namespace _321HW2
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
