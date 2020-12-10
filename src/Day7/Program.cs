using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Shared;

namespace Day7
{
    public class Program
    {
        private static string containsRegexString = @"(\d+) {0} bag";
        private static Regex mainRegex = new Regex(@"^(.+) bags contain");
        private static Regex containRegex = new Regex(@"(\d+) ([a-z\s]+) bag");

        static void Main()
        {
            var input = InputGetter.ReadInputAsLines<string>(2020, 7).Result;

            var solutionPart1 = Part1Solution(input);
            Console.WriteLine(solutionPart1);

            var solutionPart2 = Part2Solution(input);
            Console.WriteLine(solutionPart2);
        }

        public static int Part1Solution(IEnumerable<string> entries)
        {
            var bagsCounted = new HashSet<string>();
            GetContainedBags(entries, "shiny gold", bagsCounted);
            return bagsCounted.Count();
        }

        public static int Part2Solution(IEnumerable<string> entries)
        {
            int bagsCounted = 0;
            GetUnderBags(entries, "shiny gold", 1, ref bagsCounted);
            return bagsCounted;
        }

        private static void GetContainedBags(IEnumerable<string> bags, string startingColor, HashSet<string> colors)
        {
            var cRegex = new Regex(string.Format(containsRegexString, startingColor));

            var upperBagColors = bags.Where(entry => cRegex.Match(entry).Success)
                .Select(entry => mainRegex.Match(entry).Groups[1].ToString());

            foreach (var bagColor in upperBagColors)
            {
                colors.Add(bagColor);

                GetContainedBags(bags, bagColor, colors);
            }
        }

        private static void GetUnderBags(IEnumerable<string> bags, string startingColor, int multifactor, ref int bagsCounted)
        {
            var bagLine = bags.First(b => b.IndexOf(startingColor) == 0);
            var underLyingBags = containRegex.Matches(bagLine);

            foreach (Match match in underLyingBags)
            {
                var colorBagsCounted = multifactor * int.Parse(match.Groups[1].ToString());
                bagsCounted += colorBagsCounted;
                GetUnderBags(bags, match.Groups[2].ToString(), colorBagsCounted, ref bagsCounted);
            }
        }
    }
}
