using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        public enum StartType
        {
            Y,
            Consonant,
            Vowel
        }
        static void Main(string[] args)
        {
            PigLatin();
            Console.ReadLine();
        }
        static void PigLatin()
        {
            Console.WriteLine("enter a phrase: ");
            var words = Console.ReadLine().Split(' ');
            foreach(string word in words)
            {
                Console.Write(PigLatinWord(word) + " ");
            }
        }

        public static string PigLatinWord(string word)
        {
            switch (getType(word[0]))
            {
                case StartType.Vowel:
                    return word + "yay";
                default:
                    var groups = group(word);
                    return groups.Item2 + groups.Item1 + "ay";
            }
        }

        static Tuple<string, string> group(string word)
        {
            string fst = "";
            string snd = "";
            foreach(char letter in word.Substring(0, word.Length-2))
            {
                if (letter == 'y' && fst.Length > 0) break;
                else if (getType(letter) == StartType.Consonant || getType(letter) == StartType.Y) fst += letter;
                else break;
            }
            snd = word.Substring(fst.Length, word.Length - fst.Length);
            return Tuple.Create(fst, snd);
        }

        static StartType getType(char ch)
        {
            Dictionary<char, StartType> typeFinder = new Dictionary<char, StartType>();
            typeFinder.Add('a', StartType.Vowel);
            typeFinder.Add('b', StartType.Consonant);
            typeFinder.Add('c', StartType.Consonant);
            typeFinder.Add('d', StartType.Consonant);
            typeFinder.Add('e', StartType.Vowel);
            typeFinder.Add('f', StartType.Consonant);
            typeFinder.Add('g', StartType.Consonant);
            typeFinder.Add('h', StartType.Consonant);
            typeFinder.Add('i', StartType.Vowel);
            typeFinder.Add('j', StartType.Consonant);
            typeFinder.Add('k', StartType.Consonant);
            typeFinder.Add('l', StartType.Consonant);
            typeFinder.Add('m', StartType.Consonant);
            typeFinder.Add('n', StartType.Consonant);
            typeFinder.Add('o', StartType.Vowel);
            typeFinder.Add('p', StartType.Consonant);
            typeFinder.Add('q', StartType.Consonant);
            typeFinder.Add('r', StartType.Consonant);
            typeFinder.Add('s', StartType.Consonant);
            typeFinder.Add('t', StartType.Consonant);
            typeFinder.Add('u', StartType.Vowel);
            typeFinder.Add('v', StartType.Consonant);
            typeFinder.Add('w', StartType.Consonant);
            typeFinder.Add('x', StartType.Consonant);
            typeFinder.Add('y', StartType.Y);
            typeFinder.Add('z', StartType.Consonant);
            StartType val;
            typeFinder.TryGetValue(ch, out val);
            return val;
        }
    }
}
