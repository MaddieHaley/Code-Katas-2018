using System;

namespace HarryPotterDay2
{
    internal class Program
    {
        public static string numbers = "123456789";
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter the books for the Harry Potter Series that you want!");
            Console.WriteLine(GetPrice(Console.ReadLine().ToLower()));
            Console.ReadLine();
        }

        public static double GetPrice(string bookNumbersWanted)
        {
            string[] bookNumbersWantedArray = bookNumbersWanted.Split(' ');
            int[] count = {0, 0, 0, 0, 0};
            double price = 0;
            int total = 0;
            foreach (string letter in bookNumbersWantedArray)
            {
                if (numbers.Contains(letter))
                {
                    switch (int.Parse(letter))
                    {
                        case 1: count[0]++;
                            break;
                        case 2: count[1]++;
                            break;
                        case 3:
                            count[2]++;
                            break;
                        case 4:
                            count[3]++;
                            break;
                        case 5:
                            count[4]++;
                            break;
                    }
                }
            }

            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > 0)
                {
                    total++;
                    count[i] -= 1;
                }
            }

            switch (total)
            {
                case 1:
                    price = 8 * total;
                    break;
                case 2:
                    price = 8 * total;
                    price *= .95;
                    break;
                case 3:
                    price = 8 * total;
                    price *= .90;
                    break;
                case 4:
                    price = 8 * total;
                    price *= .80;
                    break;
                case 5:
                    price = 8 * total;
                    price *= .75;
                    break;
            }

            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > 0)
                {
                    while (count[1] > 0)
                    {
                        price += 8;
                        count[i] -= 1;
                    }
                }
            }

            return price;
        }
    }
}