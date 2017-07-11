using System;
using System.Linq;

namespace _02.Array_Manipulator
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var line = Console.ReadLine();

            while(line != "end")
            {
                var tokens = line.Split();
                var command = tokens[0];

                switch (command)
                {
                    case "exchange":
                        var index = int.Parse(tokens[1]);

                        arr = ExchangeArreyElements(arr, index);
                        break;
                    case "max":
                    case "min":
                        var maxOrMin = command;
                        var evenOrOdd = tokens[1];

                        FindMaxOrMinEvenOrOddElement(arr, maxOrMin, evenOrOdd);
                        break;
                    case "first":
                    case "last":
                        var firstOrLast = command;
                        var count = int.Parse(tokens[1]);
                        evenOrOdd = tokens[2];

                        FindFirstOrLastEvenOrOddElements(arr, firstOrLast, count, evenOrOdd);
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", arr));
        }

        private static void FindFirstOrLastEvenOrOddElements(int[] arr, string firstOrLast, int count, string evenOrOdd)
        {
            if (count > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            var evenOrOdParity = evenOrOdd == "even" ? 0 : 1;
            var evenOrOddElements = arr.Where(a => a % 2 == evenOrOdParity);

            int[] foundElements;
            if (firstOrLast == "first")
            {
                foundElements = evenOrOddElements
                    .Take(count)
                    .ToArray();
            }
            else
            {
                foundElements = evenOrOddElements
                    .Reverse()
                    .Take(count)
                    .Reverse()
                    .ToArray();
            }
            Console.WriteLine("[{0}]", string.Join(", ", foundElements));
        }

        private static void FindMaxOrMinEvenOrOddElement(int[] arr, string maxOrMin, string evenOrOdd)
        {
            var evenOrOddElementsParity = evenOrOdd == "even" ? 0 : 1;
            var evenOrOddElements = arr.Where(a => a % 2 == evenOrOddElementsParity).ToArray();

            if (!evenOrOddElements.Any())
            {
                Console.WriteLine("No matches");
                return;
            }

            var maxOrMinElement = 0;
           if(maxOrMin == "max")
            {
                maxOrMinElement = evenOrOddElements.Max();
            }
           else
            {
                maxOrMinElement = evenOrOddElements.Min();
            }

            var maxOrMinElementIndex = Array.LastIndexOf(arr, maxOrMinElement);
            Console.WriteLine(maxOrMinElementIndex);
        }

        private static int[] ExchangeArreyElements(int[] arr, int index)
        {
            var isValidIndex = index >= 0 && index < arr.Length;
            if (!isValidIndex)
            {
                Console.WriteLine("Invalid index");
                return arr;
            }

            var leftPart = arr.Take(index + 1);
            var rightPart = arr.Skip(index + 1);

            var combinedArray = rightPart.Concat(leftPart).ToArray();
            return combinedArray;
        }
    }
}
