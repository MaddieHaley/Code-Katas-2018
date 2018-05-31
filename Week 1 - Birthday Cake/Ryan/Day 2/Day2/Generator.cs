using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    internal static class Generator
    {
        public static List<int> generator()
        {
            Console.Write("Enter child age: ");
            int age = Int32.Parse(Console.ReadLine());
            List<int> candleHeights = new List<int>();

            Random rand = new Random();
            for (int candle = 0; candle < age; candle++)
            {
                candleHeights.Add(rand.Next(1, age));
            }

            Console.WriteLine("Candle heights: "+ String.Join(", ", candleHeights));

            return candleHeights;
        }
    }

}