﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_2
{
    internal class Program
    {
        internal static Dictionary<string, string> _intToWord = new Dictionary<string, string>
        {
            {"0", ""},
            {"00", "" },
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
            {"90", "ninety"},
            {"zero", "0" },
            {"one", "1" },
            {"two", "2" },
            {"three", "3" },
            {"four", "4" },
            {"five", "5" },
            {"six", "6" },
            {"seven", "7" },
            {"eight", "8" },
            {"nine", "9" },
            {"ten", "10" },
            {"eleven", "11" },
            {"twelve", "12" },
            {"thirteen", "13" },
            {"fourteen", "14" },
            {"fifteen", "15" },
            {"sixteen", "16" },
            {"seventeen", "17" },
            {"eighteen", "18" },
            {"nineteen", "19" },
            {"twenty", "2" },
            {"thirty", "3" },
            {"forty", "4" },
            {"fifty", "5" },
            {"sixty", "6" },
            {"seventy", "7" },
            {"eighty", "8" },
            {"ninety", "9" }
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

        public static string WordsToNumbers(string phrase)
        {
            List<string> words = phrase.Split(' ').ToList();
            string number = String.Empty;

            int chunkCount = 0;
            for (int i = 0; i < words.Count; i++)
            {
                string word = words[i];

                if (_intToWord.ContainsKey(word))
                {
                    number += _intToWord[word];
                    chunkCount == 3 ? chunkCount = 0 : chunkCount++;
                }
                else if (_prefixes.Contains(word) && words.Count > i + 1 && _prefixes.Contains(words[i + 1]))
                {
                    i++;
                }
            }

            return number;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number");
            var phrase = NumbersToWords(Console.ReadLine());
            Console.WriteLine("Number in words: " + phrase);
            Console.WriteLine("Was: " + WordsToNumbers(phrase));
            Console.ReadKey();
        }
    }
}