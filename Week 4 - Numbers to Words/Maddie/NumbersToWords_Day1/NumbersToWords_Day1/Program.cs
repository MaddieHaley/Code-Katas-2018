using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWords_Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Nums: ");
            Console.WriteLine(numsToWords(Console.ReadLine()));
            Console.ReadLine();
        }

        public static string numsToWords(string num)
        {
            if (num.Equals("0")) return "zero";
            var groups = reverseList(makeNumGroups(num));
            var suffixCode = groups.Count();
            var fin = "";
            foreach(string group in groups)
            {
                var words = translateNumGroup(group).Trim();
                fin += words + " " + getWordSuffix(suffixCode);
                suffixCode--;
                if (groups.IndexOf(group) != groups.Count - 1) fin += ", ";
            }
            return fin.Trim();
        }

        public static List<string> makeNumGroups(string nums)
        {
            var rev = reverseString(nums);
            List<string> groups = new List<string>();
            var group = "";
            foreach(char num in rev)
            {
                if(group.Length == 3)
                {
                    groups.Add(reverseString(group));
                    group = "";
                }
                group += num;
            }
            if (group.Length > 0) groups.Add(reverseString(group));
            return groups;
        }

        static string reverseString(string fwd)
        {
            string rev = "";
            foreach(char num in fwd)
            {
                rev = num + rev;
            }
            return rev;
        }

        static List<string> reverseList(List<string> fwd)
        {
            List<string> rev = new List<string>();
            foreach(var num in fwd)
            {
                rev.Insert(0, num);
            }
            return rev;
        }

        static string getWordSuffix(int index)
        {
            switch (index)
            {
                case 0: return "";
                case 1: return "";
                case 2: return "thousand";
                case 3: return "million";
                case 4: return "billion";
                case 5: return "trillion";
                case 6: return "quadrillion";
                case 7: return "quintillion";
                case 8: return "sextillion";
                case 9: return "septillion";
                case 10: return "octillion";
                case 11: return "nonillion";
                case 12: return "decillion";
                default: return "OUT OF BOUNDS";
            }
        }
        static string translateNumGroup(string num)
        {
            switch (num.Length)
            {
                case 3:
                    var hundreds = translateOnes(num[0]);
                    var rest = translateGroup(num.Substring(1, num.Length-1));
                    switch (hundreds)
                    {
                        case " ": return rest;
                        default:
                            switch (rest)
                            {
                                case " ": return hundreds + " hundred";
                                default: return hundreds + " hundred " + rest;
                            }
                    }
                case 2: return translateGroup(num.Substring(0, num.Length));
                case 1: return translateOnes(num[0]);
                default: return "ERROR IN TRANSLATE NUM GROUP";
            }
        }

        static string translateGroup(string num)
        {
            var ones = translateOnes(num[1]);
            switch (num[0])
            {
                case '0': return ones; //will return " " if ones is also 0
                case '1':
                    switch (num)
                    {
                        case "10": return "ten";
                        case "11": return "eleven";
                        case "12": return "twelve";
                        case "13": return "thirteen";
                        case "14": return "fourteen";
                        case "15": return "fifteen";
                        case "16": return "sixteen";
                        case "17": return "seventeen";
                        case "18": return "eighteen";
                        case "19": return "nineteen";
                        default: return "ERROR IN 1 CASE OF TRANSLATE GROUP";
                    }
                case '2':
                    switch (ones)
                    {
                        case " ": return "twenty";
                        default: return "twenty-" + ones;
                    }
                case '3':
                    switch (ones)
                    {
                        case " ": return "thirty";
                        default: return "thirty-" + ones;
                    }
                case '4':
                    switch (ones)
                    {
                        case " ": return "forty";
                        default: return "forty-" + ones;
                    }
                case '5':
                    switch (ones)
                    {
                        case " ": return "fifty";
                        default: return "fifty-" + ones;
                    }
                case '6':
                    switch (ones)
                    {
                        case " ": return "sixty";
                        default: return "sixty-" + ones;
                    }
                case '7':
                    switch (ones)
                    {
                        case " ": return "seventy";
                        default: return "seventy-" + ones;
                    }
                case '8':
                    switch (ones)
                    {
                        case " ": return "eighty";
                        default: return "eighty-" + ones;
                    }
                case '9':
                    switch (ones)
                    {
                        case " ": return "ninety";
                        default: return "ninety-" + ones;
                    }
                default: return "ERROR IN TRANSLATE GROUP";
            }
        }

        static string translateOnes(char num)
        {
            switch (num)
            {
                case '0': return " ";
                case '1': return "one";
                case '2': return "two";
                case '3': return "three";
                case '4': return "four";
                case '5': return "five";
                case '6': return "six";
                case '7': return "seven";
                case '8': return "eight";
                case '9': return "nine";
                default : return "ERROR IN TRANSLATE ONES";
            }
        }
        
    }
}
