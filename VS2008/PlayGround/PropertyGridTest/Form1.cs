using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PropertyGridTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ShowPropertyValue_MyCompany();
        }

        private void ShowPropertyValue_MyCompany()
        {
            var a = new MyEmployee();
            a.Name = "卢姐";
            a.Gender = "女";
            a.HairColor = Color.Yellow.ToString();

            var b = new MyEmployee();
            b.Name = "王维";
            b.Gender = "男";
            b.HairColor = Color.Black.ToString();

            MyCompany myCompany = new MyCompany("华科海讯", "蜀西路_西城国际_A1502", new MyEmployee[] { a, b });
            this.propertyGrid1.SelectedObject = myCompany;
        }

        private void ShowPropertyValue_Employee()
        {
            Employee a = new Employee();
            a.Name = "樊大姐";
            a.Gender = "女";
            a.HairColor = Color.Yellow.ToString();

            Employee b = new Employee();
            b.Name = "张小蛋";
            b.Gender = "男";
            b.HairColor = Color.Black.ToString();

            Company company = new Company();
            company.Employees.Add(a);
            company.Employees.Add(b);
            company.Address = "北京";
            company.Name = "100度";

            this.propertyGrid1.SelectedObject = company;
        }

        private void ShowPropertyValue_My()
        {
            My my1 = new My();
            My my2 = new My();
            My my3 = new My();
            My[] mys = new My[] { my1 , my2, my3};
            this.propertyGrid1.SelectedObject = my1;
        }

    }

    public class My
    {
        public My()
        {
            this.Names = new List<string>() { "hello", "nihao" };
        }

        [TypeConverter(typeof(MyTypeConverter))]          //<---
        public List<string> Names { get; private set; }

        private class MyTypeConverter : TypeConverter
        {
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string) && value is List<string>)
                {
                    return (value as List<string>).Count + " element(s)";
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
    }
}
