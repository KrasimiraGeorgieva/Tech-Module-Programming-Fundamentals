using System;
using System.Linq;

namespace Array_Modifier_02
{
    class Program
    {
        static void Main()
        {
            long[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] currentCommand = command.Split(' ').ToArray();

                if (currentCommand[0] == "decrease")
                {
                    numbers = numbers.Select(n => n - 1).ToArray();
                }
                else
                {
                    int firstIndex = int.Parse(currentCommand[1]);
                    int secondIndex = int.Parse(currentCommand[2]);

                    if (currentCommand[0] == "swap")
                    {
                        long second = numbers[secondIndex];
                        numbers[secondIndex] = numbers[firstIndex];
                        numbers[firstIndex] = second;
                    }
                    else if (currentCommand[0] == "multiply")
                    {
                        numbers[firstIndex] *= numbers[secondIndex];
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
