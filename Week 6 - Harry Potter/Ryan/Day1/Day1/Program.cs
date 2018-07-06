using System;
using System.Collections.Generic;
using System.Linq;

namespace Day1
{
    internal static class Program
    {
        private const double DefaultPrice = 8.00;

        private static readonly Dictionary<int, double> DistinctBooksToDiscounts = new Dictionary<int, double>
        {
            {1, 0.0},
            {2, .05},
            {3, .10},
            {4, .20},
            {5, .25}
        };

        private static double GetPrice(List<int> books)
        {
            double price = 0;

            var distinctBooks = books.GroupBy(x => x).ToList();
            for (var i = 0; i < distinctBooks.Max(x => x.Count()); i++)
            {
                var numberOfDistinctBooks = distinctBooks.Count(g => g.Count() > i);
                var undiscountedPrice = numberOfDistinctBooks * DefaultPrice;
                price += undiscountedPrice * (1 - DistinctBooksToDiscounts[numberOfDistinctBooks]);
            }

            return price;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Enter a sequence of books each separated by spaces:");
            var line = Console.ReadLine();
            if (line != null)
            {
                var books = line.Split(' ').ToList().ConvertAll(int.Parse);
                Console.WriteLine(GetPrice(books));
            }

            Console.ReadKey();
        }
    }
}