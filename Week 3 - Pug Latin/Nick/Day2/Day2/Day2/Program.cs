using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cont = true;

            while (cont)
            {
                Console.WriteLine("Beep-boop. Translate text. Boop.");
                string input = Console.ReadLine();

                Console.WriteLine("\nTranslation. Beep.");
                Console.WriteLine(PigLatin.Translate(input));

                Console.WriteLine("\nContinue?");
                if (!Console.ReadLine().ToLower().Equals("y"))
                    cont = false;
            }
        }
    }

    class PigLatin
    {
        private static readonly char[] VOWELS = {'a', 'e', 'i', 'o', 'u'};
        private static readonly char[] MARKS  = {',', '.', '?', '!', ';', ':' };

        public static string Translate(string phrase)
        {
            string output = "";

            foreach (string word in phrase.ToLower().Split(' '))
            {
                if (MARKS.Contains(word[word.Length - 1]))
                    output += TranslateWord(word.Substring(0, word.Length - 1)) + word[word.Length - 1] + " ";
                else
                    output += TranslateWord(word) + " ";
            }

            return output;
        }

        public static string TranslateWord(string word)
        {
            if (VOWELS.Contains(word[0]))
                return word + "yay";
            else
                return OrgWord(word) + "ay";
        }

        public static string OrgWord(string word)
        {
            if (IsConsChunk(word))
                return word[word.Length - 1] + word.Substring(0, word.Length - 1);

            string consChunk = GetConsChunk(word);

            return word.Substring(consChunk.Length, word.Length - consChunk.Length) + consChunk;
        }

        public static string GetConsChunk(string chunk)
        {
            if (chunk.Length == 1)
            {
                if (VOWELS.Contains(chunk[0]) || chunk[0].Equals('y'))
                    return "";
                else
                    return chunk;
            }
            //else if (chunk.Length < 1)
            //    return "";

            int h1s = chunk.Length / 2;
            int h2s = chunk.Length - h1s;

            string h1 = chunk.Substring(0, h1s);
            string h2 = chunk.Substring(h1s, h2s);

            if (IsConsChunk(h1))
                return h1 + GetConsChunk(h2);
            else
                return GetConsChunk(h1);
        }

        private static bool IsConsChunk(string chunk)
        {
            foreach (char c in chunk.ToCharArray())
            {
                if (VOWELS.Contains(c))
                    return false;
            }

            return true;
        }
    }
}
