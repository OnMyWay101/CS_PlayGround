using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class BestTimeToBuy
    {
        public static void Run()
        {
            int[] prices = new int[] { 2, 3, 5, 1, 6 };
            CalculateMaxPrice(prices);
        }

        static void CalculateMaxPrice(int[] prices)
        {
            int maxValue = 0;//当前时间段最大的价格差
            int minBuy = 0;//最小买入的时间点的价格
            int buyTime = 0;
            int minTime = 0;
            int saleTime = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (i == 0)
                {
                    minBuy = prices[i];
                    buyTime = 0;
                }
                else
                {
                    if ((prices[i] - minBuy) > maxValue)
                    {
                        maxValue = prices[i] - minBuy;
                        saleTime = i;
                        buyTime = minTime;
                    }
                    if (prices[i] < minBuy)
                    {
                        minBuy = prices[i];
                        minTime = i;
                    }
                }
            }
            Console.WriteLine("MaxValue:{0}, BuyTime:{1}, SaleTime:{2}", maxValue, buyTime, saleTime);
        }
    }
}
