using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumberToWordConverter.Convert(100456396));

            Console.ReadLine();
        }
    }

    public static class NumberToWordConverter
    {
        public static string Convert(int conversionInt)
        {
            NumericTermDatabase.BuildFields();

            if (conversionInt == 0)
                return "zero";

            bool negative = false;

            if (conversionInt < 0)
            {
                conversionInt = -conversionInt;
                negative = true;
            }

            int[] digits = GetDigits(conversionInt);
            string convertedString = "";

            int spotType = 0;
            int multiplier = 1;
            bool canCheck = true;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int digit = digits[i];

                if (spotType == 0)
                {
                    canCheck = true;
                    string term;

                    if (i - 1 >= 0)
                    {
                        if (digits[i - 1] == 1)
                        {
                            term = NumericTermDatabase.GetTerm(10 + digit);
                            digits[i - 1] = 0;
                        }
                        else
                            term = NumericTermDatabase.GetTerm(digit);
                    }
                    else
                        term = NumericTermDatabase.GetTerm(digit);

                    if (digit != 0)
                    {
                        string mag = NumericTermDatabase.GetMagTerm(multiplier);
                        if (canCheck && !(mag.Equals("hundred") || mag.Equals("")))
                            convertedString = mag + " " + convertedString;

                        convertedString = term + " " + convertedString;
                        canCheck = false;
                    }

                    spotType++;
                }
                else if (spotType == 1)
                {
                    if (digit != 0)
                    {
                        string mag = NumericTermDatabase.GetMagTerm(multiplier);
                        if (canCheck && !(mag.Equals("hundred") || mag.Equals("")))
                            convertedString = mag + " " + convertedString;

                        convertedString = NumericTermDatabase.GetTerm(digit * 10) + " " + convertedString;
                        canCheck = false;
                    }

                    spotType++;
                }
                else if (spotType == 2)
                {
                    if (digit != 0)
                    {
                        string mag = NumericTermDatabase.GetMagTerm(multiplier);
                        if (canCheck && !(mag.Equals("hundred") || mag.Equals("")))
                            convertedString = mag + " " + convertedString;

                        convertedString = NumericTermDatabase.GetTerm(digit) + " hundred " + convertedString;
                        canCheck = false;
                    }

                    spotType = 0;

                    multiplier *= 1000;
                }
            }

            if (negative)
                convertedString = "negative " + convertedString;
            Console.WriteLine(convertedString.Length - 1);
            return convertedString.Substring(0, convertedString.Length - 1);
        }

        private static int[] GetDigits(int digitSource)
        {
            int digitCount = digitSource.ToString().Length;

            int[] digits = new int[digitCount];

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                digits[i] = digitSource % 10;
                digitSource /= 10;
            }

            return digits;
        }
    }

    public static class WordToNumberConverter
    {
        public static int Convert(string conversionString)
        {
            if (conversionString == null || conversionString.Equals(""))
                return 0;

            NumericTermDatabase.BuildFields();
            string[] words = conversionString.Split(' ');

            int multiplier = 1 * NumericTermDatabase.CheckNegativity(words[0]);
            bool hundredInEffect = false;

            int total = 0;

            for (int i = words.Length - 1; i >= 0; i--)
            {
                string word = words[i];
;
                if (NumericTermDatabase.IsMag(word))
                {
                    int mag = NumericTermDatabase.GetMagValue(word);

                    if (mag == 100)
                    {
                        hundredInEffect = true;
                    }
                    else
                    {
                        multiplier /= Math.Abs(multiplier);
                        multiplier *= mag;
                    }
                }
                else if (NumericTermDatabase.CheckNegativity(word) == 1)
                {
                    if (hundredInEffect)
                        multiplier *= 100;

                    total += NumericTermDatabase.GetTermValue(word) * multiplier;

                    if (hundredInEffect)
                    {
                        hundredInEffect = false;
                        multiplier /= 100;
                    }
                }
            }

            return total;
        }
    }

    public static class NumericTermDatabase
    {
        private static Dictionary<int, string> _magnitudes;
        private static Dictionary<int, string> _terms;

        private static void BuildMagnitudes()
        {
            _magnitudes = new Dictionary<int, string>();
            _magnitudes.Add(1000000000, "billion");
            _magnitudes.Add(1000000, "million");
            _magnitudes.Add(1000, "thousand");
            _magnitudes.Add(100, "hundred");
        }

        private static void BuildTerms()
        {
            _terms = new Dictionary<int, string>();
            _terms.Add(90, "ninety");
            _terms.Add(80, "eighty");
            _terms.Add(70, "seventy");
            _terms.Add(60, "sixty");
            _terms.Add(50, "fifty");
            _terms.Add(40, "fourty");
            _terms.Add(30, "thirty");
            _terms.Add(20, "twenty");
            _terms.Add(19, "nineteen");
            _terms.Add(18, "eighteen");
            _terms.Add(17, "seventeen");
            _terms.Add(16, "sixteen");
            _terms.Add(15, "fifteen");
            _terms.Add(14, "fourteen");
            _terms.Add(13, "thirteen");
            _terms.Add(12, "twelve");
            _terms.Add(11, "eleven");
            _terms.Add(10, "ten");
            _terms.Add(9, "nine");
            _terms.Add(8, "eight");
            _terms.Add(7, "seven");
            _terms.Add(6, "six");
            _terms.Add(5, "five");
            _terms.Add(4, "four");
            _terms.Add(3, "three");
            _terms.Add(2, "two");
            _terms.Add(1, "one");
            _terms.Add(0, "");
        }

        public static void BuildFields()
        {
            if (_terms == null)
                BuildTerms();
            if (_magnitudes == null)
                BuildMagnitudes();
        }

        public static int CheckNegativity(string term)
        {
            if (term.Equals("negative"))
                return -1;
            return 1;
        }

        public static bool IsMag(string term)
        {
            return _magnitudes.ContainsValue(term);
        }

        public static int GetMagValue(string term)
        {
            return _magnitudes.FirstOrDefault(x => x.Value == term).Key;
        }

        public static int GetTermValue(string term)
        {
            return _terms.FirstOrDefault(x => x.Value == term).Key;
        }

        public static string GetTerm(int num)
        {
            string output;
            if (_terms.TryGetValue(num, out output))
                return output;
            return "";
        }

        public static string GetMagTerm(int mag)
        {
            string output;
            if (_magnitudes.TryGetValue(mag, out output))
                return output;
            return "";
        }
    }
}
