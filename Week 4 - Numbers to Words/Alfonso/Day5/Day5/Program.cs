using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        public static string nums = "123456789";
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to be translated into words or the other way around!");
            Console.WriteLine(converter(Console.ReadLine().ToLower()));
            Console.ReadLine();
        }
        internal static Dictionary<string, string> wordToNum = new Dictionary<string, string>()
        {
            {"one", "1" },
            {"two", "2" },
            {"three", "3" },
            {"four", "4" },
            {"five", "5" },
            {"six", "6" },
            {"seven", "7" },
            {"eight", "8" },
            {"nine", "9" },
             {"ten", "10" },
            {"eleven", "11" },
            {"twelve", "12" },
            {"thirteen", "13" },
            {"fourteen", "14" },
            {"fifteen", "15" },
            {"sixteen", "16" },
            {"seventeen", "17" },
            {"eighteen", "18" },
            {"nineteen", "19" },
            {"twenty", "2" },
            {"thirty", "3" },
            {"forty", "4" },
            {"fifty", "5" },
            {"sixty", "6" },
            {"seventy", "7" },
            {"eighty", "8" },
            {"ninety", "9" },

        };
        internal static Dictionary<string, string> numToWord = new Dictionary<string, string>()
        {
            {"1", "one" },
            {"2", "two" },
            {"3", "three" },
            {"4", "four" },
            {"5", "five" },
            {"6", "six" },
            {"7", "seven" },
            {"8", "eight" },
            {"9", "nine" },
        };
        internal static Dictionary<string, string> tens = new Dictionary<string, string>()
        {
            {"10", "ten" },
            {"11", "eleven" },
            {"12", "twelve" },
            {"13", "thirteen" },
            {"14", "fourteen" },
            {"15", "fifteen" },
            {"16", "sixteen" },
            {"17", "seventeen" },
            {"18", "eighteen" },
            {"19", "nineteen" },
            {"2", "twenty" },
            {"3", "thirty" },
            {"4", "forty" },
            {"5", "fifty" },
            {"6", "sixty" },
            {"7", "seventy" },
            {"8", "eighty" },
            {"9", "ninety" },
        };
        public static Dictionary<string, string> length = new Dictionary<string, string>()
        {
            {"thousand", "000" },
            {"million", "000000" },
            {"billion", "000000000" },
            {"trillion", "000000000000" }
        };
        public static string converter(string resp)
        {
            if (nums.Contains(resp[0])) { return Translate(resp) ; } else { return Number(resp); }
        }
        public static string Translate(string word)
        {
            string newWord = "";
            if ((word.Length % 3) == 0) {newWord = to3(word); } else { newWord = not3(word); }
            return newWord;
        }
        public static string toNum(string word)
        {
            return "1";
        }
        public static string getTen(string val)
        {
            string key = tens[val];
            return key;
        }
        public static string to3(string value)
        {
            int ind1 = 0;
            int ind2 = 1;
            int ind3 = 2;
            string newWord = "";
            string num = "";
            while(ind3 <= value.Length -1)
            {
                num = value.Substring(ind1);
                if (value[ind1] != '0') { newWord += getKey(value[ind1].ToString()) + " hundred "; } else {; }
                if (value[ind2] == '1') { newWord += getTen((value[ind2].ToString() + value[ind3].ToString())) + " "; } else if (value[ind2] != '0') { newWord += getTen(value[ind2].ToString()) + "-" + getKey(value[ind3].ToString()) + " "; } else { newWord += getKey(value[ind3].ToString()) + " "; }
                newWord += getSuffix(num.Length) + " ";
                ind1 += 3;
                ind2 += 3;
                ind3 += 3;
            }
            newWord = newWord.Substring(0, newWord.Length - 2);
            return newWord;
        }
        public static string getKey(string val)
        {
            string key = numToWord[val];
            return key;
        }
        public static string getSuffix(int length)
        {
            string suffix = "";
            if (length > 12) { suffix = "trillion"; } else if (length > 9) { suffix = "billion"; } else if (length > 6) { suffix = "million"; } else if(length > 3) { suffix = "thousand"; }
            return suffix;
        }
        public static string getNum(string word)
        {
            string key = wordToNum[word];
            return key;
        }
        public static string getLength(string value)
        {
            string key = length[value];
            return key;
        }
        public static string not3(string word)
        {
            string newWord = "";
            if ((word.Length % 3) == 1) { newWord += getKey(word[0].ToString()) + " " + getSuffix(word.Length) + " " + to3(word.Substring(1)); } else { if (word[0] == '1') { newWord += getTen((word[0].ToString() + word[1].ToString())) + " " + getSuffix(word.Length) + " " + to3(word.Substring(2)); } else if (word[1] != '0') { newWord += getTen(word[0].ToString()) + "-" + getKey(word[1].ToString()) + " " + getSuffix(word.Length) + " " + to3(word.Substring(2)); } }
            return newWord;
        }
        public static string Number(string word)
        {
            string[] suffixes = { "thousand", "million", "billion", "trillion" };
            string[] hundred = new string[30];
            int index = 0;
            int indHelp = 0;
            string[] numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" , "hundred"};
            string[] tens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] words = word.Split(' ');
            string number = "";
            int indHundy;
            foreach(var value in words) { if(numbers.Contains(value)) { if(value == "hundred") { indHundy =  indHelp; if (words.Length <= 2 || suffixes.Contains(words[indHundy + 1])) { number += "00"; } else if((words.Length >= 3 && !(words[indHundy + 1].Contains('-')) && !(tens.Contains(words[indHundy+1])) || suffixes.Contains(words[indHundy + 1]))) {number += "0"; } else {; } } else { number += getNum(value); }}
                else if (value.Contains('-'))
                { string[] wordsplit = value.Split('-'); number += getNum(wordsplit[0]); number += getNum(wordsplit[1]); } else { if (suffixes.Contains(value)) { hundred[index] = value; index++; } }
                indHelp++; }
            if((number.Length % 3) == 0) { if(number.Substring(3).Length < getLength(hundred[0]).Length) { while (number.Substring(3).Length < getLength(hundred[0]).Length) { number += "0"; } } } else if((number.Length % 3) == 1) {
                if ((number.Substring(1).Length < getLength(hundred[0]).Length)) { while (number.Substring(1).Length < getLength(hundred[0]).Length) { number += "0"; } }
            }
            else { if (number.Substring(2).Length < getLength(hundred[0]).Length) { while (number.Substring(2).Length < getLength(hundred[0]).Length) { number += "0"; } } }

            return number;
            }
        }
    }

