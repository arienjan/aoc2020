using System;
using System.Collections.Generic;
using System.Linq;
using Shared;
using Shared.Vectors;

namespace Day11
{
    public class Program
    {
        static void Main()
        {
            var input = InputGetter.ReadInputAsLines<string>(2020, 11).Result;

            // part1
            var solutionPart1 = Part2Solution(input, 4, SetSeatRefs);
            Console.WriteLine(solutionPart1);
            // part1
            var solutionPart2 = Part2Solution(input, 5, SetSeatRefs2);
            Console.WriteLine(solutionPart2);
        }

        public static int Part2Solution(IEnumerable<string> entries, int seatTolerance, Action<List<Seat>> SeatGetter)
        {
            // zet alle stoelen en referenties naar andere stoelen
            var seats = GetSeats2(entries);
            SeatGetter(seats);

            var seating = true;
            var overallCounter = 0;

            while (seating)
            {
                overallCounter = 0;
                foreach (var seat in seats)
                {
                    if (seat.Occupance == 'L')
                    {
                        if (!seat.RefSeats.Any(s => s?.Occupance == '#'))
                        {
                            seat.NextOccupance = '#';
                            overallCounter++;
                        }
                    }
                    else if (seat.Occupance == '#')
                    {
                        if (seat.RefSeats.Where(s => s?.Occupance == '#').Count() >= seatTolerance)
                        {
                            seat.NextOccupance = 'L';
                            overallCounter++;
                        }

                    }
                }

                if (overallCounter == 0)
                    seating = false;

                foreach (var seat in seats)
                    seat.Occupance = seat.NextOccupance;
            }

            return seats.Where(s => s.Occupance == '#').Count();
        }

        public class Seat
        {
            public int X { get; set; }
            public int Y { get; set; }
            public char Occupance { get; set; }
            public char NextOccupance { get; set; }
            public List<Seat?> RefSeats { get; set; }

            public Seat()
            {
                this.RefSeats = new List<Seat?>();
            }
        }

        public static List<Seat> GetSeats2(IEnumerable<string> entries)
        {
            return entries.SelectMany((seatRow, rowIndex) =>
            {
                return seatRow.Select((seat, seatIndex) =>
                {
                    return new Seat() { X = rowIndex, Y = seatIndex, Occupance = seat, NextOccupance = '.' };
                });
            }).ToList();
        }

        public static void SetSeatRefs(List<Seat> seats)
        {
            foreach (var seat in seats)
            {
                foreach (var diag in GetDiagonals())
                {
                    seat.RefSeats.Add(seats.FirstOrDefault(s => s.X == seat.X + diag.Item1 && s.Y == seat.Y + diag.Item2));
                }
            }
        }

        public static void SetSeatRefs2(List<Seat> seats)
        {
            var xmax = seats.Select(s => s.X).Max();
            var ymax = seats.Select(s => s.Y).Max();
            foreach (var seat in seats)
            {
                foreach (var diag in GetDiagonals())
                {
                    // die diag is al een soort van vector, dus die kunnen we gebruiken om de volgende stoel te vinden
                    for (int i = 1; i< seats.Count(); i++)
                    {
                        var searchVector = i * new Vector2D(diag.Item1, diag.Item2);

                        if (searchVector.x + seat.X < 0
                            || searchVector.y + seat.Y < 0
                            || searchVector.x + seat.X > xmax
                            || searchVector.y + seat.Y > ymax)
                            break;

                        if (seats.Any(s => s.X == searchVector.x + seat.X && s.Y == searchVector.y + seat.Y && s.Occupance != '.'))
                        {
                            seat.RefSeats.Add(seats.FirstOrDefault(s => s.X == searchVector.x + seat.X && s.Y == searchVector.y + seat.Y));
                            break;
                        }
                    }
                }
            }
        }

        private static IEnumerable<(int, int)> GetDiagonals()
        {
            for (var x = -1; x <= 1; x++)
            {
                for (var y = -1; y <= 1; y++)
                {
                    if (!(x == 0 && y == 0))
                    {
                        yield return (x, y);
                    }
                }
            }
        }
    }
}
