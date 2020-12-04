using Day1;
using Xunit;

namespace AocTest
{
    public class Day1Test
    {
        [Fact]
        public void Part1()
        {
            // arrange
            var input = new[] { 1721, 979, 366, 299, 675, 1456 };

            // act
            var result = Program.Part1Solution(input);

            // assert
            Assert.Equal(514579, result);
        }

        [Fact]
        public void Part2()
        {
            // arrange
            var input = new[] { 1721, 979, 366, 299, 675, 1456 };

            // act
            var result = Program.Part2Solution(input);

            // assert
            Assert.Equal(241861950, result);
        }
    }
}
