using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Day6
{
    public class Program
    {
        static void Main()
        {
            var input = InputGetter.ReadInputAsLines<string>(2020, 6).Result;

            // part1
            var solutionPart1 = Part1Solution(input);
            Console.WriteLine(solutionPart1);

            var solutionPart2 = Part2Solution(input);
            Console.WriteLine(solutionPart2);
        }

        public static int Part1Solution(IEnumerable<string> answers)
        {
            var allAnswers = answers.Aggregate((i, j) => string.IsNullOrEmpty(j) ? i + " " + j : i + j)
                .Split(" ")
                .Select(a => (new HashSet<char>(a)).Count())
                .Sum();

            return allAnswers;
        }

        public static int Part2Solution(IEnumerable<string> answers)
        {
            var groupCount = 0;

            var allAnswers = answers.Select(a =>
            {
                if (string.IsNullOrEmpty(a))
                    groupCount++;

                return new
                {
                    Answers = a,
                    Group = groupCount
                };
            })
                .GroupBy(a => a.Group)
                .Select(a =>
                {
                    var allAnswers = new HashSet<char>(string.Join(string.Empty, a.Select(ans => ans.Answers)));
                    var allAnswerCount = 0;

                    foreach (var atje in allAnswers)
                        if (a.Where(ansje => !string.IsNullOrEmpty(ansje.Answers)).All(ansje => ansje.Answers.Contains(atje)))
                            allAnswerCount++;

                    return allAnswerCount;
                })
                .Sum();

            return allAnswers;
        }
    }
}
