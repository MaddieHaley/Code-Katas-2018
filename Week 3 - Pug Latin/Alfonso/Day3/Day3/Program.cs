using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input a word or phrase so that it can be translated\n");
            
            Console.WriteLine(PigLatin(Console.ReadLine().ToLower()));
            Console.ReadLine();
            Console.ReadLine();
            
        }
        public static string Translate(string resp)
        {
            
            char[] respArray = resp.ToCharArray();
            string newWord = "";
            List<char> last = new List<char>();
            List<char> start = new List<char>();
            int index = 0;
            if (type(respArray[0]) == Typeof.vowel)
            {
                newWord = resp + "yay";
            }
            else
            {
                for(int i = 0; i < resp.Length; i++)
                {
                    while(type(respArray[i]) == Typeof.consonant){
                        last.Add(respArray[i]);
                        break;
                    }
                    if(type(respArray[i]) == Typeof.vowel || type(respArray[i]) == Typeof.y )
                    {

                        for (index = i; index < resp.Length; index++)
                        {
                            start.Add(respArray[index]);
                        }
                        break;
                    }
                }
                newWord = String.Join("", start) + String.Join("", last) + "ay";
          
            }
            return newWord;

        }
        public enum Typeof{
            consonant,
            vowel,
            y
        }
        public static Typeof type(char item)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            if (vowels.Contains(item)){
                return Typeof.vowel;
            }
            else if(item == 'y')
            {
                return Typeof.y;
            }
            else
            {
                return Typeof.consonant;
            }
    }
        public static string PigLatin(string word)
        {
            string translated = "";
            if(word.Contains(' '))
            {
                string[] words = word.Split(' ');
                foreach (string item in words)
                {
                    translated += Translate(item) + " ";
                }
            }
            else
            {
                translated = Translate(word);
            }
            return translated;
        }
    }

}
