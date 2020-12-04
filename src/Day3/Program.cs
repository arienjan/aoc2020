using System;
using System.Collections.Generic;
using System.Linq;
using Shared;
using Shared.Vectors;

namespace Day3
{
    public class Program
    {
        static void Main()
        {
            var input = InputGetter.ReadInputAsLines<string>(2020, 3).Result;

            // part1
            var solutionPart1 = Part1Solution(input);
            Console.WriteLine(solutionPart1);

            // part2
            var solutionPart2 = Part2Solution(input);
            Console.WriteLine(solutionPart2);
        }

        public static int Part1Solution(IEnumerable<string> entries)
        {
            return CalculateTreesHit(entries, new Vector2D(3, 1));
        }

        public static int Part2Solution(IEnumerable<string> entries)
        {
            var movementDirections = new[]
            {
                new Vector2D(1, 1),
                new Vector2D(3, 1),
                new Vector2D(5, 1),
                new Vector2D(7, 1),
                new Vector2D(1, 2),
            };

            var solution = 1;

            foreach (var movementDirection in movementDirections)
            {
                solution *= CalculateTreesHit(entries, movementDirection);
            }

            return solution;
        }

        private static int CalculateTreesHit(IEnumerable<string> entries, Vector2D movementDirection)
        {
            var slopeHeight = entries.Count();
            var position = new Vector2D(0, 0);
            var treeLines = entries.ToArray();
            var treeLineWidth = treeLines[0].Count();
            var treeCount = 0;

            do
            {
                if (treeLines[position.y][position.x % treeLineWidth] == '#')
                    treeCount++;

                position += movementDirection;
            }
            while (position.y < slopeHeight);

            return treeCount;
        }
    }
}
