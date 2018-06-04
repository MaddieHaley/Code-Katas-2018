using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalSumDay1
{
    class Program
    {
        static void Main(string[] args)
        {
            diagonalSum();
            Console.ReadLine();
        }

        static void diagonalSum()
        {
            var arr = generateRandArray();
            int size = arr.GetLength(0);
            int leftDiSum = 0;
            int rightDiSum = 0;
            //rows 
            for(int i = 0; i < size; i++)
            {
                leftDiSum += arr[i, i];
                rightDiSum += arr[i, size -1 - i];
            }
            Console.WriteLine("Left Diagonal Sum: " + leftDiSum);
            Console.WriteLine("Right Diagonal Sum: " + rightDiSum);
            var diff = Math.Abs(leftDiSum - rightDiSum);
            Console.WriteLine("The Diagonal Difference is " + diff);
        }

        static int[,] generateRandArray() {
            Random rand = new Random();
            int size = rand.Next(1, 1000);
            var arr = new int[size, size];
            for(int i = 0; i < size; i++)
            {
                for(int w = 0; w < size; w++)
                {
                    arr[i, w] = rand.Next(-1000, 1000);
                    Console.Write(arr[i, w] + " ");
                }
                Console.Write("\n");
            }
            return arr;
        }
    }
}
