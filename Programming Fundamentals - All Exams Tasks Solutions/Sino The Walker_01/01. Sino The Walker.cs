using System;
using System.Globalization;
using System.Linq;

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




            //Variant 2

            //var nums = Console.ReadLine().Split(':').Select(int.Parse).ToArray();
            //long seconds = nums[2] + 60 * nums[1] + 60 * 60 * nums[0];
            //var secondsToAdd = 
            //    long.Parse(Console.ReadLine()) *
            //    long.Parse(Console.ReadLine());
            //seconds = seconds + secondsToAdd;

            //var secs = seconds % 60;
            //var mins = (seconds / 60) % 60;
            //var hours = (seconds / 60 / 60) % 24;

            //Console.WriteLine("Time Arrival: {0:d2}:{1:d2}:{2:d2}", hours, mins, secs);


            //Variant 3
            //var date = DateTime.Parse(Console.ReadLine());
            //var steps = int.Parse(Console.ReadLine());
            //var timeInSeconds = int.Parse(Console.ReadLine());
            //var secondsToAdd = (long)steps * timeInSeconds;
            //var day = 24 * 60 * 60;
            //secondsToAdd = secondsToAdd % day;
            //var resultDate = date.AddSeconds(secondsToAdd);
            //Console.WriteLine("Time Arrival: {0:HH:mm:ss}", resultDate);


            //Variant 4

            //var date = DateTime.Parse(Console.ReadLine());

            //var steps = int.Parse(Console.ReadLine());
            //var timeInSeconds = int.Parse(Console.ReadLine());
            //var secondsToAdd = (long)steps * timeInSeconds;

            //var secs = (int)(secondsToAdd % 60);
            //var mins = (int)((secondsToAdd / 60) % 60);
            //var hours = (int)((secondsToAdd / 60 / 60) % 24);

            //var resultDate = date.Add(new TimeSpan(hours, mins, secs));
            //Console.WriteLine("Time Arrival: {0:HH:mm:ss}", resultDate);

        }
    }
}
