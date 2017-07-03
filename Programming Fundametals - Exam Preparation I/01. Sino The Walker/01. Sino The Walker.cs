using System;
using System.Globalization;

namespace _01.Sino_The_Walker
{
    class Program
    {
        static void Main()
        {
            var timeFormst = "HH:mm:ss";

            var startingTime = DateTime.ParseExact(Console.ReadLine(), timeFormst, CultureInfo.InvariantCulture);

            var numberOfSteps = int.Parse(Console.ReadLine());

            var secondsPerStep = int.Parse(Console.ReadLine());

            long initalSeconds = startingTime.Hour * 60 * 60 + startingTime.Minute * 60 + startingTime.Second;

            ulong secondsToAdd = (ulong)numberOfSteps * (ulong)secondsPerStep;

            ulong totalSeconds = (ulong)initalSeconds + secondsToAdd;

            var seconds = totalSeconds % 60;
            var totalMinutes = totalSeconds / 60;
            var minutes = totalMinutes % 60;
            var totalHours = totalMinutes / 60;
            var hours = totalHours % 24;

            Console.WriteLine($"Time Arrival: {hours:00}:{minutes:00}:{seconds:00}");
        }
    }
}
