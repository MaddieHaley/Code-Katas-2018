using System;
using Day2;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    class Program
    {
        static int HowManyCandles(List<int> candleHeights)
        {
            return candleHeights.FindAll(candle => candle == candleHeights.Max()).Count;
        }

        static void Main(string[] args)
        {
            List<int> candleHeights = Generator.generator();
            Console.WriteLine("You can blow out " + HowManyCandles(candleHeights) + " candels");
        }
    }
}
