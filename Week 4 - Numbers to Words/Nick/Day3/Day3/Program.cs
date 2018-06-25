using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
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

            bool negative = false;
            if (intToBeConverted < 0)
            {
                negative = true;
                intToBeConverted = -intToBeConverted;
            }

            string convertedInteger = "";
            List<int> digits = GetDigits(intToBeConverted);

            int magnitude = 1;
            int one = 1;
            int ten = 10;
            int hundred = 100;
            int period = 1;

            bool magTermNeeded = false;
            bool magTermUsed = false;

            for (int i = 0; i < digits.Count; i++)
            {
                int digit = digits[i];

                if (magnitude == one)
                {
                    magTermUsed = false;

                    if (digit != 0)
                    {

                        if (i + 1 < digits.Count && digits[i + 1] == 1)
                        {
                            if (magnitude >= 1000)
                            {
                                convertedInteger = GetNumTerm(digit + 10) + " " + GetMagTerm(period) + " " + convertedInteger;
                                digits[i + 1] = 0;
                                magTermUsed = true;
                                magTermNeeded = false;
                            }
                            else
                            {
                                convertedInteger = GetNumTerm(digit + 10) + " " + convertedInteger;
                                digits[i + 1] = 0;
                            }
                        }
                        else
                        {
                            if (magnitude >= 1000)
                            {
                                convertedInteger = GetNumTerm(digit) + " " + GetMagTerm(period) + " " + convertedInteger; ;
                                magTermUsed = true;
                                magTermNeeded = false;
                            }
                            else
                                convertedInteger = GetNumTerm(digit) + " " + convertedInteger;
                        }
                    }

                    one *= 1000;
                }
                else if (magnitude == ten)
                {
                    if (!magTermUsed)
                        magTermNeeded = true;

                    if (digit != 0)
                    {
                        if (magTermNeeded && magnitude >= 1000)
                        {
                            convertedInteger = GetNumTerm(digit * 10) + " " + GetMagTerm(period) + " " +
                                               convertedInteger;
                            magTermUsed = true;
                            magTermNeeded = false;
                        }
                        else
                            convertedInteger = GetNumTerm(digit * 10) + " " + convertedInteger;
                    }

                    ten *= 1000;
                }
                else if (magnitude == hundred)
                {
                    if (!magTermUsed)
                        magTermNeeded = true;

                    if (digit != 0)
                    {
                        if (magTermNeeded && magnitude >= 1000)
                        {
                            convertedInteger = GetNumTerm(digit) + " hundred " + GetMagTerm(period) + " " +
                                               convertedInteger;
                            magTermUsed = true;
                            magTermNeeded = false;
                        }
                        else
                            convertedInteger = GetNumTerm(digit) + " hundred " + convertedInteger;
                    }

                    hundred *= 1000;
                    period *= 1000;
                }

                magnitude *= 10;
            }

            if (negative)
                convertedInteger = "negative " + convertedInteger;

            return convertedInteger.Substring(0, convertedInteger.Length - 1);
        }

        private static List<int> GetDigits(int number)
        {
            List<int> digits = new List<int>();

            while (number > 0)
            {
                digits.Add(number % 10);
                number /= 10;
            }

            return digits;
        }

        private static string GetMagTerm(int mag)
        {
            return NumericTermDatabase.GetMagAsTerm(mag);
        }

        private static string GetNumTerm(int num)
        {
            return NumericTermDatabase.GetValueAsTerm(num);
        }
    }

    public static class WordToNumberConverter
    {
        public static int Convert(string strToBeConverted)
        {
            if (strToBeConverted == null || strToBeConverted.Equals(""))
                return 0;

            int convertedString = 0;

            string[] words = strToBeConverted.Split(' ');
            
            int magnitude = 1;
            if (words[0].Equals("negative"))
                magnitude = -magnitude;
            bool hundredInEffect = false;

            for (int i = words.Length - 1; i >= 0; i--)
            {
                string word = words[i];
                int value = GetTermValue(word);

                if (value == 0)
                {
                    int mag = GetMagValue(word);

                    if (mag == 0)
                    {
                        if (word.Equals("hundred"))
                        {
                            hundredInEffect = true;
                            magnitude *= 100;
                        }
                    }
                    else
                    {
                        magnitude = magnitude / Math.Abs(magnitude);
                        magnitude *= mag;
                    }
                }
                else
                {
                    convertedString += value * magnitude;

                    if (hundredInEffect)
                    {
                        magnitude /= 100;
                        hundredInEffect = false;
                    }
                }

            }

            return convertedString;
        }

        public static int GetTermValue(string term)
        {
            return NumericTermDatabase.GetTermAsValue(term);
        }

        public static int GetMagValue(string term)
        {
            return NumericTermDatabase.GetTermAsMag(term);
        }
    }

    public static class NumericTermDatabase
    {
        private static Tuple<int, string>[] _magnitudes =
        {
            new Tuple<int, string>(1000000000, "billion"), 
            new Tuple<int, string>(1000000, "million"), 
            new Tuple<int, string>(1000, "thousand"), 
        };

        private static Tuple<int, string>[] _terms =
        {
            new Tuple<int, string>(90, "ninety"), 
            new Tuple<int, string>(80, "eighty"), 
            new Tuple<int, string>(70, "seventy"), 
            new Tuple<int, string>(60, "sixty"), 
            new Tuple<int, string>(50, "fifty"), 
            new Tuple<int, string>(40, "fourty"), 
            new Tuple<int, string>(30, "thirty"), 
            new Tuple<int, string>(20, "twenty"), 
            new Tuple<int, string>(19, "nineteen"), 
            new Tuple<int, string>(18, "eighteen"), 
            new Tuple<int, string>(17, "seventeen"), 
            new Tuple<int, string>(16, "sixteen"), 
            new Tuple<int, string>(15, "fifteen"), 
            new Tuple<int, string>(14, "fourteen"), 
            new Tuple<int, string>(13, "thirteen"), 
            new Tuple<int, string>(12, "twelve"), 
            new Tuple<int, string>(11, "eleven"), 
            new Tuple<int, string>(10, "ten"),
            new Tuple<int, string>(9, "nine"),
            new Tuple<int, string>(8, "eight"),
            new Tuple<int, string>(7, "seven"),
            new Tuple<int, string>(6, "six"),
            new Tuple<int, string>(5, "five"),
            new Tuple<int, string>(4, "four"),
            new Tuple<int, string>(3, "three"),
            new Tuple<int, string>(2, "two"),
            new Tuple<int, string>(1, "one")
        };

        public static string GetValueAsTerm(int value)
        {
            Tuple<int, string> found = _terms.FirstOrDefault(x => x.Item1 == value);

            if (found == null)
                return "";
            return found.Item2;
        }

        public static string GetMagAsTerm(int mag)
        {
            Tuple<int, string> found = _magnitudes.FirstOrDefault(x => x.Item1 == mag);

            if (found == null)
                return "";
            return found.Item2;
        }

        public static int GetTermAsValue(string term)
        {
            Tuple<int, string> found = _terms.FirstOrDefault(x => x.Item2 == term);

            if (found == null)
                return 0;
            return found.Item1;
        }

        public static int GetTermAsMag(string term)
        {
            Tuple<int, string> found = _magnitudes.FirstOrDefault(x => x.Item2 == term);

            if (found == null)
                return 0;
            return found.Item1;
        }
    }
}
