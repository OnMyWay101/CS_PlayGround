﻿/*说明：给黎勇智的一个测试TextBox显示的示例程序；
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LYZ_TextBoxShow
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
