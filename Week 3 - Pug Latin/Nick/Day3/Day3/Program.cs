using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {

            string input;

            do
            {
                Console.WriteLine("Enter text to be pig-latinised:");
                input = Console.ReadLine();

                if (input == null)
                    input = "";

                Console.WriteLine("\nTranslation:");
                Console.WriteLine(PigLatin.Translate(input) + "\n");

                Console.WriteLine("Do you wish to continue?");
                input = Console.ReadLine();

                if (input == null)
                    input = "";

                Console.WriteLine();
            } while (input.ToLower().Equals("y"));

            Console.ReadLine();
        }
    }

    static class PigLatin
    {
        public static int total = 0;
        public static int sampleSize = 0;

        public static string Translate(string phrase)
        {
            if (phrase == null || phrase.Equals(""))
                return "";

            string output = "";

            foreach (string word in phrase.ToLower().Split(' '))
            {
                char first = word[word.Length - 1];
                if (first < 97)
                    output += TranslateWord(word.Substring(0, word.Length - 1)) + word[word.Length - 1] + " ";
                else
                    output += TranslateWord(word) + " ";
            }

            return output.Substring(0, output.Length - 1);
        }

        public static string TranslateWord(string word)
        {
            sampleSize++;

            if (IsVowel(word[0], false))
                return word + "yay";
            else if (AllConsonants(word))
            {
                sampleSize--;
                return word[word.Length - 1] + word.Substring(0, word.Length - 1) + "ay";
            }

            int start = (int)Math.Round((double)total/sampleSize);
            int index = word.Length - 1;

            for (int offset = 0; offset < word.Length; offset++)
            {
                Console.WriteLine(index);
                int li = start - offset;
                int ri = start + offset;

                if (0 < li && li < word.Length)
                {
                    if (li < index && IsVowel(word[li], true))
                    {
                        index = li;
                    }
                }
                if (0 < ri && ri < word.Length)
                {
                    if (ri < index && IsVowel(word[ri], true))
                    {
                        index = ri;
                    }

                }
            }

            total += index;

            return word.Substring(index, word.Length - index) + word.Substring(0, index) + "ay";

        }

        private static bool AllConsonants(string text)
        {
            if (IsVowel(text[0], false))
                return false;

            for (int i = 1; i < text.Length; i++)
            {
                if (IsVowel(text[i], true))
                    return false;
            }

            return true;
        }

        private static bool IsVowel(char c, bool incY)
        {
            if (c == 'a' ||
                c == 'e' ||
                c == 'i' ||
                c == 'o' ||
                c == 'u')
                return true;
            else if (incY && c == 'y')
                return true;
            return false;
        }

    }
}
