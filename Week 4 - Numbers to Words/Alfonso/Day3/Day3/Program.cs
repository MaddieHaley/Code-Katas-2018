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
            Console.WriteLine("Enter a number to be translated into words or some words to be translated into a dollar!");
            Console.WriteLine(Translate(Console.ReadLine().ToLower()));
            Console.ReadLine();
        }
        public static string Translate(string resp)
        {
            string key = "";
            if (wordToNum.ContainsKey(resp[0])) {
                key = forPart(resp);
            }
            else
            {
                key = wordToNums(resp).ToString();
            }
            return key;
        }
        public static Dictionary<char, string> wordToNum = new Dictionary<char, string>()
        {
            {'0', "" },
            {'1', "one" },
            {'2', "two" },
            {'3', "three" },
            {'4', "four" },
            {'5', "five" },
            {'6', "six" },
            {'7', "seven" },
            {'8', "eight" },
            {'9', "nine" },
        };
        public static Dictionary<string, string> tens = new Dictionary<string, string>()
            {
            {"00", "" },
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
            {"20", "twenty" },
            {"30", "thirty" },
            {"40", "forty" },
            {"50", "fifty" },
            {"60", "sixty" },
            {"70", "seventy" },
            {"80", "eighty" },
            {"90", "ninety" }
            };
        public static string getKey(char value)
        {
            string number = wordToNum[value];
            return number;
        }
        public static string getTen(string value)
        {
            string number = tens[value];
            return number;
        }
        public static string forPart(string number)
        {
            int index = 1;
            string translated = "";
            string num = "";
            int length = 0;
            int k = 0;
            string after = "";
            if ((number.Length % 3) == 0)
            {
                for (int i = 0; i < number.Length; i++)
                {
                    num = number.Substring(i);
                    if ((index % 3) == 1 && getKey(number[i]) != "")
                    {
                        translated += getKey(number[i]) + " hundred ";
                    }
                    else if ((index % 3) == 2)
                    {
                        translated += getTen(number[i] + 0.ToString());
                    }
                    else if ((index % 3) == 0 && getKey(number[i]) != "")
                    {
                        translated += "-" + getKey(number[i]) + getPrefix(num);
                    }
                    index++;
                }
            }
            else
            {
                length = number.Length % 3;
                for (int j = 0; j < length; j++)
                {
                    if (j == 0 && number.Length > 1)
                    {
                        if (number.Length == 4 || number.Length == 7 || number.Length == 10)
                        {
                            translated += getKey(number[j]);
                        }
                        else if (getKey(number[j]) == "one")
                        {
                            k++;
                            translated += getTen(number[j] + number[j].ToString());
                            break;
                        }
                        else
                        {
                            translated += getTen(number[j] + 0.ToString().ToString());
                        }
                        k++;
                    }
                    else
                    {
                        if (getKey(number[j]) != "" && number.Length > 1)
                        {
                            translated += "-" + getKey(number[j]);
                            k++;
                        }
                        else
                        {
                            translated += getKey(number[j]);
                            k++;
                        }

                    }
                }
                translated += getPrefix(number);
                after = number.Substring(k);
                for (int i = 0; i < after.Length; i++)
                {
                    num = after.Substring(i);
                    if ((index % 3) == 1 && getKey(after[i]) != "")
                    {
                        translated += getKey(after[i]) + " hundred ";
                    }
                    else if ((index % 3) == 2)
                    {
                        translated += getTen(after[i] + 0.ToString());
                    }
                    else if ((index % 3) == 0)
                    {
                        if (getKey(after[i]) != "")
                        {
                            translated += "-" + getKey(after[i]) + getPrefix(num);
                        }
                        else
                        {
                            translated += getKey(after[i]) + getPrefix(num);
                        }
                    }
                    index++;
                }
            }
            return translated;
        }
        public static string getPrefix(string len)
        {
            int length = len.Length;
            if ((length > 3 && length < 6))
            {
                while (length < 6)
                {
                    length++;
                }
            }

            if ((length > 6 && length < 9))
            {
                while (length < 9)
                {
                    length++;
                }
            }
            if ((length > 9 && length < 12))
            {
                while (length < 12)
                {
                    length++;
                }
            }
            length = length / 3;
            switch (length)
            {
                case 0: return "";
                case 1: return "";
                case 2: return " thousand ";
                case 3: return " million ";
                case 4: return " billion";
                default: return "1";
            }
        }
        public static Dictionary<string, string> numToWord = new Dictionary<string, string>()
        {
            {"one", "1" },
            {"two", "2"},
            {"three","3" },
            {"four", "4" },
            {"five", "5" },
            {"six", "6"},
            {"seven", "7" },
            {"eight", "8" },
            {"nine", "9" },
            {"twenty", "2" },
            {"thirty", "3" },
            {"forty", "4" },
            {"fifty", "5" },
            {"sixty", "6" },
            {"seventy", "7" },
            {"eighty", "8" },
            {"ninety", "9" },
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
        };
        public static Dictionary<string, long> Format = new Dictionary<string, long>()
        {
            {"thousand", 1000 },
            {"million", 1000000 },
            {"billion" , 1000000000}
        };
        public static long getInt(string value)
        {
            long val = Format[value];
            return val;
        }
        public static string getNum(string value)
        {
            string number = numToWord[value];
            return number;
        }
        public static long wordToNums(string resp)
        {
            string[] numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] hundred = { "thousand", "million", "billion" };
            string[] words = resp.Split(' ');
            string number = "";
            string W = "";
            int index = 0;
            long num = 0;
            long final = 0;
            long before = 0;
            string[] inHundred = new string[100]; 
            foreach (var word in words)
            {
                if (word.Contains('-'))
                {
                    string [] wordSplit = word.Split('-');
                    W = wordSplit[0];
                    number += getNum(W);
                    W = wordSplit[1];
                    number += getNum(W);
                }
                if (numbers.Contains(word))
                {
                    W = word;
                    number += getNum(W);
                }
                else if (hundred.Contains(word))
                {
                    hundred[index] = word;
                    index++;
                }
            }
            num = getInt(hundred[0]);
            if(number.Length < num.ToString().Length)
            {
                before = Convert.ToInt64(number);
                final = (before * num);
            }
            else
            {
                final = Convert.ToInt64(number);
            }
            return final;
        }
    }
}
