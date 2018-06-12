using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            string translated = "";
            Console.WriteLine("Enter a word or phrase to be translated into Pig Latin!");
            string toBe = Console.ReadLine();
            char space = ' ';
            string transPart = "";
            if(Contains(toBe, space))
            {
                string[] words = toBe.Split(' ');
                foreach (string item in words)
                {
                    transPart = newWord(item);
                    translated += transPart;
                    translated += " ";
                }
            }
            else
            {
                translated = newWord(toBe);
            }
            Console.WriteLine(translated.ToLower());
            Console.ReadLine();
        }

        static Boolean isVowel(char letter)     
        {
            char[] vowels = new char[] { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };
            Boolean Vowel;
            int count = 0;
            foreach (char item in vowels)
            {
                if (item == letter)
                {
                    count += 1;
                }
            }
            if (count > 0)
            {
                Vowel = true;
            }
            else
            {
               Vowel = false; 
            }
            return Vowel;
        }
        static String newWord(String word)
        {
            string newWord = "";
            char[] wordArray = word.ToCharArray();
            char[] translatedWord = new char[word.Length];
            Boolean Vowel1;
            int index;
            int k = 0;
            int count = 0;
            // Begins with Consonant
            index = count;
           if(word.Length > 2)
            {
                if (!(isVowel(wordArray[0])))
                {
                    for (int i = 0; i < (wordArray.Length); i++)
                    {

                        Vowel1 = isVowel(wordArray[i]);
                        if (!Vowel1)
                        {


                            count += 1;
                        }
                        else
                        {
                            k = i;
                            break;
                        }

                    }
                    index = count;
                    if (index < 1)
                    {
                        index = 1;
                    }
                    for (int h = 0; (h < wordArray.Length - 1); h++)
                    {

                        Vowel1 = isVowel(wordArray[h]);
                        if (!Vowel1)
                        {

                            translatedWord[word.Length - index] = wordArray[h];



                        }
                        else
                        {
                            break;
                        }
                        index -= 1;
                    }
                    index = k;
                    for (int j = 0; j < (wordArray.Length - index); j++)
                    {
                        translatedWord[j] = wordArray[k];
                        k += 1;
                    }
                    foreach (char item in translatedWord)
                    {
                        newWord = newWord + item;

                    }
                    newWord = newWord + "ay";
                }

            }
           else
            {
                char[] newOne = { word[1], word[0] };
                foreach (char item in newOne)
                {
                    newWord = newWord + item;
                }
                newWord += "ay";
            }
            // Begins with vowel
            if (isVowel(wordArray[0]))
            {
                newWord = word;
                newWord = newWord + "yay";
            }
            return newWord;
        }
        static Boolean Contains(string s1, char s2)
        {
            int number = 0;
            char[] s1Array = s1.ToCharArray();
            foreach (char item in s1Array)
            {
                if(item == s2)
                {
                    number += 1;
                }
               
            }
            if(number > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
