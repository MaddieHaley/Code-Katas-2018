using System;
using Xunit;

namespace Day_4
{
    class Program
    {
        public static string NumbersToWords(long number)
        {
            string words = String.Empty;
            return words;
        }

        public static long WordsToNumbers(string phrase)
        {
            long number = 0;
            return number;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number");
            var phrase = NumbersToWords(long.Parse(Console.ReadLine()));
            Console.WriteLine("Number in words: " + phrase);
            Console.WriteLine("Was: " + WordsToNumbers(phrase));
            Console.ReadKey();
        }
    }
}
