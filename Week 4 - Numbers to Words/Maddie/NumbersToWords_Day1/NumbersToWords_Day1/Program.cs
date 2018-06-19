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

        public static string wordsToNums(string words)
        {
            var filteredWords = filterUnnecessary(words);
            var groupedWords = filteredWords.Split(',');
            var ret = "";
            foreach(var word in groupedWords)
            {
                ret+=translateWord(word.Trim());
            }
            return ret;
        }

        static string translateWord(string word)
        {
            var ret = "";
            var pieces = word.Split(' ');
            if (word == "zero") return "0";
            if (pieces[pieces.Length - 1] == "hundred") return translateWord(pieces[0]) + "00";
            else{
                foreach (var piece in pieces)
                {
                    if (piece == "hundred") continue;
                    switch (piece)
                    {
                        case "twenty":
                            if (Array.IndexOf(pieces, piece) == pieces.Length - 1) ret += "20";
                            else ret += "2";
                            continue;
                        case "thirty":
                            if (Array.IndexOf(pieces, piece) == pieces.Length - 1) ret += "30";
                            else ret += "3";
                            continue;
                        case "forty":
                            if (Array.IndexOf(pieces, piece) == pieces.Length - 1) ret += "40";
                            else ret += "4";
                            continue;
                        case "fifty":
                            if (Array.IndexOf(pieces, piece) == pieces.Length - 1) ret += "50";
                            else ret += "5";
                            continue;
                        case "sixty":
                            if (Array.IndexOf(pieces, piece) == pieces.Length - 1) ret += "60";
                            else ret += "6";
                            continue;
                        case "seventy":
                            if (Array.IndexOf(pieces, piece) == pieces.Length - 1) ret += "70";
                            else ret += "7";
                            continue;
                        case "eighty":
                            if (Array.IndexOf(pieces, piece) == pieces.Length - 1) ret += "80";
                            else ret += "8";
                            continue;
                        case "ninty":
                            if (Array.IndexOf(pieces, piece) == pieces.Length - 1) ret += "90";
                            else ret += "9";
                            continue;
                        case "eleven":
                            ret += "11";
                            continue;
                        case "twelve":
                            ret += "12";
                            continue;
                        case "thirteen":
                            ret += "13";
                            continue;
                        case "fourteen":
                            ret += "14";
                            continue;
                        case "fifteen":
                            ret += "15";
                            continue;
                        case "sixteen":
                            ret += "11";
                            continue;
                        case "seventeen":
                            ret += "17";
                            continue;
                        case "eighteen":
                            ret += "18";
                            continue;
                        case "nineteen":
                            ret += "19";
                            continue;
                        case "one":
                            ret += "1";
                            continue;
                        case "two":
                            ret += "2";
                            continue;
                        case "three":
                            ret += "3";
                            continue;
                        case "four":
                            ret += "4";
                            continue;
                        case "five":
                            ret += "5";
                            continue;
                        case "six":
                            ret += "6";
                            continue;
                        case "seven":
                            ret += "7";
                            continue;
                        case "eight":
                            ret += "8";
                            continue;
                        case "nine":
                            ret += "9";
                            continue;
                        case "ten":
                            ret += "10";
                            continue;
                        default: return "ERROR 2 IN TRANSLATE WORD";
                    }
                }
                
                return ret;
            }
        }

        static string filterUnnecessary(string words)
        {
            words = words.Replace("-", " ");
            words = words.Replace("thousand", "");
            words = words.Replace("million", "");
            words = words.Replace("billion", "");
            words = words.Replace("trillion", "");
            words = words.Replace("quadrillion", "");
            words = words.Replace("quintillion", "");
            words = words.Replace("septillion", "");
            words = words.Replace("sextillion", "");
            words = words.Replace("octillion", "");
            words = words.Replace("nonillion", "");
            words = words.Replace("decillion", "");
            return words;
        }
        
    }
}
