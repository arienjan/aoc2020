using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Day13
{
    public class Program
    {
        static void Main()
        {
            var input = InputGetter.ReadInputAsLines<string>(2020, 13).Result.ToList();

            // part1
            var solutionPart1 = Part1Solution(input);
            Console.WriteLine(solutionPart1);

            // part2
            var solutionPart2 = Part2Solution(input);
            Console.WriteLine(solutionPart2);
        }

        public static int Part1Solution(List<string> input)
        {
            var departureTime = int.Parse(input[0]);
            var busTimes = input[1].Split(",").Where(i => i != "x").Select(i => int.Parse(i)).ToList();

            var times = busTimes.Select(bt => bt - (departureTime % bt)).ToList();
            var minBusIndex = times.IndexOf(times.Min());
            var earliestBusIndexTime = busTimes[minBusIndex] * times[minBusIndex];
            return earliestBusIndexTime;
        }

        public static long Part2Solution(List<string> input)
        {
            var primes = input[1].Split(',').Select((s, i) =>
            {
                if (int.TryParse(s, out int n))
                {
                    return new Tuple<int, int>(n, i == 0 ? 0 : n - (i % n));
                }

                return null;
            }).Where(t => t != null);

            var val = 0L;
            var previous = 1L;

            foreach (var item in primes)
            {
                if (val == 0)
                {
                    val = item.Item1 - item.Item2;
                }
                else
                {
                    while (val % item.Item1 != item.Item2)
                    {
                        val += previous;
                    }
                }

                previous *= item.Item1;
            }

            return val;
        }
    }
}
