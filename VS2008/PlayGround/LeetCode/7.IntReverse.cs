using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class IntReverse
    {
        public static void Run()
        {
            int value = -147483647;     //0x7fffffff=2147483647
            Console.WriteLine("{0} reverse result is : {1}", value, reverse2(value));
        }

        private static int reverse(int value)
        {
            int result = 0;
            Stack<int> storeInt = new Stack<int>();
            Int64 ret = 0;
            int numBase = 1;
            int intMax = 0x7FFFFFFF;
            int intMin = (intMax * -1) - 1;

            //放
            while (value != 0)
            {
                storeInt.Push(value % 10);
                value = value / 10;
            }
            //拿
            while (storeInt.Count != 0)
            {
                ret = ret + storeInt.Pop() * numBase;
                numBase = numBase * 10;
            }
            //判断是否超出范围
            if (ret > intMax || ret < intMin)
            {
                result = 0;
            }
            else
            {
                result = (int)ret;
            }
            return result;
        }

        private static int reverse2(int value)
        {
            Int64 ret = 0;
            int intMax = 0x7FFFFFFF;
            int intMin = (intMax * -1) - 1;

            while (value != 0)
            {
                ret = ret * 10 + value % 10;
                value = value / 10;
            }

            return (ret > intMax || ret < intMin) ? 0 : (int)ret;
        }
    }
}
