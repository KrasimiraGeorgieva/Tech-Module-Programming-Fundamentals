using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers_01
{
    class Program
    {
        static void Main()
        {
            //Variant 1

            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var output = numbers
                .Where(x => x > numbers.Average())
                .OrderByDescending(x => x)
                .Take(5)
                .ToArray();

            Console.WriteLine(output.Length > 0 ? string.Join(" ", output) : "No");


            /* Variant 2
            List<int> numbers = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToList();

            double avg = numbers.Average();
            int counter = 0;

            foreach (var number in numbers.Where(n => n > avg).OrderByDescending(n => n))
            {
                counter++;
                Console.Write(number + " ");
                if (counter == 5)
                {
                    break;
                }
            }
            Console.WriteLine();

            if (counter == 0)
            {
                Console.WriteLine("No");
            }
            */
        }
    }
}
