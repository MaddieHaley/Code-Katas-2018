using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralsDay2
{
    class Program
    {
        public static string numbers = "123456789";
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to be translated into a Roman Numeral or the other way around");
            Console.WriteLine(converter(Console.ReadLine().ToUpper()));
            Console.ReadLine();
        }
        internal static Dictionary<string, int> getNumfromNumeral = new Dictionary<string, int>()
        {
            {"M", 1000},
            {"D", 500 },
            {"C", 100 },
            {"L", 50 },
            {"X", 10 },
            {"V", 5 },
            {"I", 1},
        };
        internal static Dictionary<int, string> RomanNumeral = new Dictionary<int, string>()
        {
            {1000, "M" },
            {900, "CM" },
            {500, "D" },
            {400, "CD" },
            {100, "C" },
            {90, "XC" },
            {50, "L" },
            {40, "XL" },
            {10, "X" },
            {9, "IX" },
            {5, "V" },
            {4, "IV" },
            {1, "I" }
        };
        public static string converter(string resp)
        {
            string translatedWord = "";
            if (numbers.Contains(resp[0]))
            {
                translatedWord += translateNum(resp);
            }
            else
            {
                translatedWord += translatedNumeral(resp);
            }
            return translatedWord;
        }
        public static string translateNum(string resp)
        {
            string romanNumeral = "";
            int originalNumber = int.Parse(resp);
            while(originalNumber > 0)
            {
                foreach (var pair in RomanNumeral)
                {
                    if((originalNumber - pair.Key) >= 0)
                    {
                        romanNumeral += pair.Value;
                        originalNumber -= pair.Key;
                        break;
                    }
                }
            }
            return romanNumeral;
        }
        public static int translatedNumeral(string word)
        {

            int number = 0;
            int index = 0;
            char[] arrayOfNumerals = word.ToCharArray();
            foreach (char numeral in arrayOfNumerals)
            {
                foreach (var pair in getNumfromNumeral)
                {
                    
                    if (numeral.ToString() == pair.Key)
                    {
                        if (numeral == 'C' && (arrayOfNumerals[index + 1] == 'D' || arrayOfNumerals[index + 1] == 'M')) { number -= 100; }
                        else if (numeral == 'X' && (arrayOfNumerals[index + 1] == 'C' || arrayOfNumerals[index + 1] == 'L')) { number -= 10; }
                        else { number += pair.Value;  }
                    }
                }
                index++;
            }
            return number;
        }
    }
}
