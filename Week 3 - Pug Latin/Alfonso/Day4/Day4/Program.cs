using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    
    class Program
    {
        public static string vowels = "aeiou";
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a word so that it can be translated into Pig Latin!");
            Console.WriteLine(PigLatin(Console.ReadLine()));
            Console.ReadLine();
        }
        public static string PigLatin(string resp)
        {
            var words = resp.ToLower().Split(' ');
            string newWord = "";
            foreach (string word in words)
            {
                newWord += Translate(word) + " ";
            }
            return newWord;
               
        }
        public static string Translate(string word)
        {
            string translate = "";
            if(vowels.IndexOf(word[0]) > -1)
            {
                translate = word + "yay";
            }
            else
            {
                translate = Consonant(word) + "ay";
            }
            return translate;

        }
        public static string Consonant(string word)
        {
            string before = "";
            string after = "";
            string newWord = "";
            Boolean isVowel = false;
            foreach (char letter in word)
            {
                if (isVowel)
                {
                    before += letter;
                }
                else
                {
                    if(vowels.IndexOf(letter) > -1 || (letter == 'y') || letter == word[word.Length -1])
                    {
                        before += letter;
                        isVowel = true;
                    }
                    else
                    {
                        after += letter;
                    }
                }
                
            }
            string[] translate = { before, after };
            foreach(string item in translate)
            {
                newWord += item;
            }

            return newWord;
            
        }
    }
    
}
