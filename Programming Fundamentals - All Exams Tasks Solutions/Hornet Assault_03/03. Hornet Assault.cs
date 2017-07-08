using System;
using System.Linq;

namespace _03.Hornet_Assault
{
    class Program
    {
        static void Main()
        {
            var beehives = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            var hornets = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            var power = hornets.Sum();
            var currentFirstHornetIndex = 0;
            for (int i = 0; i < beehives.Length; i++)
            {
                var bees = beehives[i];

                if (bees >= power)
                {
                    beehives[i] -= power;
                    if (currentFirstHornetIndex < hornets.Length)
                    {
                        power -= hornets[currentFirstHornetIndex];
                        currentFirstHornetIndex++;
                    }
                }
                else
                {
                    beehives[i] -= power;
                }
            }

            if(beehives.Any(b => b > 0))
            {
                var result = beehives.Where(b => b > 0);
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                var result = hornets.Skip(currentFirstHornetIndex);
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
