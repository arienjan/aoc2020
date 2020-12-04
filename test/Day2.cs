using Day2;
using Xunit;

namespace AocTest
{
    public class Day2Test
    {
        [Fact]
        public void Part1()
        {
            // arrange
            var input = new[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };

            // act
            var result = Program.Part1Solution(input);

            // assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Part2()
        {
            // arrange
            var input = new[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };

            // act
            var result = Program.Part2Solution(input);

            // assert
            Assert.Equal(1, result);
        }
    }
}
