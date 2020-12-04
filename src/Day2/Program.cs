using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Shared;

namespace Day2
{
    public class Program
    {
        static void Main()
        {
            var input = InputGetter.ReadInputAsLines<string>(2020, 2).Result;

            // part1
            var solutionPart1 = Part1Solution(input);
            Console.WriteLine(solutionPart1);

            // part2
            var solutionPart2 = Part2Solution(input);
            Console.WriteLine(solutionPart2);
        }

        public static int Part1Solution(IEnumerable<string> entries)
        {
            var count = 0;
            var regex = new Regex(@"^(\d+)-(\d+) ([a-z]{1}): ([a-z].*)$", RegexOptions.Compiled);
            
            foreach (var entry in entries)
            {
                var matchValues = regex.Match(entry).Groups.Values.ToArray();

                var min = Convert.ToInt32(matchValues[1].Value);
                var max = Convert.ToInt32(matchValues[2].Value);
                var passChar = matchValues[3].Value;
                var passWord = matchValues[4].Value;

                var charsCount = passWord.Split(passChar).Count() - 1;

                if ((charsCount > min && charsCount < max) || charsCount == min || charsCount == max)
                        count++;
            }

            return count;
        }

        public static int Part2Solution(IEnumerable<string> entries)
        {
            var count = 0;
            var regex = new Regex(@"^(\d+)-(\d+) ([a-z]{1}): ([a-z].*)$", RegexOptions.Compiled);

            foreach (var entry in entries)
            {
                var matchValues = regex.Match(entry).Groups.Values.ToArray();

                var min = Convert.ToInt32(matchValues[1].Value) - 1;
                var max = Convert.ToInt32(matchValues[2].Value) - 1;
                var passChar = Convert.ToChar(matchValues[3].Value);
                var passWord = matchValues[4].Value;

                var charsCount = passWord.Split(passChar).Count() - 1;

                if ((passWord[min] == passChar && passWord[max] != passChar) || (passWord[min] != passChar && passWord[max] == passChar))
                    count++;
            }

            return count;
        }
    }
}
