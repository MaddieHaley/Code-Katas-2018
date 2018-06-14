using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a word to be translated into Pig Latin\n");
            Console.WriteLine(Translate(Console.ReadLine()));
            Console.ReadLine();
            Console.ReadLine();
        }
        public static String Translate(string resp)
        {
            resp.ToLower();
            
            
            char[] respArray = resp.ToCharArray();
            string ay = "";
            if (resp.Contains(' '))
                
            {
                string[] words = resp.Split(' ');
                foreach (string item in words)
                {
                     ay += PigLatin(item) + " ";
                }
                
            }
            else
            {
                ay = PigLatin(resp);
            }
            return ay;
        }
        static type Type(char letter)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            if(letter == 'y')
            {
                return type.y;
            }
            else if (vowels.Contains(letter)) {
                return type.vowel;
            }
            else
            {
                return type.consonant;
            }
        }
         enum type
        {
            consonant,
            vowel,
            y
        } static string PigLatin(string Resp)
        {
            string newWord = "";
            string afterVowel = "";
            char[] respArray = Resp.ToCharArray();
            int index = 1;
            if (Type(respArray[0]) == type.vowel)
            {
                newWord = Resp + "yay";
            }
            else if (Type(respArray[0]) == type.consonant || Type(respArray[0]) == type.y)
            {
                newWord = respArray[0] + newWord;
                while (index < Resp.Length && Type(respArray[index]) == type.consonant)
                {
                    newWord = newWord + respArray[index];
                    index++;
                }
                if (index == (Resp.Length))
                {
                    afterVowel = Resp.Substring(index - 1);
                }
                else
                {
                    afterVowel = Resp.Substring(index);
                }
                newWord = afterVowel + newWord;
                newWord += "ay";
            }
            return newWord;
        }
    }
}
