using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Shared;

namespace Day4
{
    public class Program
    {
        private static Regex passportRegex = new Regex(@"((byr)|(iyr)|(eyr)|(hgt)|(hcl)|(ecl)|(pid)|(cid)):([a-z|0-9|#]+)+");
        private static Regex hgtRegex = new Regex(@"^(\d*)((cm)|(in))$");
        private static Regex hclRegex = new Regex(@"^#[a-f,0-9]{6}$");
        private static Regex eclRegex = new Regex(@"^((amb)|(blu)|(brn)|(gry)|(grn)|(hzl)|(oth)){1}$");
        private static Regex pidRegex = new Regex(@"^[0-9]{9}$");

        static void Main()
        {
            var input = InputGetter.ReadInputAsLines<string>(2020, 4).Result.ToList();

            // part1
            var solutionPart1 = Part1Solution(input);
            Console.WriteLine(solutionPart1);

            // part2
            var solutionPart2 = Part2Solution(input);
            Console.WriteLine(solutionPart2);
        }

        public static int Part1Solution(List<string> passportLines)
        {
            var validPassPorts = 0;

            foreach (var passport in ScanPassports(passportLines))
            {
                if (passport.ContainsKey("byr") &&
                    passport.ContainsKey("iyr") &&
                    passport.ContainsKey("eyr") &&
                    passport.ContainsKey("hgt") &&
                    passport.ContainsKey("hcl") &&
                    passport.ContainsKey("ecl") &&
                    passport.ContainsKey("pid"))
                    validPassPorts++;
            }
            return validPassPorts;
        }
        public static int Part2Solution(List<string> passportLines)
        {
            var validPassPorts = 0;

            foreach (var passport in ScanPassports(passportLines))
            {
                if (passport.ContainsKey("byr") && ByrCheck(passport["byr"]) &&
                    passport.ContainsKey("iyr") && IyrCheck(passport["iyr"]) &&
                    passport.ContainsKey("eyr") && EyrCheck(passport["eyr"]) &&
                    passport.ContainsKey("hgt") && HgtCheck(passport["hgt"]) &&
                    passport.ContainsKey("hcl") && HclCheck(passport["hcl"]) &&
                    passport.ContainsKey("ecl") && EclCheck(passport["ecl"]) &&
                    passport.ContainsKey("pid") && PidCheck(passport["pid"]))
                    validPassPorts++;
            }
            return validPassPorts;
        }

        private static IEnumerable<IDictionary<string, string>> ScanPassports(List<string> passportLines)
        {
            var passport = new Dictionary<string, string>();
            var returnPassport = new Dictionary<string, string>();

            for (int i = 0; i<passportLines.Count(); i++)
            {
                var line = passportLines[i];

                if (string.IsNullOrEmpty(line))
                {
                    returnPassport = new Dictionary<string, string>(passport);
                    passport = new Dictionary<string, string>();
                    yield return returnPassport;
                }

                passportRegex
                    .Matches(line)
                    .Cast<Match>()
                    .Select(m => m.Groups.Values.ToList()[0])
                    .Select(m => m.Value.Split(":"))
                    .ToList()
                    .ForEach(field => passport.Add(field[0], field[1]));

                // When last line, kan vast netter?
                if (i == passportLines.Count() - 1)
                {
                    yield return passport;
                }
            }
        }

        private static bool ByrCheck(string byr)
        {
            var isValidByr = int.TryParse(byr, out var byrValue);

            return isValidByr && byrValue is (> 1919 and < 2003);
        }

        private static bool IyrCheck(string iyr)
        {
            var isValidIyr = int.TryParse(iyr, out var iyrValue);

            return isValidIyr && iyrValue is (> 2009 and < 2021);
        }

        private static bool EyrCheck(string eyr)
        {
            var isValidEyr = int.TryParse(eyr, out var eyrValue);

            return isValidEyr && eyrValue is (> 2019 and < 2031);
        }

        private static bool HgtCheck(string hgt)
        {
            var match = hgtRegex.Match(hgt);

            if (match.Success)
            {
                var matchValues = match.Groups.Values.ToArray();
                var height = int.Parse(matchValues[1].Value);
                var unit = matchValues[2].Value;

                if (unit == "cm")
                    return height is (> 149 and < 194);
                else if (unit == "in")
                    return height is (> 58 and < 77);
                else
                    return false;
            }

            return false;
        }

        private static bool HclCheck(string hcl)
        {
            var match = hclRegex.Match(hcl);
            return match.Success;
        }

        private static bool EclCheck(string ecl)
        {
            var match = eclRegex.Match(ecl);
            return match.Success;
        }

        private static bool PidCheck(string pid)
        {
            var match = pidRegex.Match(pid);
            return match.Success;
        }
    }
}
