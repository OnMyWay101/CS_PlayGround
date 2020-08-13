using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseFunCall
{
    class Program
    {
        static void Main(string[] args)
        {
            var child = new DerivedX();
            child.BaseCall1();
            Console.ReadLine();
        }
    }

    public class BaseX
    {
        public void BaseCall1()
        {
            Console.WriteLine("BaseCall1");
            BaseCall2();
        }

        private void BaseCall2()
        {
            Console.WriteLine("BaseCall2");
            BaseCall3();
        }

        //虚类，子类重载
        protected virtual void BaseCall3()
        {
            Console.WriteLine("Base_BaseCall3");
        }

    }

    public class DerivedX : BaseX
    {
        protected override void BaseCall3()
        {
            Console.WriteLine("Derived_BaseCall3");
        }
    }

}
