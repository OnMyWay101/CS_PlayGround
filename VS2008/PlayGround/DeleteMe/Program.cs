using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeleteMe
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] info = new int[5];
            GroupSDK.MAG_GetRectTemperatureInfo(0, 0, 0, 0, info);
            return info;
        }

        public int[] GetInfo()
        {
            int[] info = new int[5];
            GroupSDK.MAG_GetRectTemperatureInfo(0, 0, 0, 0, info);
            return info;
        }
    }
}
