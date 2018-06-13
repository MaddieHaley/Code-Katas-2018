using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatin_Day3
{
    public class Program
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
            foreach(char letter in word.Substring(0, word.Length-1))
            {
                if ((vowels.IndexOf(letter) > -1) || (letter == 'y' && cluster.Length > 0)) break;
                else cluster += letter;
            }

            return Tuple.Create(cluster, word.Substring(cluster.Length, word.Length - cluster.Length));
        }
    }
}
