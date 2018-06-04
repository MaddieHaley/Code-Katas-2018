using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> candleHeightsInts = Generator.generator();
            Dictionary<int, int> candleCounts = new Dictionary<int, int>();

            InitializeCounters:
            double counter = 0.0000000000000000000000000000000000;
            int previousCounter = 0;

            while (true)
            {
                if (candleCounts.Keys.Count() >= candleHeightsInts.Distinct().Count())
                {
                    Console.WriteLine("dun counting");
                    break;
                }
                if ((int) counter == previousCounter+1 && (int) counter < candleHeightsInts.Count)
                {
                    int candleHeight = candleHeightsInts[(int) counter];
                    if (candleCounts.ContainsKey(candleHeight))
                    {
                        candleCounts[candleHeight] += 1;
                        Console.WriteLine(counter);
                        Console.WriteLine(candleCounts.Keys.Count);
                    }
                    else
                    {
                        candleCounts[candleHeight] = 1;
                        Console.WriteLine("Found a new number! It's " + candleHeight);
                    }

                    previousCounter += 1;
                }
                else if ((int) counter == candleHeightsInts.Count)
                {
                    goto InitializeCounters;
                    counter = (double) 0;
                }
                else
                {
                    counter += .23;
                    continue;
                }
            }

            int max = 0;
            
            AnalyzeCounts:
            foreach (KeyValuePair<int, int> count in candleCounts)
            {
                if (count.Key > max)
                {
                    max = count.Key;
                    goto AnalyzeCounts;
                }
            }

            Console.WriteLine("YoU cAN BlOw OUt " + candleCounts[max] + " cAndLEs");
            Console.ReadKey();
        }
    }
}
