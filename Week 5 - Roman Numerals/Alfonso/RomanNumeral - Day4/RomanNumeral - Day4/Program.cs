using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeral___Day4
{
    class Program
    {
        public static string nums = "123456789";
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number so that it can be translated into a roman numeral and the other way around");
            Console.WriteLine(converter(Console.ReadLine().ToUpper()));
            Console.ReadLine();
        }
        public static string converter(string resp)
        {
            string converted = "";
            if (nums.Contains(resp[0])) { converted += numToRoman(resp); } else { converted += romanToNum(resp).ToString(); }
            return converted;
        }
        public static string numToRoman(string number)
        {
            int value = int.Parse(number);
            string numeral = "";
            int index = 0;
            if(value >= 1000)
            {
                index = 0;
                int num = value / 1000;
                while((index < num)) { numeral += "M"; value = value % 1000; index += 1; }
            }
            if (value >= 500)
            {
                if(value >= 900) { numeral += "CM"; value = value % 900; }
                else
                {
                    index = 0;
                    int num = value / 500;
                    while ((index < num)) { numeral += "D"; value = value % 500; index += 1; }
                }
            }
            if (value >= 100)
            {
                if(value >= 400) { numeral += "CD"; value = value % 400; }
                else
                {
                    index = 0;
                    int num = value / 100;
                    while ((index < num)) { numeral += "C"; value = value % 100; index += 1; }
                }
            }
            if (value >= 50)
            {
                if(value >= 90) { numeral += "XC"; value = value % 90; }
                else
                {
                    index = 0;
                    int num = value / 50;
                    while ((index < num)) { numeral += "L"; value = value % 50; index += 1; }
                }
            }
            if (value >= 10)
            {
               if(value >= 40)
                {
                    numeral += "XL";
                    value = value % 40;
                }
               else
                {
                    index = 0;
                    int num = value / 10;
                    while ((index < num)) { numeral += "X"; value = value % 10; index += 1; }
                }
            }
            if (value >= 5)
            {
                if(value >= 9) { numeral += "IX"; value = value % 9; }
                else
                {
                    index = 0;
                    int num = value / 5;
                    while ((index < num)) { numeral += "V"; value = value % 5; index += 1; }
                }
            }
            if (value >= 1)
            {
                index = 0;
                int num = value / 1;
                while ((index < num)) { numeral += "I"; value = value % 1; index += 1; }
            }
            return numeral;
        }
        public static int romanToNum(string numeral)
        {
            char[] romanArray = numeral.ToCharArray();
            int number = 0;
            for (int i = 0; i < romanArray.Length; i++)
            {
                if((romanArray[i] == 'C' || romanArray[i] == 'X' || romanArray[i] == 'I') && romanArray.Length > i + 1)
                {

                    if (romanArray[i] == 'C' && (romanArray[i + 1] == 'D' || romanArray[i + 1] == 'M')) { number += getType((romanArray[i] + romanArray[i + 1]).ToString()); number -= 200; }
                    else if (romanArray[i] == 'X' && (romanArray[i + 1] == 'L' || romanArray[i + 1] == 'C')) { number += getType((romanArray[i] + romanArray[i + 1]).ToString()); number -= 20; }
                    else if (romanArray[i] == 'I' && (romanArray[i + 1] == 'X')) { number += getType((romanArray[i] + romanArray[i + 1]).ToString()); number -= 2; }
                }
                number += getType(romanArray[i].ToString());

            }
            return number;
        }
        public static int getType(string value)
        {
            int number = 0;
            if (value == "M") { number = 1000; } else if (value == "CM") { number = 900; }
            else if (value == "D") { number = 500; } else if (value == "CD") { number = 400; }
            else if (value == "C") { number = 100; } else if (value == "XC") { number = 90; }
            else if (value == "XL") { number = 40; } else if (value == "L"){ number = 50; }  else if (value == "X") { number = 10; }
            else if (value == "IX") { number = 9; } else if (value == "V") { number = 5; }
            else if (value == "I") { number = 1; }
            return number;
        }
    }
}
