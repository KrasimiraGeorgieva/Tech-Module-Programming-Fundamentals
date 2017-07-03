using System;
using System.Linq;

namespace _03.Endurance_Rally
{
    class Program
    {
        static void Main()
        {
            var drivers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var track = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var checkpoint = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (var driver in drivers)
            {
                double fuel = driver.First();

                for (int i = 0; i < track.Length; i++)
                {
                    var currentZoneFuel = track[i];

                    if (checkpoint.Contains(i))
                    {
                        fuel += currentZoneFuel;
                    }
                    else
                    {
                        fuel -= currentZoneFuel;
                    }

                    if (fuel <= 0)
                    {
                        Console.WriteLine($"{driver} - reached {i}");
                        break;
                    }
                }
                if (fuel > 0)
                {
                    Console.WriteLine($"{driver} - fuel left {fuel:f2}");
                }
            }
        }
    }
}
