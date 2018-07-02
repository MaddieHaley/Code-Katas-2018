using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotterDay1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Harry Potter books you want by entering 'book' followed by the number in the series you want (1-5)");
            Console.WriteLine(getPrice(Console.ReadLine()));
            Console.ReadLine();
        }
        public static double getPrice(string resp)
        {
            string[] words = resp.Split(' ');
            var bookNums = new List<int>();
            int index = 0;
            int theRest = 0;
            double price = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if(words[i] == "1" || words[i] == "2" || words[i] == "3" || words[i] == "4" || words[i] == "5")
                {
                    bookNums.Add(int.Parse(words[i]));
                }
                
            }
            int[] theNumberOfDifferentBooks = getHowManyDifferentBooks(bookNums);
            price += getTheDiscount(theNumberOfDifferentBooks[0]);
            theRest = theNumberOfDifferentBooks[1] * 8;
            price += theRest;
            return price;
            
        }

        public static int[] getHowManyDifferentBooks(List<int> allTheBooksOrdered)
        {
            int[] notRepeatedBooks = new int[5];
            int index = 0;
            int count = 0;
            int repeat = 0;
            for (int i = 0; i < allTheBooksOrdered.Count; i++)
            {
                if(!(notRepeatedBooks.Contains(allTheBooksOrdered[i])))
                {
                    notRepeatedBooks[index] = allTheBooksOrdered[i];
                    count++;
                    index++;
                }
                else { repeat++;  }
            }
            int[] total = { count, repeat };
            return total;
        }
        public static double getTheDiscount(int numberOfBooksDifferent)
        {
            double totalPrice = 0;
            if (numberOfBooksDifferent == 1) { totalPrice += 8; }
            else if (numberOfBooksDifferent == 2) { totalPrice += 16; totalPrice *= .95; }
            else if (numberOfBooksDifferent == 3) { totalPrice += 24; totalPrice *= .90; }
            else if (numberOfBooksDifferent == 4) { totalPrice += 32; totalPrice *= .80; }
            else if (numberOfBooksDifferent == 5) { totalPrice += 40; totalPrice *= .75; }
            return totalPrice;
        }
    }
}
