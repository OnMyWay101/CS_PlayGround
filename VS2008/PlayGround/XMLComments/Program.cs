using System;

namespace XMLComments
{
    class MyProgram
    {
        /// <summary>
        /// 程序入口函数
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Student<string> ss = new Student<string>("WangCJ", 123, 28);
            ss.MyWork = "C# Programming";

            ss.IntruduceSelf();
            ss.DoWork("happy");

            Console.ReadLine();
        }

        /// <summary>
        /// 打印一个学生的信息
        /// </summary>
        /// <param name="stuName"></param>
        /// <param name="stuNum"></param>
        /// <param name="stuAge"></param>
        public static void Example_ShowStudentInfo(string stuName, uint stuNum, uint stuAge)
        {
            Console.WriteLine("{0} student number is {1}, age is {2}", stuName, stuNum, stuAge);
        }

        /// <summary>
        /// 打印一个学生的信息2
        /// </summary>
        /// <param name="stuName"></param>
        /// <param name="stuNum"></param>
        /// <param name="stuAge"></param>
        /// <returns>是否打印成功</returns>
        public static bool Example_ShowStudentInfo2(string stuName, uint stuNum, uint stuAge)
        {
            Console.WriteLine("{0} student number is {1}, age is {2}", stuName, stuNum, stuAge);
            return true;
        }
    }

    /// <summary>
    /// 同学类
    /// </summary>
    public class Student<T>:IDoWork<T>
    {
        public String Name { get; private set; }
        public uint Num { get; private set; }
        public uint Age { get; private set; }
        public string MyWork { get; set; }

        public Student(string name, uint num, uint age)
        {
            Name = name;
            Num = num;
            Age = age;
        }

        /// <summary>
        /// 介绍自己
        /// </summary>
        public void IntruduceSelf()
        {
            Console.WriteLine("{0} student number is {1}, age is {2}", Name, Num, Age);
            Console.WriteLine("My favorite game is Temple Run!");
        }

        /// <summary>
        /// 做工作
        /// </summary>
        public void DoWork<T>(T feel)
        {
            Console.WriteLine("{0} is doing {1},and feel {2}!", Name, MyWork, feel.ToString());
        }
    }

    public interface IDoWork<T>
    {
        void DoWork<T>(T someWhat);
    }
}
