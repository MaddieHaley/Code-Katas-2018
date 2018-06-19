using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        public static string vowels = "aeiou";
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a word to be translated into Pig Latin!");
            Console.WriteLine(PigLatin(Console.ReadLine()));
            Console.ReadLine();
        }
        public static string PigLatin(string resp)
        {
            string translated = "";
            string[] words = resp.ToLower().Split(' ');
            foreach (string item in words)
            {
                translated = translated + Translate(item) + " ";
            }
            return translated;
        }
        public static string Translate(string Word)
        {
            string newWord = "";
            if(vowels.IndexOf(Word[0]) > -1)
            {
                newWord = Word + "yay";
            }
            else
            {
                var consonant = getConsonant(Word);
                newWord = consonant.Item1 + consonant.Item2 + "ay";
            }
            return newWord;
        }
        public static Tuple<string, string>  getConsonant(string word)
        {
            string beginning = "";
            string end = "";
            int index = 0;
            foreach (char letter in word)
            {
                if(vowels.IndexOf(letter) > -1 || letter == 'y'  || letter == word[word.Length - 1])
                {
                    index = word.IndexOf(letter);
                    break;
                }
                else
                {
                    end += letter;
                }
                
            }
            beginning = word.Substring(index);
            return Tuple.Create(beginning, end);
        }
    }
}
