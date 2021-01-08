using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace GenericType
{
    class Program
    {
        static void Main(string[] args)
        {
            FlexibleTypeStatic(typeof(string), new object[]{"hello"});
            Console.ReadLine();
        }

        static void StableType()
        {
            Type type = typeof(Class1<int>);
            object o = Activator.CreateInstance(type);
            type.InvokeMember("Test", BindingFlags.Default | BindingFlags.InvokeMethod, null, o, new object[] { 123 });
        }


        static void FlexibleType(Type t, params object[] args)
        {
            Type type = typeof(Class1<>);
            type = type.MakeGenericType(t);
            object o = Activator.CreateInstance(type);
            type.InvokeMember("Test", BindingFlags.Default | BindingFlags.InvokeMethod, null, o, args);
        }

        class Class1<T>
        {
            public void Test(T t)
            {
                Console.WriteLine(t);
            }
        }

        static void StableTypeStatic()
        {
            Type type = typeof(Class2<int>);
            type.InvokeMember("Test", BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { 321 });
        }


        static void FlexibleTypeStatic(Type t, params object[] args)
        {
            Type type = typeof(Class2<>);
            type = type.MakeGenericType(t);
            type.InvokeMember("Test", BindingFlags.Default | BindingFlags.InvokeMethod, null, null, args);
        }

        static class Class2<T>
        {
            public static void Test(T t)
            {
                Console.WriteLine(t);
            }
        }
    }
}
