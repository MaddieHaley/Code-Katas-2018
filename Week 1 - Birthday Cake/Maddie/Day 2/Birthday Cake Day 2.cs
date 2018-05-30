using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCakeDay2
{
    class Program
    {
        static void Main(string[] args)
        {
            BirthdayCake();
            Console.ReadLine();
        }

        static void BirthdayCake()
        {
            Console.Write("How old is the birthday person? ");
            int age = Int32.Parse(Console.ReadLine());
            var candels = generateRandCandels(age);
            var num =  candels.Where(x => x == (candels.Max())).Count();
            Console.WriteLine("They can blow out " + num + " candels.");
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
