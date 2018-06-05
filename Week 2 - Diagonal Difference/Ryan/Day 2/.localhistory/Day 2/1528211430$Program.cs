using System;
using System.Collections.Generic;

namespace Day_2
{
    class Program
    {
        public static int DiagonalDifference(List<List<int>> grid)
        {
            int distanceFromEdge = 0;
            int diff = 0;
            foreach (List<int> row in grid)
            {
                diff += row[distanceFromEdge] - row[row.Count - distanceFromEdge];
                distanceFromEdge++;
            }

            return Math.Abs(diff);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("The sum is " + DiagonalDifference(Generator.generator()));
        }
    }
}
