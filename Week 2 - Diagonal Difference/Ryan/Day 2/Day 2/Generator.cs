using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_2
{
    internal static class Generator
    {
        public static List<List<int>> generator()
        {
            Random rand = new Random();
            Console.WriteLine("Enter the table size: ");
            int n = Int32.Parse(Console.ReadLine());

            Console.WriteLine("This is the table:");

            List<List<int>> grid = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                List<int> line = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    line.Add(rand.Next(-100, 100));
                }
                Console.WriteLine(String.Join(" ", line));
                grid.Add(line);
            }

            return grid;
        }
    }

}