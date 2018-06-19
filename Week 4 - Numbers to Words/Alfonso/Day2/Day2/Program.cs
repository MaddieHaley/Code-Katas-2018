using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number so that it can be translated into words or some words to be translated to a number!");
            Console.WriteLine(Translator(Console.ReadLine()));
            Console.ReadLine();
        }
        public static string Translator(string resp)
        {
            char[] nums = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string translated = "";
            string number ="";
            string newWord = "";
            if (nums.Contains(resp[0]))
            {
                string[] num = resp.Split('.');
                string translate = num[0];
                
                for (int i = 0; i < translate.Length; i++)
                {
                    if (translate.Substring(i)[0] == '0')
                    {
                        ;
                    }
                    else if (translate.Substring(i).Length == 2 || translate.Substring(i).Length == 5 || translate.Substring(i).Length == 8 || translate.Substring(i).Length == 11)
                    {
                        translated += numsToWords(translate.Substring(i));
                        translated += inHundred(translate.Substring(i));
                        i++;
                    }
                    
                    else
                    {
                        if (translate.Substring(i).Length == 2 || translate.Substring(i).Length == 1)
                        {
                            translated += numsToWords(translate.Substring(i));
                            translated += inHundred(translate.Substring(i));
                        }
                        else
                        {
                            translated += numsToWords(translate.Substring(i));
                            translated += inHundred(translate.Substring(i));
                        }
                    }
                    
                }
                translated += "dollars";
                return translated;
            }
            else
            {
                string[] hundreds = { "hundred", "thousand", "ten thousand", "hundred thousand", "million", "ten million", "hundred million", "billion", "ten billion", "hundred billion", "trillion" };
                string[] tens = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
                string[] less20 = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "ten" };
                string newOne = resp.ToLower();
                string[] hundred = new string[30] ;
                int index = 0;
                int inTen = 0;
                int len = 0;
                string[] words = newOne.Split(' ');
                foreach (string word in words)
                {
                    if (word.Contains('-') || tens.Contains(word))
                    {

                        
                        if (word.Contains('-'))
                        {
                            string[] ten = word.Split('-');
                            number += toTen(ten[0]).ToString();
                            number += toWord(ten[1]).ToString();

                        }
                        else if (!(less20.Contains(word)))
                        {
                            number += toTen(word).ToString();
                            number += 0.ToString();
                        }

                        else
                        {
                            number += toTen(word);
                            len += 1;
                        }
                        
                        
                    }
                    else
                    {

                        if (!hundreds.Contains(word))
                        {
                            number += toWord(word).ToString();
                        }
                        else
                        {
                            hundred[index] = word;
                            index++;
                        }
                    }
                }
                if(hundred[1] == "million" || hundred[1] == "thousand" || hundred[1] == "billion")
                {
                    string word = hundred[0] + " " + hundred[1];
                    len += length(word);
                }
                else
                {
                    len += length(hundred[0]);
                }

                if (number.Length > 3 || len > 3)
                {
                    if (number.Length < len)
                    {
                        while (number.Length < len)
                        {
                            number += 0.ToString();
                        }

                    }
                }
                number += " dollars";
                return number;
            }
            
        }
        public static string numsToWords(string resp)
        {
            
            int numLength = resp.Length;
            switch (numLength)
            {
                case 1: return numToString(resp[0]);
                case 2: return tens(resp.Substring(0, 2));
                case 3: return numToString(resp[0]);
                case 4: return numToString(resp[0]);
                case 5: return tens(resp.Substring(0,2));
                case 6: return numToString(resp[0]);
                case 7: return numToString(resp[0]);
                case 8: return tens(resp.Substring(0, 2));
                case 9: return numToString(resp[0]);
                case 10: return numToString(resp[0]);
                case 11: return tens(resp.Substring(0, 2));
                case 12: return numToString(resp[0]);
                case 13: return numToString(resp[0]);
                default: return numToString(resp[0]);
            }
        }
        public static string tens(string nums)
        {
            
            if(!(nums[1] == '0'))
            {
                switch (nums[0])
                {
                    case '1': return tenNum(nums) + " ";
                    case '2': return "twenty" + '-' + numToString(nums[1]);
                    case '3': return "thirty" + '-' + numToString(nums[1]);
                    case '4': return "forty" + '-' + numToString(nums[1]);
                    case '5': return "fifty" + '-' + numToString(nums[1]);
                    case '6': return "sixty" + '-' + numToString(nums[1]);
                    case '7': return "seventy" + '-' + numToString(nums[1]);
                    case '8': return "eighty" + '-' + numToString(nums[1]);
                    case '9': return "ninety" + '-' + numToString(nums[1]);
                    default: return "Not a 10";
                }
            }
            else
            {
                switch (nums[0])
                {
                    case '1': return tenNum(nums) + " ";
                    case '2': return "twenty " + numToString(nums[1]);
                    case '3': return "thirty " + numToString(nums[1]);
                    case '4': return "fourty " + numToString(nums[1]);
                    case '5': return "fifty " +  numToString(nums[1]);
                    case '6': return "sixty " + numToString(nums[1]);
                    case '7': return "seventy " + numToString(nums[1]);
                    case '8': return "eighty " + numToString(nums[1]);
                    case '9': return "ninety " + numToString(nums[1]);
                    default: return "Not a 10";
                }
            }
        }
        public static string numToString(char number)
        {
            switch (number)
            {
                case '0': return "";
                case '1': return "one ";
                case '2': return "two ";
                case '3': return "three ";
                case '4': return "four ";
                case '5': return "five ";
                case '6': return "six ";
                case '7': return "seven ";
                case '8': return "eight ";
                case '9': return "nine ";
                default: return "This is not a number!";
            }
        }
        public static string inHundred(string resp)
        {
            string[] nums = resp.Split('.');
            int numLength = resp.Length;
            switch (numLength)
            {
                case 1: return " ";
                case 2: return " ";
                case 3: return "hundred ";
                case 4: return "thousand ";
                case 5: return "thousand ";
                case 6: return "hundred ";
                case 7: return "million ";
                case 8: return "million ";
                case 9: return "hundred ";
                case 10: return "billion ";
                case 11: return "billion ";
                case 12: return "hundred ";
                case 13: return "trillion ";
                default: return "Number entered is out of bounds";
            }
        }
        public static string tenNum(string num)
        {
            switch (num[1])
            {
                case '1': return "eleven";
                case '2': return "twelve";
                case '3': return "thirteen";
                case '4': return "fourteen";
                case '5': return "fifteen";
                case '6': return "sixteen";
                case '7': return "seventeen";
                case '8': return "eighteen";
                case '9': return "nineteen";
                default: return "Not a Ten";
            }
        }
        public static int toWord(string word)
        {
            switch (word)
            {
                case "one": return 1;
                case "two": return 2;
                case "three": return 3;
                case "four": return 4;
                case "five": return 5;
                case "six": return 6;
                case "seven": return 7;
                case "eight": return 8;
                case "nine": return 9;
                default: return 10;
            }
        }
        public static int toTen(string word)
        {
            switch (word)
            {
                case "ten": return 1;
                case "eleven": return 11;
                case "twelve": return 12;
                case "thirteen": return 13;
                case "fourteen": return 14;
                case "fifteen": return 15;
                case "sixteen": return 16;
                case "seventeen": return 17;
                case "eighteen": return 18;
                case "nineteen": return 19;
                case "twenty": return 2;
                case "thirty": return 3;
                case "fourty": return 4;
                case "fifty": return 5;
                case "sixty": return 6;
                case "seventy": return 7;
                case "eighty": return 8;
                case "ninety": return 9;
                default: return 100;
            }
        }
        public static int length(string word)
        {
            switch (word)
            {
                case "hundred": return 3;
                case "thousand": return 4;
                case "ten thousand": return 5;
                case "hundred thousand": return 6;
                case "million": return 7;
                case "ten million": return 8;
                case "hundred million": return 9;
                case "billion": return 10;
                case "ten billion": return 11;
                case "hundred billion": return 12;
                case "trillion": return 13;
                default: return 16;
            }
        }
    }
}
