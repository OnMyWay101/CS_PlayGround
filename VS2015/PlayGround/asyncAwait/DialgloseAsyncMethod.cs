using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace asyncAwait
{
    class DialgloseAsyncMethod
    {
        public static void Example_Task()
        {
            Task t = Calculator.AddAsync2(1, 2);

            t.Wait();
            Console.WriteLine("AddAsync 方法执行完成");
        }

        public static void Example_TaskT()
        {
            Task<int> t = Calculator.AddAsync(1, 2);

            Console.WriteLine($"AddAsync 方法执行完成 Result:{t.Result}");
        }

        internal class Calculator
        {
            private static int Add(int n, int m)
            {
                Thread.Sleep(1000);
                return n + m;
            }

            //异步方法返回Task
            public static async Task AddAsync2(int n, int m)
            {
                int val = await Task.Run(() => Add(n, m));
                Console.WriteLine($"Result: {val}");
            }

            //异步方法返回Task<T>
            public static async Task<int> AddAsync(int n, int m)
            {
                int val = await Task.Run(() => Add(n, m));
                
                return val;
            }

            //异步方法返回Void
            public static async void AddAsync3(int n, int m)
            {
                int val = await Task.Run(() => Add(n, m));
                Console.WriteLine($"Result: {val}");
            }
        }
    }

    class AWaitTest
    {
        public static void Example1()
        {
            //配置停止的资源
            CancellationTokenSource source = new CancellationTokenSource();
            var token = source.Token;

            Console.WriteLine("Start do work!");
            Task t = DoWorks(token);
            Console.WriteLine("after do work!");

            Thread.Sleep(1000);
            source.Cancel();

            //t.Wait();
            Console.WriteLine("end do work!");
            Console.ReadLine();
        }

        private static void Work(int id)
        {
            Console.WriteLine($"Start working (id:{id})");
            Thread.Sleep(5000);
            Console.WriteLine($"work end (id:{id})");
        }

        private static async Task DoWorks(CancellationToken token)
        {
            Console.WriteLine("Start assign work!");

            //case1
            //await Task.Run(() => Work(1), token);
            //await Task.Run(() => Work(2), token);
            //await Task.Run(() => Work(3), token);
            //await Task.Run(() => Work(4), token);

            //case2
            for(int i = 0; i < 4; i++)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }
                //await Task.Run(() => Work(i + 1), token);
                await Task.Delay(700, token);
                Console.WriteLine($"complete:{i + 1}");
            }

            Console.WriteLine("end assign work!");

        }

    }
}
