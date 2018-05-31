using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCakeDay3
{
    class Program
    {
        static void Main(string[] args)
        {
            BirthdayCake();
            Console.ReadLine();
        }
        static void BirthdayCake() {
            Console.Write("How old? ");
            var  candels = generateRandCandels(Int32.Parse(Console.ReadLine()));
            int count = 0;
            int max = 0;
            foreach (int candel in candels) {
                if (candel > max)
                {
                    max = candel;
                    count = 1;
                }
                else if (candel == max) count++;
            }
            Console.WriteLine("You can extinguish " + count + " candels.");
        }
        static List<int> generateRandCandels(int age)
        {
            List<int> candels = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < age; i++)
            {
                candels.Add(rnd.Next(1, age));
            }
            Console.WriteLine(string.Join(",", candels));
            return candels;
        }
    }
}
