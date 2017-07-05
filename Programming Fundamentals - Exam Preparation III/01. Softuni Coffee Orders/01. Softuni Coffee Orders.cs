using System;
using System.Linq;

namespace _01.Softuni_Coffee_Orders
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            decimal totalPrice = 0;

            for (int i = 0; i < n; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                int[] date = Console.ReadLine().Split('/').Select(int.Parse).ToArray();
                int daysInMonth = DateTime.DaysInMonth(date[2], date[1]);
                int capsulesCount = int.Parse(Console.ReadLine());
                decimal price = (decimal)daysInMonth * capsulesCount * pricePerCapsule;

                Console.WriteLine($"The price for the coffee is: ${price:f2}");
                totalPrice += price;
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
