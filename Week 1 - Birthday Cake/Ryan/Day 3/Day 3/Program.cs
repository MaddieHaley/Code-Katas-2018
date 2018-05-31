using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Day_3
{
    class Program
    {
        public static int HowManyCandles(List<int> candleHeights)
        {
            return candleHeights.Count(candle => candle == candleHeights.Max());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("The birthday person can blow out " + HowManyCandles(Generator.generator()) + " candles.");
        }
    }
}
