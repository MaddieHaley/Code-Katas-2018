using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalDifferenceDay2
{
    class Program
    {
        static void Main(string[] args)
        {
            diagonalDifference();
        }

        static void diagonalDifference()
        {
            var arr = generateRandArray();
            var len = arr.GetLength(0);
            var left = 0;
            var right = 0;
            foreach(int x in Enumerable.Range(0, len))
            {
                left += arr[x, x];
                right += arr[x, len - 1 - x];
            }
            Console.WriteLine("The diagonal difference is: " + Math.Abs(left - right));
            again();
        }

        static void again()
        {
            Console.WriteLine("Would you like to go again?");
            var resp = Console.ReadLine();
            if (resp.Contains("y")) diagonalDifference();
            else if (resp.Contains("n")) return;
            else
            {
                Console.WriteLine("Sorry, couldn't catch that.");
                again();
            }
        }

        static int[,] generateRandArray()
        {
            Random rand = new Random();
            int size = rand.Next(3, 5);
            var arr = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int w = 0; w < size; w++)
                {
                    arr[i, w] = rand.Next(-10, 10);
                    Console.Write(arr[i, w] + " ");
                }
                Console.Write("\n");
            }
            return arr;
        }
    }
}
