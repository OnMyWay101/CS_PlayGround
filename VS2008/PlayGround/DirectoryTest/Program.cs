using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectoryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Specify the directory you want to manipulate.
            string path = @"E:\cms\ZCD2_MHalSoftware\Software\Host\DRSysCtrlDisplay\bin\Debug\MyDir";

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

                // Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
