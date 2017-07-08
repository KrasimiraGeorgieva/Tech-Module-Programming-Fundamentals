using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Melrah_Shake
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var pattern = Console.ReadLine();

            var canMelrahShake = true;

            while (canMelrahShake)
            {
                var firstIndex = input.IndexOf(pattern);
                var lastIndex = input.LastIndexOf(pattern);

                if (firstIndex > -1 && lastIndex > -1 && pattern.Length > 0)
                {
                    firstIndex = input.IndexOf(pattern);
                    input = input.Remove(firstIndex, pattern.Length);
                    lastIndex = input.LastIndexOf(pattern);
                    input = input.Remove(lastIndex, pattern.Length);
                    Console.WriteLine("Shaked it.");

                    if (pattern.Length > 0)
                    {
                        pattern = pattern.Remove(pattern.Length / 2, 1);
                    }
                }
                else
                {
                    Console.WriteLine("No shake.");
                    canMelrahShake = false;
                    break;
                }
            }

            Console.WriteLine(input);
        }
    }
}
