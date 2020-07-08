using System;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace Test_LINQ
{
    class LINQToXML
    {

        public static void Test_Query()
        {
            // Load the XML file from our project directory containing the purchase orders
            var filename = "PurchaseOrder.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var purchaseOrderFilepath = Path.Combine(currentDirectory, filename);

            XElement purchaseOrder = XElement.Load(purchaseOrderFilepath);

            IEnumerable<string> partNos = from item in purchaseOrder.Descendants("Item")
                                          select (string)item.Attribute("PartNumber");
            foreach(string ret in partNos)
            {
                Console.WriteLine(ret);
            }
        }

        public static void Test_XElement()
        {
            XElement shippingUnit = new XElement("shippingUnit", new XElement("Cost", 312.14));
            Console.WriteLine(shippingUnit);
        }

        public static void Test_XAttribute()
        {
            XElement phone = new XElement("Phone", new XAttribute("Type", "Home"), "555-555-555");
            Console.WriteLine(phone);
        }

        public static void Test_CreateXElement()
        {
            XElement xmlTree1 = new XElement("Root",
                new XElement("Child1", 1),
                new XElement("Child2", 2),
                new XElement("Child3", 3),
                new XElement("Child4", 4),
                new XElement("Child5", 5),
                new XElement("Child6", 6)
            );
            IEnumerable<string> contents = from element in xmlTree1.Elements()
                                          select element.Value;
            Console.WriteLine(xmlTree1);
            Console.WriteLine("Write contents");
            foreach (string s in contents)
            {
                Console.WriteLine(s);
            }
        }

        public static void Test_CreateXML(string fileName)
        {
            XElement xmlTree = new XElement("设备库",
                new XElement("芯片库",
                    new XElement("PPC"),
                    new XElement("FPGA"),
                    new XElement("ZYNQ")
                    ),
                new XElement("板卡库"),
                new XElement("背板库"),
                new XElement("机箱库")
                );
            xmlTree.Save(fileName);
        }
    }
}
