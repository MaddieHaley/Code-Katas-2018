using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        { }
    }

    public static class NumberToWordConverter
    {
        public static string Convert(int intToBeConverted)
        {
            if (intToBeConverted == 0)
                return "zero";

            string convertedInt = "";

            bool negative = intToBeConverted < 0;
            if (negative)
                intToBeConverted = -intToBeConverted;

            int[][] periods = GetPeriods(intToBeConverted);

            int mag = 1;
            for (int i = periods.Length - 1; i >= 0; i--)
            {
                string period = PeriodAsTerms(periods[i]);

                if (period != "")
                {
                    convertedInt = PeriodAsTerms(periods[i]) + " " + MagAsTerm(mag) + " " + convertedInt;
                }

                mag *= 1000;
            }

            if (negative)
                convertedInt = "negative " + convertedInt;

            return convertedInt.Trim();
        }

        private static string PeriodAsTerms(int[] period)
        {
            string convertedPeriod = "";

            if (period[0] != 0)
            {
                convertedPeriod += GetTerm(period[0]) + " hundred ";
            }

            if (period[1] != 0)
            {
                if (period[1] == 1)
                {
                    convertedPeriod += GetTerm(period[1] * 10 + period[2]);
                }
                else
                {
                    convertedPeriod += GetTerm(period[1] * 10) + " " + GetTerm(period[2]);
                }
            }
            else if (period[2] != 0)
            {
                convertedPeriod += GetTerm(period[2]);
            }

            return convertedPeriod.Trim();
        }

        private static object MagAsTerm(int mag)
        {
            return NumericTermDatabase.GetMagnitudeAsTerm(mag);
        }

        private static int[][] GetPeriods(int periodSource)
        {
            int totalDigits = periodSource.ToString().Length;

            int[][] periods = new int[(int) Math.Ceiling((double) totalDigits / 3)][];

            for (int i = periods.GetLength(0) - 1; i >= 0; i--)
            {
                int period = periodSource % 1000;

                periods[i] = GetDigits(period);
                
                periodSource /= 1000;
            }

            return periods;
        }

        private static int[] GetDigits(int digitSource)
        {
            int[] digits = new int[3];

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                digits[i] = digitSource % 10;
                digitSource /= 10;
            }

            return digits;
        }

        private static string GetTerm(int value)
        {
            return NumericTermDatabase.GetValueAsTerm(value);
        }
    }

    public static class WordToNumberConverter
    {
        public static int Convert(string strToBeConverted)
        {
            if (string.IsNullOrEmpty(strToBeConverted))
                return 0;
            
            int convertedStr;

            string[] words = strToBeConverted.Split(' ');

            bool negative = words[0] == "negative";

            convertedStr = ConvertPhrase(words);

            if (negative) convertedStr = -convertedStr;

            return convertedStr;
        }

        private static int ConvertPhrase(string[] words)
        {
            int convertedPhrase = 0;

            int multiplier = 1;
            bool hundredInEffect = false;

            for (int i = words.Length - 1; i >= 0; i--)
            {
                string word = words[i];

                int wordValue = GetValue(word);

                if (wordValue == 0)
                {
                    if (word == "hundred")
                    {
                        multiplier *= 100;
                        hundredInEffect = true;
                    }
                    else
                    {
                        multiplier = GetMag(word);
                    }
                }
                else
                {
                    convertedPhrase += wordValue * multiplier;

                    if (hundredInEffect)
                    {
                        multiplier /= 100;
                        hundredInEffect = false;
                    }
                }
            }

            return convertedPhrase;
        }

        private static int GetValue(string word)
        {
            return NumericTermDatabase.GetTermValue(word);
        }

        private static int GetMag(string mag)
        {
            return NumericTermDatabase.GetTermMagnitude(mag);
        }
    }

    public static class NumericTermDatabase
    {
        private static Hashtable _terms = new Hashtable
        {
            { 90, "ninety" },
            { 80, "eighty" },
            { 70, "seventy" },
            { 60, "sixty" },
            { 50, "fifty" },
            { 40, "fourty" },
            { 30, "thirty" },
            { 20, "twenty" },
            { 19, "nineteen" },
            { 18, "eighteen" },
            { 17, "seventeen" },
            { 16, "sixteen" },
            { 15, "fifteen" },
            { 14, "fourteen" },
            { 13, "thirteen" },
            { 12, "twelve" },
            { 11, "eleven" },
            { 10, "ten" },
            { 9, "nine" },
            { 8, "eight" },
            { 7, "seven" },
            { 6, "six" },
            { 5, "five" },
            { 4, "four" },
            { 3, "three" },
            { 2, "two" },
            { 1, "one" },
        };
        private static Hashtable _magnitudes = new Hashtable
        {
            { 1000000000, "billion" },
            { 1000000, "million" },
            { 1000, "thousand" }
        };

        public static string GetMagnitudeAsTerm(int mag)
        {
            object found = _magnitudes[mag];

            if (found == null)
                return "";
            return found.ToString();
        }

        public static string GetValueAsTerm(int value)
        {
            object found = _terms[value];

            if (found == null)
                return "";
            return found.ToString();
        }

        public static int GetTermValue(string term)
        {
            return _terms.Keys.OfType<int>().FirstOrDefault(i => _terms[i].ToString() == term);
        }

        public static int GetTermMagnitude(string term)
        {
            return _magnitudes.Keys.OfType<int>().FirstOrDefault(i => _magnitudes[i].ToString() == term);
        }
    }
}
