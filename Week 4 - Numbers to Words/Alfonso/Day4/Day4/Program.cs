
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        public static string nums = "123456789";
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number so that it can be translated into words or the other way around");
            Console.WriteLine(converter(Console.ReadLine().ToLower()));
            Console.ReadLine();
        }
        public static string converter(string resp)
        {
            if (nums.Contains(resp[0]))
            {
                return Translate(resp);
            }
            else
            {
                return toNumber(resp);
            }
        }
        public static Dictionary<string, string> numToWord = new Dictionary<string, string>()
        {
            {"0", "" },
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
        public static Dictionary<string, string> wordToNum = new Dictionary<string, string>()
        {
            {"zero", "" },
            {"one", "1" },
            {"two", "2" },
            {"three", "3" },
            {"four", "4" },
            {"five", "4" },
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
        public static Dictionary<string, string> tens = new Dictionary<string, string>()
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
        public static Dictionary<string, string> prefixes = new Dictionary<string, string>()
        {
            {"1000", "thousand " },
            {"1000000", "million " },
            {"1000000000", "billion " },
            {"1000000000000", "trillion" }
        };
        public static Dictionary<string, string> length = new Dictionary<string, string>()
        {
            {"thousand", "1000" },
            {"million", "1000000" },
            {"billion", "1000000000" },
            {"trillion", "10000000000000" },
        };
        public static string Translate(string resp)
        {
            string word = "";
            if((resp.Length % 3) == 0)
            {
                word += getWord(resp);
            }
            else
            {
                if((resp.Length % 3) == 1)
                {
                    word += getKey(resp[0].ToString()) + " ";
                    word += getPrefix(resp.Length);
                    word += getWord(resp.Substring(1));
                }
                else
                {
                    int two = int.Parse(resp[0].ToString());
                    if (two == 1)
                    {
                        word += getTen(resp[0].ToString() + resp[1].ToString()) + " ";
                        word += getPrefix(resp.Length);
                        word += getWord(resp.Substring(2));                       
                    }

                    else
                    {
                        word += getTen(resp[0].ToString()) + "-";
                        word += getKey(resp[1].ToString()) + " ";
                        word += getPrefix(resp.Length);
                        word += getWord(resp.Substring(2));
                    }
                }
            }
            word = word.Substring(0, word.Length - 1);
            return word;
        }
        public static string getKey(string value)
        {
            string key = numToWord[value];
            return key;

        }
        public static string getTen(string value)
        {
            string Key = tens[value];
            return Key;
        }
        public static string getNum(string value)
        {
            string ye = wordToNum[value];
            return ye;
        }
        public static string getLen(string value)
        {
            string Ye = length[value];
            return Ye;
        }
        public static string getPrefix(int length)
        {
            string prefix = "";
            if(length >= 4 && length < 7) {
                prefix = "thousand ";
            }
            else if(length >= 7 && length < 10)
            {
                prefix = "million ";
            }
            else if( length >= 10 && length < 13)
            {
                prefix = "billion ";
            }
            else if(length >= 13)
            {
                prefix = "trillion ";
            }
            else
            {
                prefix = "";
            }
            return prefix;
        }
        public static string getWord(string resp)
        {
            string num = "";
            int ind1 = 0;
            int ind2 = 1;
            int ind3 = 2;
            string word = "";
            while (ind1 < resp.Length)
            {
                num = resp.Substring(ind1);
                int one = int.Parse(resp[ind1].ToString());
                int two = int.Parse(resp[ind2].ToString());
                if (one > 0)
                {
                    word += getKey(resp[ind1].ToString()) + " ";
                    word += "hundred ";
                }
                if (two == 1)
                {
                    word += getTen(resp[ind2].ToString() + resp[ind3].ToString()) + " ";
                }
                else if (two > 0)
                {
                    word += getTen(resp[ind2].ToString()) + "-";
                    word += getKey(resp[ind3].ToString()) + " ";
                }
                else
                {
                    word += getKey(resp[ind3].ToString()) + " ";
                }
                word += getPrefix(num.Length);
                ind1 += 3;
                ind2 += 3;
                ind3 += 3;
            }
            return word;
        }
        public static string toNumber(string resp)
        {
            string[] numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety", "hundred" };
            string[] words = resp.Split(' ');
            string[] hundredVal = { "thousand", "million", "billion", "trillion" };
            string number = "";
            int index = 0;
            string[] hundred = new string[30];
            foreach (var word in words)
            {
                if (word.Contains('-'))
                {
                    string j = word;
                    string[] wordSplit = j.Split('-');
                    number += getNum(wordSplit[0]);
                    number += getNum(wordSplit[1]);
                }
                else if (numbers.Contains(word))
                {
                        if(word == "hundred" &&  words.Length == 1)
                       {
                        number += "00";
                         }
                    else
                    {
                        if(word == "hundred"){
                            ;
                        }
                        else
                        {
                            number += getNum(word);
                        }
                    }

                }
                else
                {
                    if (hundredVal.Contains(word))
                    {
                        hundred[index] = word;
                        index++;
                    }
                }
            }
            if(number.Length < getLen(hundred[0]).Length){
                if((number.Length % 3) == 0)
                {
                    int length = number.Length;
                    while (length <= (getLen(hundred[0]).Length + 1)) 
                    {
                        number += 0.ToString();
                        length++;
                    }
                }
                else if((number.Length % 3) == 1)
                {
                    int length = number.Length;
                    while (length <= (getLen(hundred[0]).Length - 1))
                    {
                        number += 0.ToString();
                        length++;
                    }
                }
                else
                {
                    int length = number.Length;
                    while (length <= getLen(hundred[0]).Length)
                    {
                        number += 0.ToString();
                        length++;
                    }
                }
            }
            return number;
        }
    }
}
