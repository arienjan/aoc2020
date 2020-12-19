using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Shared;
using Shared.Vectors;

namespace Day12
{
    public class Program
    {
        private static Regex regex = new Regex(@"^(N|E|S|W|F|R|L)(\d+)$");
        static void Main()
        {
            var input = InputGetter.ReadInputAsLines<string>(2020, 12).Result;

            // part1
            var solutionPart1 = Part1Solution(input);
            Console.WriteLine(solutionPart1);

            // part2
            var solutionPart2 = Part2Solution(input);
            Console.WriteLine(solutionPart2);
        }

        public static int Part1Solution(IEnumerable<string> entries)
        {
            var position = new Vector2D(0, 0);
            var direction = new Vector2D(1, 0);
            var instructions = entries.Select(e => regex.Match(e).Groups.Values.ToArray()).Select(e => new Tuple<string, int>(e[1].Value, int.Parse(e[2].Value)));

            foreach (var instruction in instructions)
            {
                switch (instruction.Item1)
                {
                    case "N":
                        position += new Vector2D(0, instruction.Item2);
                        break;
                    case "E":
                        position += new Vector2D(instruction.Item2, 0);
                        break;
                    case "S":
                        position += new Vector2D(0, -instruction.Item2);
                        break;
                    case "W":
                        position += new Vector2D(-instruction.Item2, 0);
                        break;
                    case "F":
                        position += instruction.Item2 * direction;
                        break;
                    case "R":
                    case "L":
                        var rotationFactor = instruction.Item1 == "R" ? -1 : 1;
                        var angle = rotationFactor * instruction.Item2 * Math.PI / 180;
                        var xrotated = (int)(direction.x * Math.Cos(angle) - direction.y * Math.Sin(angle));
                        var yrotated = (int)(direction.x * Math.Sin(angle) + direction.y * Math.Cos(angle));
                        direction = new Vector2D(xrotated, yrotated); 

                        break;
                    default:
                        Console.WriteLine("hoi");
                        break;
                }
            }

            return Math.Abs(position.x) + Math.Abs(position.y);
        }

        public static int Part2Solution(IEnumerable<string> entries)
        {
            var position = new Vector2D(0, 0);
            var waypoint = new Vector2D(10, 1);
            var instructions = entries.Select(e => regex.Match(e).Groups.Values.ToArray()).Select(e => new Tuple<string, int>(e[1].Value, int.Parse(e[2].Value)));

            foreach (var instruction in instructions)
            {
                switch (instruction.Item1)
                {
                    case "N":
                        waypoint += new Vector2D(0, instruction.Item2);
                        break;
                    case "E":
                        waypoint += new Vector2D(instruction.Item2, 0);
                        break;
                    case "S":
                        waypoint += new Vector2D(0, -instruction.Item2);
                        break;
                    case "W":
                        waypoint += new Vector2D(-instruction.Item2, 0);
                        break;
                    case "F":
                        position += instruction.Item2 * waypoint;
                        break;
                    case "R":
                    case "L":
                        var rotationFactor = instruction.Item1 == "R" ? -1.0 : 1.0;
                        var angle = rotationFactor * instruction.Item2 * Math.PI / 180.0;
                        var xrotated = (int)Math.Round(waypoint.x * Math.Cos(angle) - waypoint.y * Math.Sin(angle));
                        var yrotated = (int)Math.Round(waypoint.x * Math.Sin(angle) + waypoint.y * Math.Cos(angle));
                        waypoint = new Vector2D(xrotated, yrotated);

                        break;
                    default:
                        Console.WriteLine("hoi");
                        break;
                }
            }

            return Math.Abs(position.x) + Math.Abs(position.y);
        }
    }
}
