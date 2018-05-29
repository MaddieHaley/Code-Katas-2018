using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("You can blow out " + HowManyCandels() + " candels");
            Console.ReadLine();
        }

        static int HowManyCandels()
        {
            Console.WriteLine("How old is the birthday person?");
            var age = Int32.Parse(Console.ReadLine());
            var intCandels = generateRandCandels(age);
            int mx = intCandels.Max();
            return intCandels.Where(x => x == mx).Count();
        }

        static List<int> generateRandCandels(int age)
        {
            List<int> candels = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < age; i++) {
                candels.Add(rnd.Next(1, age));
            }
            Console.WriteLine(string.Join(",", candels));
            return candels;
        }
    }
}
