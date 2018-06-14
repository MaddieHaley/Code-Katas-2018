using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Day4
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

            Letter current = new Letter(word[0]);

            if (IsVowel(current.Val, false)) return word + "yay";

            Letter first = current;
            for (int i = 1; i < word.Length; i++)
            {
                current.Next = new Letter(word[i]);
                current.Next.Prev = current;
                current = current.Next;
            }

            Letter last = current;

            current = first.Next;
            Letter cutOff = null;
            
            while (current != null)
            {
                if (cutOff == null &&
                    IsVowel(current.Val, true))
                    cutOff = current.Prev;

                current = current.Next;
            }

            if (cutOff == null) cutOff = last.Prev;
            
            last.Next = first;
            first.Prev = last;
            first = cutOff.Next;
            cutOff.Next.Prev = null;
            cutOff.Next = null;

            string output = "";

            current = first;
            while (current != null)
            {
                output += current.Val;
                current = current.Next;
            }

            return output + "ay";

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

    class Letter
    {
        public char Val { get; set; }
        public Letter Next { get; set; }
        public Letter Prev { get; set; }

        public Letter(char _Val)
        {
            Val = _Val;
            Next = null;
            Prev = null;
        }

    }
}
