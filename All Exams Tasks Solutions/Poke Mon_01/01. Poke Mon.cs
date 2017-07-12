using System;

namespace _01
{
    class Program
    {
        static void Main()
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int count = 0;
            int resultPower = pokePower;
            decimal halfPower = 0.5m * pokePower;

            while (pokePower >= distance)
            {
                count++;
                pokePower -= distance;
                if (pokePower == halfPower)
                {
                    if (exhaustionFactor > 0)
                        pokePower = pokePower / exhaustionFactor;
                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(count);
        }
    }
}
