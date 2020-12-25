using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Shared;

namespace Day14
{
    public class Program
    {
        private static Regex maskRegex = new Regex(@"^mask = (.*)$");
        private static Regex memRegex = new Regex(@"^mem\[(\d.*)\] = (\d.*)$");

        static void Main()
        {
            var input = InputGetter.ReadInputAsLines<string>(2020, 14).Result.ToList();

            // part 1;
            var solutionPart1 = Part1Solution(input);
            Console.WriteLine(solutionPart1);

            // part 2;
            var solutionPart2 = Part2Solution(input);
            Console.WriteLine(solutionPart2);
        }

        public static long Part1Solution(List<string> entries)
        {
            var memory = new Dictionary<int, long>();
            string mask = string.Empty;

            foreach (var entry in entries)
            {
                var match = memRegex.Match(entry);

                if (!match.Success)
                {
                    mask = maskRegex.Match(entry).Groups[1].Value;
                }
                else
                {
                    var matchGroups = match.Groups.Values.ToList();
                    var memLocation = int.Parse(matchGroups[1].Value);
                    var memValue = int.Parse(matchGroups[2].Value);

                    var bitValue = (Convert.ToString(memValue, 2)).PadLeft(mask.Length, '0');

                    var maskedBitValue = new string(bitValue.Select((bit, index) => mask[index] != 'X' ? mask[index] : bit).ToArray());
                    var maskedValue = Convert.ToInt64(maskedBitValue, 2);

                    memory[memLocation] = maskedValue;
                }
            }

            return memory.Values.Sum();
        }

        public static long Part2Solution(List<string> entries)
        {
            var memory = new Dictionary<long, long>();
            string mask = string.Empty;

            foreach (var entry in entries)
            {
                var match = memRegex.Match(entry);

                if (!match.Success)
                {
                    mask = maskRegex.Match(entry).Groups[1].Value;
                }
                else
                {
                    var matchGroups = match.Groups.Values.ToList();
                    var memLocation = int.Parse(matchGroups[1].Value);
                    var memValue = int.Parse(matchGroups[2].Value);

                    var bitValue = (Convert.ToString(memLocation, 2)).PadLeft(mask.Length, '0');

                    var maskedBitValue = bitValue.Select((bit, index) => mask[index] != '0' ? mask[index] : bit).ToList();

                    var memoryAddressesChars = new List<List<char>>();

                    ReplaceFloating(maskedBitValue, memoryAddressesChars);

                    var memoryAddresses = memoryAddressesChars.Select(ma => Convert.ToInt64(new string(ma.ToArray()), 2));

                    foreach (var address in memoryAddresses)
                    {
                        memory[address] = memValue;
                    }
                }
            }

            return memory.Values.Sum();
        }

        private static void ReplaceFloating(List<char> maskedBitValue, List<List<char>> memoryAddresses)
        {
            if (maskedBitValue.Contains('X'))
            {
                var index = maskedBitValue.FindIndex(b => b == 'X');

                var copyMasked = maskedBitValue.Select(c => c).ToList();
                copyMasked[index] = '0';
                ReplaceFloating(copyMasked, memoryAddresses);

                copyMasked = maskedBitValue.Select(c => c).ToList();
                copyMasked[index] = '1';
                ReplaceFloating(copyMasked, memoryAddresses);

            }
            else
            {
                memoryAddresses.Add(maskedBitValue);
            }
        }
    }
}
