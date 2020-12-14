using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Day9
{
    public class Program
    {
        static void Main()
        {
            var input = InputGetter.ReadInputAsLines<long>(2020, 9).Result;

            // part1
            var solutionPart1 = Part1Solution(input, 25);
            Console.WriteLine(solutionPart1);

            // part2
            var solutionPart2 = Part2Solution(input, solutionPart1);
            Console.WriteLine(solutionPart2);
        }

        public static long Part1Solution(IEnumerable<long> entries, int preambleLength)
        {
            var entriesToLoop = entries.Skip(preambleLength).ToList();

            for (int i = 0 ; i<entriesToLoop.Count(); i++ )
            {
                var summedEntries = entries.Skip(i).Take(preambleLength);
                var sums = summedEntries.SelectMany(se => summedEntries.Select(see => see != se ? see + se : -1));

                if (!sums.Any(s => s == entriesToLoop[i]))
                    return entriesToLoop[i];
            }

            return 1;
        }

        public static long Part2Solution(IEnumerable<long> entries, long invalidNumber)
        {
            var index = entries.ToList().IndexOf(invalidNumber);

            for (int i = 3; i<=index; i++)
            {
                for (int j = 0; j<index-i; j++)
                {
                    var sumList = entries.Skip(j).Take(i).ToList();
                    if (sumList.Sum() == invalidNumber)
                        return sumList[0] + sumList[sumList.Count() - 1];
                }
            }

            return 1;
        }
    }
}
