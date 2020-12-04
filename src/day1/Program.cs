using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Day1
{
    public class Program
    {
        static void Main()
        {
            var input = InputGetter.ReadInputAsLines<int>(2020, 1).Result;

            // part1
            var solutionPart1 = Part1Solution(input);
            Console.WriteLine(solutionPart1);

            // part2
            var solutionPart2 = Part2Solution(input);
            Console.WriteLine(solutionPart2);
        }

        public static int Part1Solution(IEnumerable<int> entries)
        {
            var output = entries.SelectMany(entry1 => entries.Select(entry2 => entry1 + entry2 == 2020 ? entry1 * entry2 : 0)).Max();
            return output;
        }

        public static int Part2Solution(IEnumerable<int> entries)
        {
            var output = entries.SelectMany(entry1 => entries.SelectMany(entry2 => entries.Select(entry3 => entry1 + entry2 + entry3 == 2020 ? entry1 * entry2 * entry3 : 0))).Max();
            return output;
        }
    }
}
