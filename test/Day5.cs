using System.Collections.Generic;
using Day5;
using Xunit;

namespace AocTest
{
    public class Day5Test
    {
        [Fact]
        public void Part1_1()
        {
            // arrange
            var input = new[] { "BFFFBBFRRR" };

            // act
            var result = Program.Part1Solution(input);

            // assert
            Assert.Equal(567, result);
        }

        [Fact]
        public void Part1_2()
        {
            // arrange
            var input = new[] { "FFFBBBFRRR" };

            // act
            var result = Program.Part1Solution(input);

            // assert
            Assert.Equal(119, result);
        }

        [Fact]
        public void Part1_3()
        {
            // arrange
            var input = new[] { "BBFFBBFRLL" };

            // act
            var result = Program.Part1Solution(input);

            // assert
            Assert.Equal(820, result);
        }
    }
}
