using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Endurance_Rally
{
    class Program
    {
        static void Main()
        {
            //zadacha 3  judge 100/100

            string[] players = Regex.Split(Console.ReadLine(), @"\s+");
            double[] route = Regex.Split(Console.ReadLine(), @"\s+").Select(p => double.Parse(p) * -1).ToArray();
            long[] checkpointIndexes = Regex.Split(Console.ReadLine(), @"\s+").Where(t => t.Length > 0).Select(long.Parse).Distinct().ToArray();

            foreach (var i in checkpointIndexes)
            {
                if (i >= 0 && i < route.Length)
                {
                    route[i] *= -1;
                }
            }
            foreach (var p in players)
            {
                var fuel = (double)p[0];
                var index = 0;
                foreach (var r in route)
                {
                    fuel += r;
                    if (fuel <= 0)
                    {
                        Console.WriteLine("{0} - reached {1}", p, index);
                        break;
                    }
                    index++;
                }
                if (fuel > 0)
                {
                    Console.WriteLine("{0} - fuel left {1:F2}", p, fuel);
                }
            }


            //var drivers = Console.ReadLine()
            //    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //var track = Console.ReadLine()
            //    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(double.Parse)
            //    .ToArray();

            //var checkpoint = Console.ReadLine()
            //    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();

            //foreach (var driver in drivers)
            //{
            //    double fuel = driver.First();

            //    for (int i = 0; i < track.Length; i++)
            //    {
            //        var currentZoneFuel = track[i];

            //        if (checkpoint.Contains(i))
            //        {
            //            fuel += currentZoneFuel;
            //        }
            //        else
            //        {
            //            fuel -= currentZoneFuel;
            //        }

            //        if (fuel <= 0)
            //        {
            //            Console.WriteLine($"{driver} - reached {i}");
            //            break;
            //        }

            //    }
            //    if (fuel > 0)
            //    {
            //        Console.WriteLine($"{driver} - fuel left {fuel:f2}");
            //    }
            //}
        }
    }
}
