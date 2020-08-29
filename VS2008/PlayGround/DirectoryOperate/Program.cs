using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DirectoryOperate
{
    class Program
    {
        static void Main(string[] args)
        {
            Example_ShowDirFiles();
            Console.ReadKey();
        }

        static void Example_ShowDirFiles()
        {
            var fileNames = Directory.GetFiles(@"D:\自己资料\C++\网络爬虫\src");
            foreach (string fileName in fileNames)
            {
                Console.WriteLine("Raw name:" + fileName);
                var names = fileName.Split(new char[] { '\\', '.' });
                Console.WriteLine("Processed name:" + names[names.Length - 2]);
            }
        }
    }
}
