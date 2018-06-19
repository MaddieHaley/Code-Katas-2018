using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using Console = System.Console;

namespace Day1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumberToWordConverter.Convert(800));
            Console.ReadLine();
        }
    }

    public static class NumberToWordConverter
    {
        public static string Convert(int conversionNumber)
        {
            if (conversionNumber == 0)
                return "zero";

            string convertedNumber = "";

            if (conversionNumber < 0)
            {
                convertedNumber += " negative";
                conversionNumber = -conversionNumber;
            }

            convertedNumber += ConvertNumber(conversionNumber);

            return convertedNumber.Substring(1, convertedNumber.Length - 2);
        }

        private static string ConvertNumber(int conversionNumber)
        {
            string convertedNumber = "";

            int[] periods = FindPeriods(conversionNumber);

            for (int i = 0; i < periods.Length; i++)
            {
                if (periods[i] != 0)
                {
                    convertedNumber += " " + ConvertPeriod(periods[i]) + " ";
                    convertedNumber += NumericTermDatabase.GetMagnitude(i, periods.Length);
                }
            }

            if (convertedNumber[convertedNumber.Length - 1] != ' ')
                convertedNumber += " ";

            return convertedNumber;
        }

        private static string ConvertPeriod(int period)
        {
            string convertedPeriod = "";
            int[] digits = FindDigits(period);

            if (digits.Length == 3)
            {
                convertedPeriod += NumericTermDatabase.GetDigitAsString(digits[0]);
                convertedPeriod += " hundred";

                if (digits[1] == 1)
                {
                    convertedPeriod += NumericTermDatabase.GetTeenAsString(digits[2]);
                    return convertedPeriod;
                }

                if (digits[1] != 0)
                    convertedPeriod += " " + NumericTermDatabase.GetTensPlaceAsString(digits[1]);
                if (digits[2] != 0)
                    convertedPeriod += " " + NumericTermDatabase.GetDigitAsString(digits[2]);
            }
            else if (digits.Length == 2)
            {
                if (digits[0] == 1)
                {
                    convertedPeriod += NumericTermDatabase.GetTeenAsString(digits[1]);
                    return convertedPeriod;
                }

                if (digits[0] != 0)
                    convertedPeriod += NumericTermDatabase.GetTensPlaceAsString(digits[1]);
                if (digits[1] != 0)
                    convertedPeriod += " " + NumericTermDatabase.GetDigitAsString(digits[1]);
            }
            else
            {
                convertedPeriod += NumericTermDatabase.GetDigitAsString(digits[0]);
            }

            return convertedPeriod;
        }

        private static int[] FindPeriods(int number)
        {
            int digitCount = CountDigits(number);
            int periodCount = digitCount / 3;

            if (digitCount % 3 != 0)
                periodCount++;

            int[] periods = new int[periodCount];

            for (int i = 0; i < periods.Length; i++)
            {
                int mag = (int)Math.Pow(1000, periodCount - 1 - i);
                if (mag != 0)
                {
                    periods[i] = number / mag;
                    number %= mag;
                }
                else
                    periods[i] = number;
            }

            return periods;
        }

        private static int[] FindDigits(int number)
        {
            int[] digits = new int[CountDigits(number)];
            for (int i = 0; i < digits.Length; i++)
            {
                int mag = (int) Math.Pow(10, digits.Length - 1 - i);
                digits[i] = number / mag;
                number %= mag;
            }

            return digits;
        }

        private static int CountDigits(int number)
        {
            int digits = 0;
            while (number > 0)
            {
                digits++;
                number /= 10;
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

            string[] words = conversionString.Split(' ');
            int convertedString = 0;

            convertedString = ConvertStatement(words);

            if (words[0].Equals("negative"))
                convertedString *= -1;

            return convertedString;
        }

        private static int ConvertStatement(string[] words)
        {
            int convertedValue = 0;
            int currentMultiplier = 1;
            bool resetHundred = false;

            for (int i = words.Length - 1; i >= 0; i--)
            {
                string word = words[i];

                convertedValue += NumericTermDatabase.GetTermValue(word) * currentMultiplier;

                if (resetHundred)
                {
                    currentMultiplier /= 100;
                    resetHundred = false;
                }

                if (word.Equals("hundred"))
                {
                    currentMultiplier *= 100;
                    resetHundred = true;
                }

                if (NumericTermDatabase.IsMagnitudeIdentifier(word))
                {
                    currentMultiplier *= 1000;
                }
            }

            return convertedValue;
        }
    }

    public static class NumericTermDatabase
    {
        private static readonly string[] Magnitudes =
        {
            "billion",
            "million",
            "thousand",
            ""
        };

        public static string GetMagnitude(int periodIndex, int totalPeriods)
        {
            int arrayOffset = Magnitudes.Length - 1 - totalPeriods;

            return Magnitudes[periodIndex + arrayOffset + 1];
        }

        public static bool IsMagnitudeIdentifier(string possibleIdentifier)
        {
            return Magnitudes.Contains(possibleIdentifier);
        }

        public static string GetTensPlaceAsString(int tensValue)
        {
            switch (tensValue)
            {
                case 2:
                    return "twenty";
                case 3:
                    return "thirty";
                case 4:
                    return "fourty";
                case 5:
                    return "fifty";
                case 6:
                    return "sixty";
                case 7:
                    return "seventy";
                case 8:
                    return "eighty";
                case 9:
                    return "ninety";
                default:
                    return "";
            }
        }

        public static string GetTeenAsString(int secondDigit)
        {
            switch (secondDigit)
            {
                case 0:
                    return "ten";
                case 1:
                    return "eleven";
                case 2:
                    return "twelve";
                case 3:
                    return "thirteen";
                case 4:
                    return "fourteen";
                case 5:
                    return "fifteen";
                case 6:
                    return "sixteen";
                case 7:
                    return "seventeen";
                case 8:
                    return "eighteen";
                case 9:
                    return "nineteen";
                default:
                    return "";
            }
        }

        public static string GetDigitAsString(int digit)
        {
            switch (digit)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return "";
            }
        }

        public static int GetTermValue(string word)
        {
            switch (word)
            {
                case "ninety":
                    return 90;
                case "eighty":
                    return 80;
                case "seventy":
                    return 70;
                case "sixty":
                    return 60;
                case "fifty":
                    return 50;
                case "fourty":
                    return 40;
                case "thirty":
                    return 30;
                case "twenty":
                    return 20;
                case "nineteen":
                    return 19;
                case "eighteen":
                    return 18;
                case "seventeen":
                    return 17;
                case "sixteen":
                    return 16;
                case "fifteen":
                    return 15;
                case "fourteen":
                    return 14;
                case "thirteen":
                    return 13;
                case "twelve":
                    return 12;
                case "eleven":
                    return 11;
                case "ten":
                    return 10;
                case "nine":
                    return 9;
                case "eight":
                    return 8;
                case "seven":
                    return 7;
                case "six":
                    return 6;
                case "five":
                    return 5;
                case "four":
                    return 4;
                case "three":
                    return 3;
                case "two":
                    return 2;
                case "one":
                    return 1;
                default:
                    return 0;
            }
        }
    }
}
