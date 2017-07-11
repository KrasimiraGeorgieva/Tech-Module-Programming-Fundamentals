using System;

namespace Splinter_Trip_01
{
    class Program
    {
        static void Main()
        {
            double tripDistance = double.Parse(Console.ReadLine());
            double fuelTankCapacity = double.Parse(Console.ReadLine());
            double milesInHeavyWind = double.Parse(Console.ReadLine());

            double fuelConsumption = (tripDistance - milesInHeavyWind) * 25 + milesInHeavyWind * 25 * 1.5;

            double fuelNeeded = fuelConsumption * 1.05;

            double difference = Math.Abs(fuelNeeded - fuelTankCapacity);

            Console.WriteLine($"Fuel needed: {fuelNeeded:f2}L");

            if (fuelTankCapacity < fuelNeeded)
            {
                Console.WriteLine($"We need {difference:f2}L more fuel.");
            }
            else
            {
                Console.WriteLine($"Enough with {difference:f2}L to spare!");
            }
        }
    }
}
