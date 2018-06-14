using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatinDay4
{
    class Program
    {
        public static string vowels = "aeiou";
        static void Main(string[] args)
        {
        }

        public static string PigLatin(string phrase)
        {
            var words = phrase.ToLower().Split(' ');
            string fin = "";
            foreach (string word in words) fin += TranslateWord(word) + " ";
            return fin;
        }

        public static string TranslateWord(string word)
        {
            if (vowels.IndexOf(word[0]) > -1) return word + "yay";
            else
            {
                var clusters = getCluster(word);
                return clusters.Item2 + clusters.Item1 + "ay";
            }
        }
        private static Tuple<string, string> getCluster(string word)
        {
            string cluster = "";
            string leftover = "";
            bool found = false;
            foreach(char letter in word.Substring(0, word.Length-1))
            {
                if (found) leftover += letter;
                else
                {
                    if (vowels.IndexOf(letter) > -1 || (letter == 'y' && cluster.Length > 0))
                    {
                        found = true;
                        leftover += letter;
                    }
                    else cluster += letter;
                }
            }
            leftover += word[word.Length-1];
            return Tuple.Create(cluster, leftover);
        }
    }
}
