using System;
using System.Collections.Generic;

namespace Day_1
{
    class Program
    {
        public static int DiagonalDifference(List<List<int>> grid)
        {
            int i1 = 0;
            int j1 = 0;
            int i2 = grid.Count-1;
            int j2 = 0;

            int sum1 = 0;
            int sum2 = 0;

            for (int k = 0; k < grid.Count; k++)
            {
                sum1 += grid[i1][j1];
                sum2 += grid[i2][j2];
                i1++;
                j1++;
                i2--;
                j2++;
            }

            return Math.Abs(sum1-sum2);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("The maximum sum is " + DiagonalDifference(Generator.generator()));
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
