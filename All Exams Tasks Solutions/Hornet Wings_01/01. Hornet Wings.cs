using System;

namespace _01.Hornet_Wings
{
    class Program
    {
        static void Main()
        {
            int wingFlaps = int.Parse(Console.ReadLine());
            double distancePer1000wingFlaps = double.Parse(Console.ReadLine());
            int endurance = int.Parse(Console.ReadLine());

            var distance = Math.Abs(wingFlaps / 1000) * distancePer1000wingFlaps;

            var secondsFlaps = wingFlaps / 100;
            var secondsRests = (wingFlaps / endurance) * 5;
            var secondsPassed = secondsFlaps + secondsRests;

            Console.WriteLine($"{ distance:f2} m.");
            Console.WriteLine($"{secondsPassed} s.");
        }
    }
}
