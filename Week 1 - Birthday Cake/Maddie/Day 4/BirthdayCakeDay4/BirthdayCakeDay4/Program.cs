using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCakeDay4
{
    class Program
    {
        static void Main(string[] args)
        {
            BirthdayCake();
        }

        static void BirthdayCake()
        {
            Console.Write("\n");
            Console.Write("How ");
            Console.Write("old ");
            Console.Write("is ");
            Console.Write("the ");
            Console.Write("birthday ");
            Console.Write("girl");
            Console.Write("/");
            Console.Write("boy");
            Console.Write("?");
            Console.Write(" ");
            var resp = Console.ReadLine();
            Console.Write("\n");
            int age = -1;
            Int32.TryParse(resp, out age);
            if (age != -1 &&
                age != 0)
            {
                var candels = generateRandCandels(age);
                int max = -1;
                foreach (int candel in candels)
                {
                    if (candel > max)
                    {
                        max = candel;
                    }
                    else
                    {
                        continue;
                    }
                }
                int numCandels = 0;
                foreach(int candel in candels)
                {
                    if(candel == max)
                    {
                        numCandels++;
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.Write("The ");
                Console.Write("birthday ");
                Console.Write("girl");
                Console.Write("/");
                Console.Write("boy ");
                Console.Write("can ");
                Console.Write("extinguish ");
                Console.Write(numCandels);
                Console.Write(" ");
                Console.Write("of ");
                Console.Write("height ");
                Console.Write(max);
                Console.Write(".");
                Console.Write("\n");
            }
            else
            {
                Console.Write(resp);
                Console.Write(" ");
                Console.Write("is ");
                Console.Write("not ");
                Console.Write("an ");
                Console.Write("acceptable ");
                Console.Write("age. ");
                Console.Write("Please ");
                Console.Write("try ");
                Console.Write("again");
                Console.Write(".");
                Console.Write("\n");
                BirthdayCake();
            }
            Console.Write("Would ");
            Console.Write("you ");
            Console.Write("like ");
            Console.Write("to ");
            Console.Write("try ");
            Console.Write("again");
            Console.Write("?");
            var again = Console.ReadLine();
            if(again.Contains("Y") ||
               again.Contains("y"))
            {
                BirthdayCake();
            }
            else
            {
                if(again.Contains("N") ||
                   again.Contains("n"))
                {
                    Console.Write("Goodbye");
                    Console.Write(".");
                }
                else
                {
                    Console.Write("I ");
                    Console.Write("don't ");
                    Console.Write("recognize ");
                    Console.Write("that ");
                    Console.Write("response ");
                    Console.Write(".");
                    Console.Write("Please ");
                    Console.Write("try ");
                    Console.Write("again");
                    Console.Write(".");
                    Console.Write("\n");
                    Console.Write("Would ");
                    Console.Write("you ");
                    Console.Write("like ");
                    Console.Write("to ");
                    Console.Write("try ");
                    Console.Write("again");
                    Console.Write("?");
                    again = Console.ReadLine();
                    if (again.Contains("Y") ||
                       again.Contains("y"))
                    {
                        BirthdayCake();
                    }
                    else
                    {
                        if (again.Contains("N") ||
                           again.Contains("n"))
                        {
                            Console.Write("Goodbye");
                            Console.Write(".");
                        }
                        else
                        {
                            Console.Write("I ");
                            Console.Write("don't ");
                            Console.Write("recognize ");
                            Console.Write("that ");
                            Console.Write("response ");
                            Console.Write(".");
                            Console.Write("Please ");
                            Console.Write("try ");
                            Console.Write("again");
                            Console.Write(".");
                            Console.Write("\n");
                            Console.Write("Would ");
                            Console.Write("you ");
                            Console.Write("like ");
                            Console.Write("to ");
                            Console.Write("try ");
                            Console.Write("again");
                            Console.Write("?");
                            again = Console.ReadLine();
                            if (again.Contains("Y") ||
                               again.Contains("y"))
                            {
                                BirthdayCake();
                            }
                            else
                            {
                                if (again.Contains("N") ||
                                   again.Contains("n"))
                                {
                                    Console.Write("Goodbye");
                                    Console.Write(".");
                                }
                                else
                                {
                                    Console.Write("I ");
                                    Console.Write("don't ");
                                    Console.Write("recognize ");
                                    Console.Write("that ");
                                    Console.Write("response ");
                                    Console.Write(".");
                                    Console.Write("Please ");
                                    Console.Write("try ");
                                    Console.Write("again");
                                    Console.Write(".");
                                    Console.Write("\n");
                                    Console.Write("Would ");
                                    Console.Write("you ");
                                    Console.Write("like ");
                                    Console.Write("to ");
                                    Console.Write("try ");
                                    Console.Write("again");
                                    Console.Write("?");
                                    again = Console.ReadLine();
                                    if (again.Contains("Y") ||
                                       again.Contains("y"))
                                    {
                                        BirthdayCake();
                                    }
                                    else
                                    {
                                        if (again.Contains("N") ||
                                           again.Contains("n"))
                                        {
                                            Console.Write("Goodbye");
                                            Console.Write(".");
                                        }
                                        else
                                        {
                                            Console.Write("I ");
                                            Console.Write("don't ");
                                            Console.Write("recognize ");
                                            Console.Write("that ");
                                            Console.Write("response ");
                                            Console.Write(".");
                                            Console.Write("Please ");
                                            Console.Write("try ");
                                            Console.Write("again");
                                            Console.Write(".");
                                            Console.Write("\n");
                                            Console.Write("Would ");
                                            Console.Write("you ");
                                            Console.Write("like ");
                                            Console.Write("to ");
                                            Console.Write("try ");
                                            Console.Write("again");
                                            Console.Write("?");
                                            again = Console.ReadLine();
                                            if (again.Contains("Y") ||
                                               again.Contains("y"))
                                            {
                                                BirthdayCake();
                                            }
                                            else
                                            {
                                                if (again.Contains("N") ||
                                                   again.Contains("n"))
                                                {
                                                    Console.Write("Goodbye");
                                                    Console.Write(".");
                                                }
                                                else
                                                {
                                                    Console.Write("I ");
                                                    Console.Write("don't ");
                                                    Console.Write("recognize ");
                                                    Console.Write("that ");
                                                    Console.Write("response ");
                                                    Console.Write(".");
                                                    Console.Write("Please ");
                                                    Console.Write("try ");
                                                    Console.Write("again");
                                                    Console.Write(".");
                                                    Console.Write("\n");
                                                    Console.Write("Would ");
                                                    Console.Write("you ");
                                                    Console.Write("like ");
                                                    Console.Write("to ");
                                                    Console.Write("try ");
                                                    Console.Write("again");
                                                    Console.Write("?");
                                                    again = Console.ReadLine();
                                                    if (again.Contains("Y") ||
                                                       again.Contains("y"))
                                                    {
                                                        BirthdayCake();
                                                    }
                                                    else
                                                    {
                                                        if (again.Contains("N") ||
                                                           again.Contains("n"))
                                                        {
                                                            Console.Write("Goodbye");
                                                            Console.Write(".");
                                                        }
                                                        else
                                                        {
                                                            Console.Write("You ");
                                                            Console.Write("are ");
                                                            Console.Write("very ");
                                                            Console.Write("bad ");
                                                            Console.Write("at ");
                                                            Console.Write("this ");
                                                            Console.Write(".");
                                                            Console.Write("Please ");
                                                            Console.Write("leave ");
                                                            Console.Write("me ");
                                                            Console.Write("alone");
                                                            Console.Write(".");
                                                            Console.Write("\n");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
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
