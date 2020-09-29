/*说明：创建一个ListView但是配有一个TextBox编辑框；
 * 实现效果：当我点击一个ListView的单元格的时候就会附带一个TextBox的编辑框，编辑完的数值就是该单元格的数值了；
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ListViewTB
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
