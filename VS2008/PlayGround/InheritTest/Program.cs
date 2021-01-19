using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Test2();
            Console.ReadLine();
        }

        static void Test1()
        {
            TestD t = new TestD();
            t.Func1();
            t.Func2();
            t.Func3();
            t.Func4();
        }

        static void Test2()
        {
            ITestE it = new TestG();
            it.Func5();
            it.Func6();
        }
    }
    #region 类继承测试
    public abstract class TestA
    {
        public abstract void Func1();
        public abstract void Func2();
        public abstract void Func3();
    }

    public class TestB : TestA
    {
        //测试子类实现抽象函数能否使用virtual;结果：不能
        public override void Func1()
        {
            Console.WriteLine("TestB:Func1");
        }

        public override void Func2()
        {
            Console.WriteLine("TestB:Func2");
        }

        public override void Func3()
        {
            Console.WriteLine("TestB:Func3");
        }

        public virtual void Func4()
        {
            Console.WriteLine("TestB:Func4");
        }
    }

    public class TestC : TestB
    {
        //测试子类重写父类的重写函数:结果：可以的
        //sealed可以阻值对象重写父类函数

        public override void Func1()
        {
            Console.WriteLine("TestC:Func1");
        }

        public sealed override void Func3()
        {
            Console.WriteLine("TestC:Func3");
        }
        
        public override void Func4()
        {
            base.Func4();
            Console.WriteLine("TestC:Func4");
        }
    }

    public class TestD : TestC
    {
        public override void Func2()
        {
            base.Func2();
            Console.WriteLine("TestD:Func2");
        }

        public override void Func4()
        {
            Console.WriteLine("TestD:Func4");
        }
    }
    #endregion

    #region 接口测试

    interface ITestE
    {
        void Func5();
        void Func6();
    }

    public class TestF : ITestE
    {
        //1.必需实现继承接口的方法
        //2.实现接口必需声明为public；
        //3.不能使用override关键字；因为override关键字是针对virtual的;
        //4.可以使用virtual关键字，这样能虚实现函数重写，实现多态；
        public virtual void Func5()
        {
            Console.WriteLine("TestF:Func5");
        }

        public void Func6()
        {
            Console.WriteLine("TestF:Func6");
        }
    }

    public class TestG : TestF
    {
        public override void Func5()
        {
            Console.WriteLine("TestG:Func5");
        }

    }

    #endregion

}
