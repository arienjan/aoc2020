using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Shared;

namespace Day8
{
    public class Program
    {
        static void Main()
        {
            var input = InputGetter.ReadInputAsLines<string>(2020, 8).Result;

            // part1
            var solutionPart1 = Part1Solution(input);
            Console.WriteLine(solutionPart1);

            // part2, Moet ik hier nou gaan loopen en elke nop of jmp proberen te veranderen. Dat denk ik wel... Nu ff geen zin in
            var solutionPart2 = Part2Solution(input);
            Console.WriteLine(solutionPart2);
        }

        public static int Part1Solution(IEnumerable<string> entries)
        {
            var value = 0;
            var iter = 0;
            var executedEntries = new HashSet<int>();

            var instructions = entries.Select(e =>
            {
                var values = e.Split(' ');
                return new Tuple<string, int>(values[0], int.Parse(values[1]));
            }).ToList();


            while (!executedEntries.Any(ee => ee == iter))
            {
                var command = instructions[iter];

                executedEntries.Add(iter);

                switch (command.Item1)
                {
                    case "nop":
                        iter++;
                        break;
                    case "acc":
                        iter++;
                        value += command.Item2;
                        break;
                    case "jmp":
                        iter += command.Item2;
                        break;
                    default:
                        Console.WriteLine("DOOM");
                        break;
                }
            }

            return value;
        }

        public static int Part2Solution(IEnumerable<string> entries)
        {
            var value = 0;
            var iter = 0;
            var secontToLastCommand = false;
            var lastcommand = false;
            var numberofEntries = entries.Count();

            var instructions = entries.Select(e =>
            {
                var values = e.Split(' ');
                return new Tuple<string, int>(values[0], int.Parse(values[1]));
            }).ToList();


            while (!lastcommand)
            {
                var command = instructions[iter];

                switch (command.Item1)
                {
                    case "nop":
                        iter = iter + command.Item2 == numberofEntries - 1 || iter + command.Item2 == numberofEntries - 2 ? iter + command.Item2 : iter + 1;
                        break;
                    case "acc":
                        iter++;
                        value += command.Item2;
                        break;
                    case "jmp":
                        iter = iter + 1 == numberofEntries - 1 || iter + 1 == numberofEntries - 2 ? iter + 1 : iter + command.Item2;
                        break;
                    default:
                        Console.WriteLine("DOOM");
                        break;
                }

                if (secontToLastCommand)
                    lastcommand = true;

                if (iter == numberofEntries - 1)
                    secontToLastCommand = true;
            }

            return value;
        }
    }
}
