using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_2
{
    internal class Program
    {
        internal static Dictionary<string, string> _intToWord = new Dictionary<string, string>
        {
            {"0", ""},
            {"1", "one"},
            {"2", "two"},
            {"3", "three"},
            {"4", "four"},
            {"5", "five"},
            {"6", "six"},
            {"7", "seven"},
            {"8", "eight"},
            {"9", "nine"},
            {"10", "ten"},
            {"11", "eleven"},
            {"12", "twelve"},
            {"13", "thirteen"},
            {"14", "fourteen"},
            {"15", "fifteen"},
            {"16", "sixteen"},
            {"17", "seventeen"},
            {"18", "eighteen"},
            {"19", "nineteen"},
            {"20", "twenty"},
            {"30", "thirty"},
            {"40", "forty"},
            {"50", "fifty"},
            {"60", "sixty"},
            {"70", "seventy"},
            {"80", "eighty"},
            {"90", "ninety"}
        };

        internal static List<string> _prefixes = new List<string>
        {
            "",
            "thousand",
            "million",
            "billion",
            "trillion",
            "quadrillion"
        };

        public static string GetPrefix(int chunk)
        {
            if (chunk < _prefixes.Count)
                return _prefixes[chunk];

            return GetPrefix(chunk - _prefixes.Count) + _prefixes[_prefixes.Count - 1];
        }

        public static string NumbersToWords(string number)
        {
            var words = string.Empty;
            var chunks = new List<string>();

            for (var i = 0; i < number.Length; i++)
            {
                var c = number[i];
                if (i % 3 == 0)
                {
                    if (i != 0)
                        chunks[chunks.Count - 1] = String.Join("", chunks[chunks.Count - 1].Reverse());
                    chunks.Add(string.Empty);
                }

                chunks[chunks.Count - 1] += c.ToString();
            }

            chunks[chunks.Count - 1] = String.Join("", chunks[chunks.Count - 1].Reverse());

            for (var i = 0; i < chunks.Count; i++)
            {
                var chunk = chunks[i];

                if (chunk.Length == 3 && chunk[2] != '0')
                    words += " " + _intToWord[chunk[2].ToString()] + " hundred";

                if (chunk.Length > 1 && _intToWord.ContainsKey(chunk[1].ToString() + chunk[0]))
                {
                    words += " " + _intToWord[chunk[1].ToString() + chunk[0]];
                }
                else if (chunk.Length > 1)
                {
                    words += " " + _intToWord[chunk[1] + "0"];
                    words += " " + _intToWord[chunk[0].ToString()];
                }
                else
                {
                    words += " " + _intToWord[chunk[0].ToString()];
                    if (chunk[0] == '0' && i == chunks.Count && words.Trim() == "")
                        words += "zero";
                }

                words += " " + GetPrefix(chunks.Count - 1 - i);
            }

            return words.Trim();
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number");
            var words = NumbersToWords(Console.ReadLine());
            Console.WriteLine("Number in words: " + words);
            Console.ReadKey();
        }
    }
}