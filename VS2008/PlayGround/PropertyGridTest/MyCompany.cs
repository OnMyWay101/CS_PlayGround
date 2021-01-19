using System;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace PropertyGridTest
{
    class MyCompany
    {
        [Category("基本属性"), Description("公司名称")]
        public string Name { get; set; }

        [Category("基本属性"), Description("公司地址")]
        public string Address { get; set; }

        [Category("员工信息"), Description("员工详细信息")]
        public MyEmployee[] MyEmployees{ get; set; }

        public MyCompany(string name, string addr, MyEmployee[] employees)
        {
            Name = name;
            Address = addr;
            MyEmployees = employees;
        }
    }

    [TypeConverter(typeof(MyEmployeeTypeConvertor))]
    public class MyEmployee
    {
        [DisplayName("员工名称"), Description("员工名称")]
        public string Name { get; set; }

        [DisplayName("员工性别"), Description("员工性别")]
        public string Gender { get; set; }

        [DisplayName("员工发色"), Description("员工发色")]
        public string HairColor { get; set; }
    }

    public class MyEmployeeTypeConvertor : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(MyEmployee))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType)
        {
            if (destinationType == typeof(String) && value is MyEmployee)
            {
                MyEmployee myEmployee = (MyEmployee)value;
                string str = myEmployee.Gender == "男" ? "男员工" : "女员工";
                return str;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

}
