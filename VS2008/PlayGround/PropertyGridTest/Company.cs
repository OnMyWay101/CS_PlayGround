using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace PropertyGridTest
{
    public class Employee
    {
        [DisplayName("员工名称")]
        [Description("员工名称")]
        public string Name { get; set; }

        [DisplayName("员工性别")]
        [Description("员工性别")]
        public string Gender { get; set; }

        [DisplayName("员工发色")]
        [Description("员工发色")]
        public string HairColor { get; set; }
    }

    public class EmployeeCollection : CollectionBase
    {
        public Employee this[int index]
        {
            get { return (Employee)List[index]; }
        }

        public void Add(Employee emp)
        {
            List.Add(emp);
        }

        public void Remove(Employee emp)
        {
            List.Remove(emp);
        }

    }

    //public class EmployeeCollectionEditor : CollectionEditor
    //{
    //    public EmployeeCollectionEditor(Type type)
    //        : base(type)
    //    {
    //    }

    //    protected override string GetDisplayText(object value)
    //    {
    //        Employee item = new Employee();
    //        item = (Employee)value;

    //        return base.GetDisplayText(string.Format("{0}", item.Name));
    //    }
    //}

    class Company
    {
        [Category("基本属性")]
        [DisplayName("公司名称")]
        [Description("公司名称")]
        public string Name { get; set; }

        [Category("基本属性")]
        [DisplayName("公司地址")]
        [Description("公司地址")]
        public string Address { get; set; }

        private EmployeeCollection emCollection = new EmployeeCollection();
        //[Editor(typeof(EmployeeCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Category("公司员工")]
        [DisplayName("公司员工")]
        [Description("员工是公司的竞争力")]
        public EmployeeCollection Employees
        {
            get { return emCollection; }
            set { emCollection = value; }
        }
    }
}
