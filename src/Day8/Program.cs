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

            // part2
            var solutionPart2 = Part2Solution(input);
            Console.WriteLine(solutionPart2);
        }

        public static int Part1Solution(IEnumerable<string> entries)
        {
            var instructions = FormatEntries(entries);
            return DoesItLoop(instructions).Item1;
        }

        public static int Part2Solution(IEnumerable<string> entries)
        {
            var instructions = FormatEntries(entries);

            for (int i = 0; i < instructions.Count(); i++)
            {
                var instruction = instructions[i];
                var instructionLoop = instructions.Select(i => i).ToList(); // clone lijst

                if (instruction.Item1 == "nop")
                    instruction = new Tuple<string, int>("jmp", instruction.Item2);
                else if (instruction.Item1 == "jmp")
                    instruction = new Tuple<string, int>("nop", instruction.Item2);

                instructionLoop[i] = instruction;

                var bla = DoesItLoop(instructionLoop);

                if (bla.Item2 == false)
                    return bla.Item1;
            }

            return 1;
        }

        private static List<Tuple<string, int>> FormatEntries(IEnumerable<string> entries)
        {
            return entries.Select(e =>
            {
                var values = e.Split(' ');
                return new Tuple<string, int>(values[0], int.Parse(values[1]));
            }).ToList();
        }

        private static (int, bool) DoesItLoop(List<Tuple<string, int>> instructions)
        {
            var loops = false;
            var value = 0;
            var iter = 0;
            var secontToLastCommand = false;
            var lastcommand = false;
            var numberofEntries = instructions.Count();
            var executedEntries = new HashSet<int>();

            while (!lastcommand)
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

                if (executedEntries.Any(ee => ee == iter))
                {
                    loops = true;
                    break;
                }

                if (secontToLastCommand)
                    lastcommand = true;

                if (iter == numberofEntries - 1)
                    secontToLastCommand = true;
            }

            return (value, loops);
        }
    }
}
