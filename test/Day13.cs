using System.Collections.Generic;
using Day13;
using Xunit;

namespace AocTest
{
    public class Day13Test
    {
        [Fact]
        public void Part1()
        {
            // arrange
            var input = new List<string> { "939" , "7,13,x,x,59,x,31,19" };

            // act
            var result = Program.Part1Solution(input);

            // assert
            Assert.Equal(295, result);
        }

        [Fact]
        public void Part2()
        {
            // arrange
            var input = new List<string> { "939", "7,13,x,x,59,x,31,19" };

            // act
            var result = Program.Part2Solution(input);

            // assert
            Assert.Equal(1068781, result);
        }
    }
}
