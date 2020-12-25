using System.Collections.Generic;
using Day14;
using Xunit;

namespace AocTest
{
    public class Day14Test
    {
        [Fact]
        public void Part1()
        {
            // arrange
            var input = new List<string> {
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
"mem[8] = 11",
"mem[7] = 101",
"mem[8] = 0",
            };

            // act
            var result = Program.Part1Solution(input);

            // assert
            Assert.Equal(165, result);
        }

        [Fact]
        public void Part2()
        {
            // arrange
            var input = new List<string> {
                "mask = 000000000000000000000000000000X1001X",
"mem[42] = 100",
"mask = 00000000000000000000000000000000X0XX",
"mem[26] = 1",
            };

            // act
            var result = Program.Part2Solution(input);

            // assert
            Assert.Equal(208, result);
        }
    }
}
