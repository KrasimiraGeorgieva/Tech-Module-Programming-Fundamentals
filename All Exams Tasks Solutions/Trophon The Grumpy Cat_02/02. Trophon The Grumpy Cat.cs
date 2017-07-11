using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Trophon_The_Grumpy_Cat
{
    class Program
    {
        static void Main()
        {
            // Variant 1

            long[] items = Console.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToArray();

            int entryIndex = int.Parse(Console.ReadLine());
            string typeOfItemsToBreak = Console.ReadLine();  // cheap, expensive
            string typeOfPriceRate = Console.ReadLine();  // positive, negative, all

            long leftSum = 0;
            long rightSum = 0;
            
            if (typeOfItemsToBreak == "cheap")
            {
                if (typeOfPriceRate == "positive")
                {
                    leftSum = items.Take(entryIndex).Where(x => x < items[entryIndex]).Where(x => x > 0).Sum();
                    rightSum = items.Skip(entryIndex + 1).Where(x => x < items[entryIndex]).Where(x => x > 0).Sum();
                }
                else if (typeOfPriceRate == "negative")
                {
                    leftSum = items.Take(entryIndex).Where(x => x < items[entryIndex]).Where(x => x < 0).Sum();
                    rightSum = items.Skip(entryIndex + 1).Where(x => x < items[entryIndex]).Where(x => x < 0).Sum();
                }
                else if (typeOfPriceRate == "all")
                {
                    leftSum = items.Take(entryIndex).Where(x => x < items[entryIndex]).Sum();
                    rightSum = items.Skip(entryIndex + 1).Where(x => x < items[entryIndex]).Sum();
                }
            }
            else if (typeOfItemsToBreak == "expensive")
            {
                if (typeOfPriceRate == "positive")
                {
                    leftSum = items.Take(entryIndex).Where(x => x >= items[entryIndex]).Where(x => x > 0).Sum();
                    rightSum = items.Skip(entryIndex + 1).Where(x => x >= items[entryIndex]).Where(x => x > 0).Sum();
                }
                else if (typeOfPriceRate == "negative")
                {
                    leftSum = items.Take(entryIndex).Where(x => x >= items[entryIndex]).Where(x => x < 0).Sum();
                    rightSum = items.Skip(entryIndex + 1).Where(x => x >= items[entryIndex]).Where(x => x < 0).Sum();

                }
                else if (typeOfPriceRate == "all")
                {
                    leftSum = items.Take(entryIndex).Where(x => x >= items[entryIndex]).Sum();
                    rightSum = items.Skip(entryIndex + 1).Where(x => x >= items[entryIndex]).Sum();
                }
            }

            if (leftSum >= rightSum)
            {
                Console.WriteLine($"Left - {leftSum}");
            }
            else
            {
                Console.WriteLine($"Right - {rightSum}");
            }


            // Variant 2
            /*
            long[] numbers = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            int entryPoint = int.Parse(Console.ReadLine());
            long entryValue = numbers[entryPoint];
            string typeOfItems = Console.ReadLine();
            string typeOfPriceIndexes = Console.ReadLine();

            long sumLeft = 0;
            long sumRight = 0;

            var rightSide = new List<long>();
            for (int i = entryPoint + 1; i < numbers.Length; i++)
            {
                rightSide.Add(numbers[i]);
            }

            var leftSide = new List<long>();
            for (int i = entryPoint - 1; i >= 0; i--)
            {
                leftSide.Add(numbers[i]);
            }

            switch (typeOfItems)
            {
                case "cheap":
                    switch (typeOfPriceIndexes)
                    {
                        case "positive":
                            sumRight = rightSide
                                .Where(x => x < entryValue)
                                .Where(x => x > 0)
                                .Sum();
                            sumLeft = leftSide
                                .Where(x => x < entryValue)
                                .Where(x => x > 0)
                                .Sum();
                            break;
                        case "negative":
                            sumRight = rightSide
                                .Where(x => x < entryValue)
                                .Where(x => x < 0)
                                .Sum();
                            sumLeft = leftSide
                                .Where(x => x < entryValue)
                                .Where(x => x < 0)
                                .Sum();
                            break;
                        case "all":
                            sumRight = rightSide
                                .Where(x => x < entryValue)
                                .Sum();
                            sumLeft = leftSide
                               .Where(x => x < entryValue)
                               .Sum();
                            break;
                    }
                    break;

                case "expensive":
                    switch (typeOfPriceIndexes)
                    {
                        case "positive":
                            sumRight = rightSide
                                .Where(x => x >= entryValue)
                                .Where(x => x > 0)
                                .Sum();
                            sumLeft = leftSide
                                .Where(x => x >= entryValue)
                                .Where(x => x > 0)
                                .Sum();
                            break;
                        case "negative":
                            sumRight = rightSide
                                .Where(x => x >= entryValue)
                                .Where(x => x < 0)
                                .Sum();
                            sumLeft = leftSide
                                .Where(x => x >= entryValue)
                                .Where(x => x < 0)
                                .Sum();
                            break;
                        case "all":
                            sumRight = rightSide
                                .Where(x => x >= entryValue)
                                .Sum();
                            sumLeft = leftSide
                               .Where(x => x >= entryValue)
                               .Sum();
                            break;
                    }
                    break;
            }

            Console.WriteLine(sumLeft >= sumRight ? $"Left - {sumLeft}" : $"Right - {sumRight}");
            */

        }
    }
}
