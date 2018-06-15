using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            do
            {
                Console.WriteLine("Activating latent latin-like powers...");
                input = Console.ReadLine();

                Console.WriteLine("\nDid you mean:");
                Console.WriteLine(PigLatin.Translate(input));

                Console.WriteLine("\nContinue? (y/n)");
                input = Console.ReadLine();
                if (input == null) input = "";

                Console.WriteLine();
            } while (input.ToLower().Equals("y"));
        }
    }

    static class PigLatin
    {
        public static string Translate(string phrase)
        {
            if (phrase == null || phrase.Equals(""))
                return "";

            string output = "";

            foreach (string word in phrase.ToLower().Split(' '))
            {
                if (word[word.Length - 1] < 97)
                    output += TranslateWord(word.Substring(0, word.Length - 1)) + word[word.Length - 1] + " ";
                else
                    output += TranslateWord(word) + " ";
            }

            return output.Substring(0, output.Length - 1);
        }

        public static string TranslateWord(string word)
        {
            if (word == null || word.Equals(""))
                return "";
            if (IsVowel(word[0], false))
                return word + "yay";

            int vCount = VCount(word);
            int i1 = 1;
            int i2 = word.Length - 1;
            bool l1Move = true;
            bool l2Move = true;

            while (i1 != i2 && l1Move && l2Move && vCount > 0)
            {
                if (l1Move)
                {
                    if (IsVowel(word[i1], true))
                    {
                        vCount--;
                        l1Move = false;
                    }
                    else
                        i1++;
                }

                if (l2Move)
                {
                    if (IsVowel(word[i2], true))
                    {
                        vCount--;
                    }

                    if (vCount <= 0)
                    {
                        l2Move = false;
                    }
                }
            }

            int cutoff = 1;

            if (l1Move && l2Move)
            {
                cutoff = word.Length - 1;
            }
            else if (!l1Move)
            {
                cutoff = i1;
            }
            else if (!l2Move)
            {
                cutoff = i2;
            }

            return word.Substring(cutoff, word.Length - cutoff) + word.Substring(0, cutoff) + "ay";

        }

        private static int VCount(string word)
        {
            int count = 0;
            for (int i = 1; i < word.Length; i++)
                if (IsVowel(word[i], true))
                    count++;
            return count;
        }

        private static bool IsVowel(char c, bool inclY)
        {
            if (c == 'a' ||
                c == 'e' ||
                c == 'i' ||
                c == 'o' ||
                c == 'u')
                return true;
            if (inclY && c == 'y')
                return true;
            return false;
        }
    }
}
