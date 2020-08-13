using System;
using System.Threading;


namespace WaitHandle
{
    class Program
    {
        static AutoResetEvent autoEvent = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Example_AutoEvent();
            Console.ReadLine();
        }

        static void Example_AutoEvent()
        {
            Console.WriteLine("Main starting");

            ThreadPool.QueueUserWorkItem(new WaitCallback(AutoEvent_DoWork), autoEvent);

            //wait for work method to signal
            if(autoEvent.WaitOne(new TimeSpan(0, 0, 8)))
            {
                Console.WriteLine("work method signaled!");
            }
            else
            {
                Console.WriteLine("time out for 'method to signal'");
            }
        }

        static void AutoEvent_DoWork(object stateInfo)
        {
            Console.WriteLine("Work starting!");
            Console.WriteLine("Please type!");
            Console.ReadLine();
            Console.WriteLine("type ok!");
            Thread.Sleep(new Random().Next(100, 2000));

            Console.WriteLine("Work ending.");
            ((AutoResetEvent)stateInfo).Set();
        }
    }
}
