using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class SumOfTwoNum
    {
        public static void Run()
        {
            int targ = 19;
            int[] data = new int[] { 17,2,6,14,9,4};
            int[] ret = new int[2]{0,0};


            Calculate(data, targ, ref ret);

            Console.WriteLine("point1:{0};point2:{1}", ret[0], ret[1]);
        }

        private static void Calculate(int[] data, int targ, ref int[] ret)
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = i + 1; j < data.Length; j++)
                {
                    if ((data[i] + data[j]) == targ)
                    {
                        ret[0] = i;
                        ret[1] = j;
                        return;
                    }
                }
            }
        }
    }
}
