using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1___Week_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number so that it can be translated into Roman Numerals");
            long number = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine(Translate(number));
            Console.ReadLine();
        }
        internal static Dictionary<string, string> numToRoman = new Dictionary<string, string>()
        {
            {"1", "I" },
            {"2", "II" },
            {"3", "III" },
            {"4", "IV" },
            {"5", "V" },
            {"6", "VI" },
            {"7", "VII" },
            {"8", "VIII" },
            {"9", "IX" },
            {"10", "X" },




        };
        public static string getKey(string value)
        {
            string key = numToRoman[value];
            return key;
        }
        public static string Translate(long resp)
        {
            string translated = "";
            int length = 0;
            if(resp >= 1000)
            {
                translated += getPart(resp, 1000, "M");
                resp = resp % 1000;
            }
            if(resp >= 500)
            {
                translated += getPart(resp, 500, "D");
                resp = resp % 500;
            }
            if(resp >= 100)
            {
                translated += getPart(resp, 100, "C");
                resp = resp % 100;
            }
            if(resp >= 90)
            {
                translated += "XC";
                string num = resp.ToString();
                if (num[1] != '0') { translated += getKey(num[1].ToString()); }
            }
            else if(resp >= 50)
            {
                translated += getPart(resp, 50, "L");
                resp = resp % 50;
                if (resp >= 10)
                {
                    translated += getPart(resp, 10, "X");
                    resp = resp % 10;
                }
                if (resp > 0) { translated += getKey(resp.ToString()); }
            }
            else if (resp >= 40 && resp < 50)
            {
                translated += "XL";
                string num = resp.ToString();
                if (num[1] != '0') { translated += getKey(num[1].ToString()); }
            }
            return translated;
        }
        public static string getPart(long resp, int value, string toAdd)
        {
            string translate = "";
            int length = Convert.ToInt32(resp / value);
            for (int i = 0; i < length; i++)
            {
                translate += toAdd;
            }
            return translate;
        }
    }
}
