using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Day10
{
    public class Program
    {
        private static List<int> StepPossibilities = new List<int> { 1, 1, 2 };

        static void Main()
        {
            var input = InputGetter.ReadInputAsLines<int>(2020, 10).Result;

            // part1
            var solutionPart1 = Part1Solution(input);
            Console.WriteLine(solutionPart1);

            // part2
            var solutionPart2 = Part2Solution(input);
            Console.WriteLine(solutionPart2);
        }

        public static int Part1Solution(IEnumerable<int> entries)
        {
            var differences = GetDifferences(entries);
            return differences.Where(d => d == 1).Count() * (differences.Where(d => d == 3).Count() + 1);
        }

        public static long Part2Solution(IEnumerable<int> entries)
        {
            // Het is dus een soort van fibbonacci
            // Maak eerst een clusters van 1 stapjes in de verschillen die groter zijn dan 2 opeenvolgende
            var clusterSizes = new List<int>();
            var clusterSize = 1;

            var differences = GetDifferences(entries).ToList();
            differences.ForEach(d =>
            {
                if (d == 1)
                {
                    clusterSize++;
                }
                if (d == 3)
                {
                    clusterSizes.Add(clusterSize);
                    clusterSize = 1;
                }
            });

            var stepPossibilitiesPerCluster = clusterSizes.Select(cs => (long)GetStepPossibilities(cs));

            return stepPossibilitiesPerCluster.Aggregate(1L, (acc, val) => acc * val);
        }

        public static IEnumerable<int> GetDifferences(IEnumerable<int> entries)
        {
            var entrylist = entries.ToList();
            entrylist.Add(0);  // start from 0
            var sortedAdapters = entrylist.OrderBy(e => e).ToList();
            return sortedAdapters.Skip(1).Select(adapter => adapter - sortedAdapters[sortedAdapters.IndexOf(adapter) - 1]);
        }

        public static int GetStepPossibilities(int steps)
        {
            var stepPossibilitiesCount = StepPossibilities.Count();
            if (stepPossibilitiesCount > steps - 1)
                return StepPossibilities[steps - 1];


            for (int i = stepPossibilitiesCount; i < steps; i++)
            {
                var stepPossibilityToAdd = StepPossibilities.Skip(i - 3 < 0 ? 0 : i - 3).Take(3).Sum();
                StepPossibilities.Add(stepPossibilityToAdd);
            }

            return StepPossibilities[steps - 1];
        }
    }
}
