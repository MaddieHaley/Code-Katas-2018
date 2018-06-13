using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            PigLatin();
            Console.ReadLine();
        }

        public enum StartType
        {
            Y,
            Consonant,
            Vowel
        }

        static void PigLatin()
        {
            var resp = getInput().ToLower();
            var fin = "";
            if(resp[0] == 'y')
            {
                 var groups = GetGroups(0, resp);
                 Console.WriteLine(groups.Item2 + groups.Item1 + "ay");
            }
            else
            {
                if (getType(resp[0]) == StartType.Consonant)
                {
                    Console.WriteLine("consonant case");
                    var groups = GetGroups(0, resp);
                    Console.WriteLine(groups.Item2 + groups.Item1 + "ay");
                }
                else
                {
                    Console.WriteLine("vowel case");
                    Console.WriteLine(resp + "yay");
                }
            }
            again();
        }

        static void again()
        {
            Console.WriteLine("Would you like to go again?");
            var resp = Console.ReadLine();
            if (resp.Contains("y")) PigLatin();
            else if (resp.Contains("n")) return;
            else
            {
                Console.WriteLine("Sorry, couldn't catch that.");
                again();
            }
        }

        static Tuple<string, string> GetGroups(int index, string str)
        {
            string group = "";
            string rest = "";
            while (getType(str[index]) == StartType.Consonant && index < str.Length)
            {
                group += str[index];
                index++;
            }
            rest = str.Substring(index, str.Length - index);
            return Tuple.Create(group, rest);
        }

        static StartType getType(char fst)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            if (fst == 'y') return StartType.Y;
            else if (vowels.Contains(fst)) return StartType.Vowel;
            else return StartType.Consonant;
        }

        static string getInput()
        {
            Console.Write("enter a phrase: ");
            return Console.ReadLine();
        }
    }
}
