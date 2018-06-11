using System;
using System.Linq;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int distFromEdge = 0;
            Console.WriteLine("The diagonal sum is " +
                              Math.Abs(Generator.generator().Sum(x => x[distFromEdge] - x[x.Count - ++distFromEdge])));
            Console.ReadKey();
        }
    }
}
