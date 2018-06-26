using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_1
{
    internal class Program
    {
        public static SortedMap<int, char> DecimalToRoman = new SortedMap<int, char>
        {
            {1, 'I'},
            {5, 'V'},
            {10, 'X'},
            {50, 'L'},
            {100, 'C'},
            {500, 'D'},
            {1000, 'M'}
        };

        public static bool IsPowerOfTenConversion(int index)
        {
            return index % 2 == 0;
        }

        public static string NumbersToRomanNumerals(int number)
        {
            string romanNumerals = String.Empty;

            List<KeyValuePair<int, char>> conversions = DecimalToRoman.Forward.ToList();
            conversions.Reverse();

            for (int i = 0; i < conversions.Count(); i++)
            {
                int lastIndex = conversions.Count() - 1;
                int subtractorIndexDifference = IsPowerOfTenConversion(i) ? 2 : 1;
                bool noSubtractor = i + subtractorIndexDifference >= conversions.Count();
                KeyValuePair<int, char> subtractor;
                if (!noSubtractor)
                    subtractor = conversions[i + subtractorIndexDifference];

                if (conversions[i].Key * 3 >= number && noSubtractor ||  conversions[i].Key - subtractor.Key <= number)
                {
                    if (number == conversions[i].Key)
                    {
                        romanNumerals += conversions[i].Value.ToString();
                        break;
                    }

                    if (conversions[i].Key < number &&
                        (i == 0 || noSubtractor ||
                         number < conversions[i].Key - subtractor.Key))
                    {
                        while (number >= conversions[i].Key)
                        {
                            romanNumerals += conversions[i].Value.ToString();
                            number -= conversions[i].Key;
                        }
                    }
                    else
                    {
                        romanNumerals += subtractor.Value.ToString() + conversions[i].Value;
                        number -= (conversions[i].Key - subtractor.Key);
                    }
                }
            }

            return romanNumerals;
        }

        private static void Main(string[] args)
        {
            Console.Write("Please enter a number to be converted: ");
            Console.WriteLine($"The number in Roman numerals is: {NumbersToRomanNumerals(Int32.Parse(Console.ReadLine()))}");
            Console.ReadKey();
        }
    }
}