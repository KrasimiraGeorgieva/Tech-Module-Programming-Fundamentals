using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _03.Critical_Breakpoint
{
    public class Line
    {
        public int X1 { get; set; }

        public int Y1 { get; set; }

        public int X2 { get; set; }

        public int Y2 { get; set; }

        public BigInteger CriticalRatio { get; set; }

        public static Line LineParse(int[] arr, BigInteger r)
        {
            return new Line()
            {
                X1 = arr[0],

                Y1 = arr[1],

                X2 = arr[2],

                Y2 = arr[3],

                CriticalRatio = r
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var lines = new List<Line>();

            while (input != "Break it.")
            {
                var parameters = input.Split().Select(int.Parse).ToArray();

                var criticulRatio =

                    BigInteger.Abs((long)(parameters[2] + parameters[3]) - (long)(parameters[0] + parameters[1]));

                var line = Line.LineParse(parameters, criticulRatio);

                lines.Add(line);

                input = Console.ReadLine();
            }

            var hasBreakPoint = true;

            var currentRatio = (BigInteger)0;

            foreach (var line in lines)
            {
                if (currentRatio == 0 && line.CriticalRatio != 0)
                {
                    currentRatio = line.CriticalRatio;
                }
                if ((currentRatio != line.CriticalRatio) && (line.CriticalRatio != 0))
                {
                    hasBreakPoint = false;

                    break;
                }
            }

            if (hasBreakPoint)
            {
                var total = BigInteger.Pow(currentRatio, lines.Count);

                var breakPoint = (BigInteger)0; ;

                BigInteger.DivRem(total, lines.Count, out breakPoint);

                foreach (var line in lines)
                {
                    Console.WriteLine($"Line: [{line.X1}, {line.Y1}, {line.X2}, {line.Y2}]");
                }

                Console.WriteLine($"Critical Breakpoint: {breakPoint}");
            }
            else
            {
                Console.WriteLine("Critical breakpoint does not exist.");
            }
        }
    }
}
