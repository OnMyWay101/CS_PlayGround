namespace DefineIMyInterface
{
    using System;

    public interface IMyInterface
    {
        void MethodB();
    }
}

namespace Extension
{
    using System;
    using DefineIMyInterface;

    public static class Extension
    {
        public static void MethodA(this IMyInterface myInterface, int i)
        {
            Console.WriteLine("Extension.MethodA(this IMyInterface myInterface, int i)");
        }

        public static void MethodA(this IMyInterface myInterface, string s)
        {
            Console.WriteLine("Extension.MethodA(this IMyInterface myInterface, string s)");
        }
    }
}

namespace ExtensionMethodDemo1
{
    using System;
    using Extension;
    using DefineIMyInterface;

    class A : IMyInterface
    {
        public void MethodB() { Console.WriteLine("A.MethodB"); }
    }

    class B : IMyInterface
    {
        public void MethodA(int i) { Console.WriteLine("B.MethodA(int i)"); }
        public void MethodB(){Console.WriteLine("B.MethodB");}
    }

    class C : IMyInterface
    {
        public void MethodA(object o) { Console.WriteLine("C.MethodA(object o))"); }
        public void MethodB() { Console.WriteLine("C.MethodB"); }
    }

    class ExtMethodDemo
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();

            Console.WriteLine("A:");
            a.MethodA(1);
            a.MethodA("hello");
            a.MethodB();

            Console.WriteLine("B:");
            b.MethodA(1);
            b.MethodA("hello");
            b.MethodB();

            Console.WriteLine("C:");
            c.MethodA(1);
            c.MethodA("hello");
            c.MethodB();

            Console.ReadLine();
        }
    }
}
