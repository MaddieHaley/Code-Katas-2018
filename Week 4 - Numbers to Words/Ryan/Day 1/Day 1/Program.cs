using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day_1
{
    class Program
    {
        internal static Dictionary<int, string> _intToWord = new Dictionary<int, string>
        {
            {0, "" },
            {1, "one" },
            {2, "two" },
            {3, "three" },
            {4, "four" },
            {5, "five" },
            {6, "six" },
            {7, "seven" },
            {8, "eight" },
            {9, "nine" },
            {10, "ten" },
            {11, "eleven" },
            {12, "twelve" },
            {13, "thirteen" },
            {14, "fourteen" },
            {15, "fifteen" },
            {16, "sixteen" },
            {17, "seventeen" },
            {18, "eighteen" },
            {19, "nineteen" },
            {20, "twenty" },
            {30, "thirty" },
            {40, "forty" },
            {50, "fifty" },
            {60, "sixty" },
            {70, "seventy" },
            {80, "eighty" },
            {90, "ninety" }
        };

        internal static List<string> _prefixes = new List<string>
        {
            "thousand",
            "million",
            "billion",
            "trillion",
            "quadrillion",
        };

        internal static Dictionary<string, int> _wordToInt = new Dictionary<string, int>
        {
            {"zero", 0 },
            {"one", 1 },
            {"two", 2 },
            {"three", 3 },
            {"four", 4 },
            {"five", 5 },
            {"six", 6 },
            {"seven", 7 },
            {"eight", 8 },
            {"nine", 9 },
            {"ten", 10 },
            {"eleven", 11 },
            {"twelve", 12 },
            {"thirteen", 13 },
            {"fourteen", 14 },
            {"fifteen", 15 },
            {"sixteen", 16 },
            {"seventeen", 17 },
            {"eighteen", 18 },
            {"nineteen", 19 },
            {"twenty", 20 },
            {"thirty", 30 },
            {"forty", 40 },
            {"fifty", 50 },
            {"sixty", 60 },
            {"seventy", 70 },
            {"eighty", 80 },
            {"ninety", 90 }
        };

        internal static Dictionary<string, double> _multipliers = new Dictionary<string, double>
        {
            {"cents", (double) .01 },
            {"dollars", 1 },
            {"thousand", 1000},
            { "million", 1000000},
            { "billion", 1000000000},
            { "trillion", 1000000000000},
            {"quadrillion", 1000000000000000}
        };

        public static string GetPrefix(int group)
        {
            if (group < _prefixes.Count)
                return _prefixes[group];

            return GetPrefix(group - _prefixes.Count) + _prefixes[_prefixes.Count - 1];
        }

        public static string NumberToWords(double number)
        {
            number = Math.Round(number, 2);

            if (Math.Abs(number) < .001) return "zero";

            string numberString = number.ToString(CultureInfo.InvariantCulture);
            if (numberString[numberString.Length - 2] == '.') numberString += '0';

            string numberWords = String.Empty;

            string dollarsString = numberString.Substring(0, numberString.Length - 3);
            string centsString = numberString.Substring(numberString.Length - 2, 2);

            List<int> centsList = centsString.ToList().ConvertAll(x => (int) Char.GetNumericValue(x));

            int cents = Int32.Parse(centsString);

            List<List<int>> dollarGroups = new List<List<int>>();


            for (int i = 0; i < dollarsString.Length; i += 3)
            {
                if (i == 0 && dollarsString.Length % 3 != 0)
                {
                    int mod = dollarsString.Length % 3;
                    dollarGroups.Add(dollarsString.Substring(i, mod).ToList()
                        .ConvertAll(x => (int) Char.GetNumericValue(x)));
                    i -= 3 - mod;
                    continue;
                }

                dollarGroups.Add(dollarsString.Substring(i, 3).ToList()
                    .ConvertAll(x => (int) Char.GetNumericValue(x)));
            }

            for (int i = 0; i < dollarGroups.Count; i++)
            {
                int count = dollarGroups[i].Count;
                bool setPrefix = false;

                int tens = dollarGroups[i][count - 1];
                if (count > 1)
                {
                    tens += dollarGroups[i][count - 2] * 10;
                }


                if (count == 3 && dollarGroups[i][count-3] > 0)
                {
                    numberWords += " " + _intToWord[dollarGroups[i][count - 3]] + " hundred";
                    setPrefix = true;
                }

                if (_intToWord.ContainsKey(tens) && tens != 0)
                {
                    numberWords += " " + _intToWord[tens];
                    setPrefix = true;
                }
                else if (tens != 0)
                {
                    numberWords += " " + _intToWord[dollarGroups[i][count - 2] * 10] + " " + _intToWord[dollarGroups[i][count - 1]];
                    setPrefix = true;
                }

                if (dollarGroups.Count - 1 == i) setPrefix = false;

                numberWords += setPrefix ? " " + GetPrefix(dollarGroups.Count - 2 - i) : "";
            }

            if (numberWords == "")
            {
                numberWords += "zero";
            }

            numberWords += " dollars and ";

            if (cents == 0)
            {
                numberWords += "zero";
            }
            else if (_intToWord.ContainsKey(cents))
            {
                numberWords += _intToWord[cents];
            }
            else
            {
                numberWords += _intToWord[centsList[0] * 10] + " " + _intToWord[centsList[1]];
            }

            numberWords += " cents";

            return numberWords;
        }

        public static double WordsToNumbers(string numberText)
        {
            List<string> words = numberText.Split(' ').ToList();
            double totalSum = 0;
            double currentSum = 0;

            for (var i = 0; i < words.Count; i++)
            {
                string word = words[i];
                if (_wordToInt.ContainsKey(word))
                {
                    currentSum += _wordToInt[word];
                }
                else if (word == "hundred")
                {
                    currentSum *= 100;
                }
                else if (_multipliers.ContainsKey(word))
                {
                    currentSum *= _multipliers[word];
                    if (words.Count > i+1 && !_multipliers.ContainsKey(words[i + 1]))
                    {
                        totalSum += currentSum;
                        currentSum = 0;
                    }
                }
            }

            totalSum += currentSum;

            return totalSum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number: ");
            string words = NumberToWords(Double.Parse(Console.ReadLine()));
            Console.WriteLine("Number in words: " + words);
            Console.WriteLine("Was: " + WordsToNumbers(words));
            Console.ReadKey();
        }
    }
}
