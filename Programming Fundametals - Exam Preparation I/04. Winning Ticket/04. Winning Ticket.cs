using System;
using System.Linq;

namespace _04.Winning_Ticket
{
    class Program
    {
        public static void Main()
        {
            /*var tickets = Console.ReadLine().Split(new[] { ','},StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToArray();

            foreach (var ticket in tickets)
            {
                if(ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                var left = new string(ticket.Take(10).ToArray());
                var right = new string(ticket.Skip(10).ToArray());

                var winningSymbols = new string[] { "@", "#", "\\$", "\\^" };
                var winningTicket = false;

                foreach (var winningSymbol in winningSymbols)
                {
                    var regex = new Regex($"{winningSymbol}{{6,}}");
                    var leftMatch = regex.Match(left);
                    if (leftMatch.Success)
                    {
                        var rightMatch = regex.Match(right);
                        if (rightMatch.Success)
                        {
                            winningTicket = true;

                            var leftSymbolsLength = leftMatch.Value.Length;
                            var rightSymbolsLength = rightMatch.Value.Length;
                            var jackpot = leftSymbolsLength == 10 && rightSymbolsLength == 10
                                ? " Jackpot!" 
                                : string.Empty;

                            Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(leftSymbolsLength, rightSymbolsLength)}{winningSymbol.Trim('\\')}{jackpot}");

                            break;
                        }
                    }

                }
                if (!winningTicket)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }*/

            // Variant 2

            var tickets = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToArray();

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                var left = ticket.Take(10).ToArray();
                var right = ticket.Skip(10).ToArray();

                var winningTicket = false;

                var leftResult = FindRepeatingSymbols(left);
                if((leftResult.Symbol == '@'
                    || leftResult.Symbol == '#'
                    || leftResult.Symbol == '$'
                    || leftResult.Symbol == '^')
                    && leftResult.Count >= 6)
                {
                    var rightResult = FindRepeatingSymbols(right);
                    if (leftResult.Symbol == rightResult.Symbol
                        && rightResult.Count >= 6)
                    {
                        var jackpot = leftResult.Count == 10 && rightResult.Count == 10
                        ? " Jackpot!"
                        : string.Empty;

                        Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(leftResult.Count, rightResult.Count)}{leftResult.Symbol}{jackpot}");                         
                        winningTicket = true;
                    }
                }
                if(!winningTicket)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
        }

        public class Result
        {
            public int Count { get; set; }

            public char Symbol { get; set; }
        }


        public static  Result FindRepeatingSymbols(char[] symbols)
        {
            var prevSymbol = symbols.First();
            int count = 1;
            int maxCount = 0;
            var maxSymbol = default(char);


            for (int i = 1; i < symbols.Length; i++)
            {
                var currentSymbol = symbols[i];

                if (prevSymbol == currentSymbol)
                {
                    count++;
                }
                else
                {
                    
                    count = 1;
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    maxSymbol = prevSymbol;
                }

                prevSymbol = currentSymbol;
            }

            return new Result
            {
                Count = maxCount,
                Symbol = maxSymbol
            };
        }
    }
}
