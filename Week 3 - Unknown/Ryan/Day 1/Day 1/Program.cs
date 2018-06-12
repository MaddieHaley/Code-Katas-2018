using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_1
{
    class Program
    {
        private static readonly char[] Consonants = { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Z'};

        public static string PigLatinTranslator(string english)
        {
            string[] words = english.Split(' ');
            string pigLatin = String.Empty;
            foreach (string word in words)
            {
                List<char> end = new List<char>();
                List<char> beginning = new List<char>();
                if (Consonants.Contains(Char.ToUpper(word[0])) || Char.ToUpper(english[0]) == 'Y')
                {
                    end.Add(word[0]);
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (Consonants.Contains(word[i]))
                        {
                            end.Add(word[i]);
                        }
                        else
                        {
                            beginning.AddRange(word.Substring(i+1));
                            break;
                        }
                    }

                    end.AddRange("ay");
                }
                else
                {
                    beginning.AddRange(word);
                    end.AddRange("yay");
                }

                pigLatin += String.Join("", beginning) + String.Join("", end) + " ";
            }

            return pigLatin;
        }

        public static void Main()
        {
            Console.WriteLine("Enter a phrase to be translated");
            Console.WriteLine(PigLatinTranslator(Console.ReadLine()));
            Console.ReadKey();
        }
    }
}
