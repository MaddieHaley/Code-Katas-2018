using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Day2
{
    internal class Program
    {
        public static List<KeyValuePair<int, string>> DecimalToRoman = new List<KeyValuePair<int, string>>
        {
            new KeyValuePair<int, string>(1000, "M"),
            new KeyValuePair<int, string>(900, "CM"),
            new KeyValuePair<int, string>(500, "D"),
            new KeyValuePair<int, string>(400, "CD"),
            new KeyValuePair<int, string>(100, "C"),
            new KeyValuePair<int, string>(90, "XC"),
            new KeyValuePair<int, string>(50, "L"),
            new KeyValuePair<int, string>(40, "XL"),
            new KeyValuePair<int, string>(10, "X"),
            new KeyValuePair<int, string>(9, "IX"),
            new KeyValuePair<int, string>(5, "V"),
            new KeyValuePair<int, string>(4, "IV"),
            new KeyValuePair<int, string>(1, "I")
        };

        public static  Dictionary<string, int> RomanSingleToDecimal = new Dictionary<string, int>
        {
            {"M", 1000},
            {"D", 500},
            {"C", 100},
            {"L", 50},
            {"X", 10},
            {"V", 5},
            {"I", 1}
        };

        public static Dictionary<string, int> RomanDoubleToDecimal = new Dictionary<string, int>
        {
            {"CM", 900},
            {"CD", 400},
            {"XC", 90},
            {"XL", 40},
            {"IX", 9},
            {"IV", 4}
        };


        public static string NumberToRoman(int number)
        {
            var romanNumerals = string.Empty;
            while (number > 0)
            {
                var match = DecimalToRoman.First(x => x.Key <= number);
                number -= match.Key;
                romanNumerals += match.Value;
            }

            return romanNumerals;
        }

        public static int RomanToNumber(string romanNumerals)
        {
            romanNumerals = romanNumerals.ToUpper();
            int number = 0;
            while (romanNumerals.Length > 0)
            {
                if (romanNumerals.Length > 1 && RomanDoubleToDecimal.ContainsKey(romanNumerals.Substring(0, 2)))
                {
                    number += RomanDoubleToDecimal[romanNumerals.Substring(0, 2)];
                    romanNumerals = romanNumerals.Substring(2, romanNumerals.Length - 2);
                }
                else
                {
                    number += RomanSingleToDecimal[romanNumerals.Substring(0, 1)];
                    romanNumerals = romanNumerals.Substring(1, romanNumerals.Length - 1);
                }
            }

            return number;
        }

        private static void Main(string[] args)
        {
            Console.Write("Please enter a number: ");
            string result = NumberToRoman(int.Parse(Console.ReadLine()));
            Console.WriteLine("The number in roman numerals is: " + result);
            Console.WriteLine("Was: " + RomanToNumber(result));
            Console.ReadKey();
        }
    }
}