using System;
using System.Collections;
using System.Collections.Generic;

namespace Day_4
{
    internal class Program
    {
        internal static Map<string, int> WordToInt = new Map<string, int>
        {
            {"zero", 0},
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9},
            {"ten", 10},
            {"eleven", 11},
            {"twelve", 12},
            {"thirteen", 13},
            {"fourteen", 14},
            {"fifteen", 15},
            {"sixteen", 16},
            {"seventeen", 17},
            {"eighteen", 18},
            {"nineteen", 19},
            {"twenty", 20},
            {"twenty one", 21},
            {"twenty two", 22},
            {"twenty three", 23},
            {"twenty four", 24},
            {"twenty five", 25},
            {"twenty six", 26},
            {"twenty seven", 27},
            {"twenty eight", 28},
            {"twenty nine", 29},
            {"thirty", 30},
            {"thirty one", 31},
            {"thirty two", 32},
            {"thirty three", 33},
            {"thirty four", 34},
            {"thirty five", 35},
            {"thirty six", 36},
            {"thirty seven", 37},
            {"thirty eight", 38},
            {"thirty nine", 39},
            {"forty", 40},
            {"forty one", 41},
            {"forty two", 42},
            {"forty three", 43},
            {"forty four", 44},
            {"forty five", 45},
            {"forty six", 46},
            {"forty seven", 47},
            {"forty eight", 48},
            {"forty nine", 49},
            {"fifty", 50},
            {"fifty one", 51},
            {"fifty two", 52},
            {"fifty three", 53},
            {"fifty four", 54},
            {"fifty five", 55},
            {"fifty six", 56},
            {"fifty seven", 57},
            {"fifty eight", 58},
            {"fifty nine", 59},
            {"sixty", 60},
            {"sixty one", 61},
            {"sixty two", 62},
            {"sixty three", 63},
            {"sixty four", 64},
            {"sixty five", 65},
            {"sixty six", 66},
            {"sixty seven", 67},
            {"sixty eight", 68},
            {"sixty nine", 69},
            {"seventy", 70},
            {"seventy one", 71},
            {"seventy two", 72},
            {"seventy three", 73},
            {"seventy four", 74},
            {"seventy five", 75},
            {"seventy six", 76},
            {"seventy seven", 77},
            {"seventy eight", 78},
            {"seventy nine", 79},
            {"eighty", 80},
            {"eighty one", 81},
            {"eighty two", 82},
            {"eighty three", 83},
            {"eighty four", 84},
            {"eighty five", 85},
            {"eighty six", 86},
            {"eighty seven", 87},
            {"eighty eight", 88},
            {"eighty nine", 89},
            {"ninety", 90},
            {"ninety one", 91},
            {"ninety two", 92},
            {"ninety three", 93},
            {"ninety four", 94},
            {"ninety five", 95},
            {"ninety six", 96},
            {"ninety seven", 97},
            {"ninety eight", 98},
            {"ninety nine", 99}
        };

        internal static Map<string, long> Multipliers = new Map<string, long>
        {
            {"thousand", 1000},
            {"million", 1000000},
            {"billion", 1000000000},
            {"trillion", 1000000000000},
            {"quadrillion", 1000000000000000}
        };

        public static string GetPrefix(int chunk)
        {
            if (chunk < Multipliers.Count())
                return Multipliers.Reverse[(long) Math.Pow(1000, chunk + 1)];

            return GetPrefix(chunk - Multipliers.Count()) + Multipliers.Reverse[(Multipliers.Count() - 1) * 10];
        }

        public static string NumbersToWords(long number)
        {
            var words = string.Empty;

            if (number == 0)
            {
                words = "zero";
                return words;
            }

            for (var count = 0; number != 0; count++)
            {
                var emptyChunk = true;
                var chunk = (int) (number % 1000);
                var hundreds = chunk / 100;
                var tens = chunk % 100;

                var wordChunk = "";

                if (hundreds != 0)
                {
                    emptyChunk = false;
                    wordChunk += WordToInt.Reverse[hundreds];
                }

                if (tens != 0)
                {
                    emptyChunk = false;
                    wordChunk += WordToInt.Reverse[tens] + (words.Length > 0 ? " " + words : "");
                }

                if (!emptyChunk) wordChunk += GetPrefix(count) + (words.Length > 0 ? " " + words : "");

                words = wordChunk + (words.Length > 0 ? " " + words : "");

                number /= 1000;
            }

            return words;
        }


        public static long WordsToNumbers(string phrase)
        {
            long number = 0;
            long currentSum = 0;

            var words = phrase.Split(' ');
            for (var i = 0; i < words.Length; i++)
            {
                var word = words[i];
                if (WordToInt.Forward.Contains(word))
                {
                    if (words.Length > i + 1 && words[i + 1] == "hundred")
                        currentSum += WordToInt.Forward[word] * 100;
                    else
                        currentSum += WordToInt.Forward[word];
                }
                else if (Multipliers.Forward.Contains(word))
                {
                    currentSum *= Multipliers.Forward[word];
                    if (words.Length == i + 1 || !Multipliers.Forward.Contains(words[i + 1]))
                    {
                        number += currentSum;
                        currentSum = 0;
                    }
                }
            }

            number += currentSum;

            return number;
        }

        private static void Main()
        {
            Console.WriteLine("Please enter a number");
            var phrase = NumbersToWords(long.Parse(Console.ReadLine()));
            Console.WriteLine("Number in words: " + phrase);
            Console.WriteLine("Was: " + WordsToNumbers(phrase));
            Console.ReadKey();
        }

        public class Map<T1, T2> : IEnumerable<KeyValuePair<T1, T2>>
        {
            private readonly Dictionary<T1, T2> _forward = new Dictionary<T1, T2>();
            private readonly Dictionary<T2, T1> _reverse = new Dictionary<T2, T1>();

            public Map()
            {
                Forward = new Indexer<T1, T2>(_forward);
                Reverse = new Indexer<T2, T1>(_reverse);
            }

            public Indexer<T1, T2> Forward { get; }
            public Indexer<T2, T1> Reverse { get; }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public IEnumerator<KeyValuePair<T1, T2>> GetEnumerator()
            {
                return _forward.GetEnumerator();
            }

            public void Add(T1 t1, T2 t2)
            {
                _forward.Add(t1, t2);
                _reverse.Add(t2, t1);
            }

            public int Count()
            {
                return _forward.Count;
            }

            public class Indexer<T3, T4>
            {
                private readonly Dictionary<T3, T4> _dictionary;

                public Indexer(Dictionary<T3, T4> dictionary)
                {
                    _dictionary = dictionary;
                }

                public T4 this[T3 index]
                {
                    get => _dictionary[index];
                    set => _dictionary[index] = value;
                }

                public bool Contains(T3 key)
                {
                    return _dictionary.ContainsKey(key);
                }
            }
        }
    }
}