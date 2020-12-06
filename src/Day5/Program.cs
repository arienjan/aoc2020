using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Day5
{
    public class Program
    {
        static void Main()
        {
            var input = InputGetter.ReadInputAsLines<string>(2020, 5).Result;

            // part1
            var solutionPart1 = Part1Solution(input);
            Console.WriteLine(solutionPart1);

            // part1
            var solutionPart2 = Part2Solution(input);
            Console.WriteLine(solutionPart2);
        }

        public static int Part1Solution(IEnumerable<string> entries)
        {
            return GetSeats(entries).Max(s => s.SeatId);
        }

        public static int Part2Solution(IEnumerable<string> entries)
        {
            var seats = GetSeats(entries);

            foreach (var seat in seats)
            {
                if (!seats.Any(s => s.SeatId == seat.SeatId + 1) && seats.Any(s => s.SeatId == seat.SeatId + 2))
                {
                    return seat.SeatId + 1;
                }
            }

            return -1;
        }

        private static IEnumerable<dynamic> GetSeats(IEnumerable<string> entries)
        {
            return entries.Select(e =>
            {
                var rowNumber = Convert.ToInt32(new string(e.Take(7).Select(r => r == 'B' ? '1' : '0').ToArray()), 2);
                var colNumber = Convert.ToInt32(new string(e.Skip(7).Take(3).Select(r => r == 'R' ? '1' : '0').ToArray()), 2);
                return new
                {
                    Row = rowNumber,
                    Column = colNumber,
                    SeatId = rowNumber * 8 + colNumber
                };
            });
        }
    }
}
