﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OOp_Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for he application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFOrm());
        }
    }
}
