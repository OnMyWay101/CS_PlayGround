using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleCallUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose to show form? [Y/N]");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            if (key.KeyChar == 'Y')
            {
                ShowForm();
            }
            else
            {
                Console.WriteLine("Input error ,but still show!");
                ShowForm();
            }
            Console.ReadLine();
        }

        static void ShowForm()
        {
            Form form = new Form();
            Button btn = new Button();
            Button btn2 = new Button();

            form.ClientSize = new Size(500, 500);
            form.Text = "My Form";

            btn.Location = new Point(290, 290);
            btn.Size = new Size(150, 20);
            btn.Text = "Click Me!";
            btn.Click += new EventHandler((s, e) => Console.WriteLine("Click the button!"));

            btn2.Location = new Point(190, 190);
            btn2.Size = new Size(150, 20);
            btn2.Text = "Click Me~!";
            btn2.Click += new EventHandler((s, e) =>
                {
                    form.DialogResult = DialogResult.Yes;
                    form.Dispose();
                });

            form.Controls.Add(btn);
            form.Controls.Add(btn2);

            //Application.Run(form);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Yes)
            {
                Console.WriteLine("button close!");
            }
        }

    }
}
