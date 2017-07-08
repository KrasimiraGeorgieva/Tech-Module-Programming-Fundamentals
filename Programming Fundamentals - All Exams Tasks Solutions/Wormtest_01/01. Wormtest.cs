using System;

namespace Wormtest_01
{
    class Program
    {
        static void Main()
        {
            long length = long.Parse(Console.ReadLine()) * 100;     //  in centimeters
            double width = double.Parse(Console.ReadLine());            //  in centimeters

            if (width == 0)
            {
                Console.WriteLine($"{length * width:f2}");
                return;
            }
            double percentage = length / width;
            double reminder = length % width;

            if (reminder == 0)
            {
                Console.WriteLine($"{length * width:f2}");
            }
            else
            {
                Console.WriteLine($"{percentage * 100:f2}%");
            }
        }
    }
}
