using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals_Day1
{
    class Program
    {
        private static Dictionary<char, int> getNum = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
        private static Dictionary<int, string> getRoman = new Dictionary<int, string>()
        {
            {1000, "M"},
            {900, "CM"},
            {500, "D"},
            {400, "CD"},
            {100, "C"},
            {90, "XC"},
            {50, "L"},
            {40, "XL"},
            {10, "X"},
            {9, "IX"},
            {5, "V"},
            {4, "IV"},
            {1, "I"}
        };
        static void Main(string[] args)
        {
            Console.WriteLine(Int32.Parse(Console.ReadLine()));
        }

        public static string NumsToRomanNums(int nums)
        {
            if (nums > 3000) throw new Exception("out of bounds");
            string roman = "";
            while(nums > 0)
            {
                foreach(var set in getRoman)
                {
                    if(nums - set.Key >= 0)
                    {
                        roman += set.Value;
                        nums = nums - set.Key;
                        break;
                    }
                }
            }
            return roman;
        }

        public static int RomanNumsToNums(string roman)
        {
            List<int> nums = new List<int>();
            foreach(char letter in roman.ToUpper())
            {
                int num;
                getNum.TryGetValue(letter, out num);
                nums.Add(num);
            }
            for(int i = 1; i < nums.Count; i++)
            {
                if(nums[i-1] < nums[i])
                {
                    int calc = nums[i] - nums[i - 1];
                    nums.RemoveAt(i);
                    nums.RemoveAt(i-1);
                    nums.Insert(i - 1, calc);
                }
            }
            int sum = 0;
            foreach(int num in nums)
            {
                sum += num;
            }
            return sum;
        }
        

    }
}
