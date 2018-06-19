using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_2
{
    class Program
    {
        internal static Dictionary<string, string> _intToWord = new Dictionary<string, string>
        {
            {"0", "" },
            {"1", "one" },
            {'2', "two" },
            {"3", "three" },
            {"4", "four" },
            {"5", "five" },
            {"6", "six" },
            {"7", "seven" },
            {"8", "eight" },
            {"9", "nine" },
            {"10", "ten" },
            {"11", "eleven" },
            {"12", "twelve" },
            {"13", "thirteen" },
            {"14", "fourteen" },
            {"15", "fifteen" },
            {"16", "sixteen" },
            {"17", "seventeen" },
            {"18", "eighteen" },
            {"19", "nineteen" },
            {"20", "twenty" },
            {"30", "thirty" },
            {"40", "forty" },
            {"50", "fifty" },
            {"60", "sixty" },
            {"70", "seventy" },
            {"80", "eighty" },
            {"90", "ninety" }
        };

        internal static List<string> _prefixes = new List<string>
        {
            "thousand",
            "million",
            "billion",
            "trillion",
            "quadrillion",
        };

        public static string GetPrefix(int chunk)
        {
            if (chunk < _prefixes.Count)
                return _prefixes[chunk];

            return GetPrefix(chunk - _prefixes.Count) + _prefixes[_prefixes.Count - 1];
        }

        public static string NumbersToWords(string number)
        {
            string reverseNumber = number.Reverse().ToString();
            List<string> chunks = new List<string>();
            for (var i = 0; i < reverseNumber.Length; i++)
            {
                char c = reverseNumber[i];
                if (i % 3 == 0)
                {
                    chunks.Add(String.Empty);
                }

                chunks[i] += c;
            }

            for (var i = 0; i < chunks.Count; i++)
            {
                string chunk = chunks[i];


            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number");
            string words = NumbersToWords(Console.ReadLine());
        }
    }
}
