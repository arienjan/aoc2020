using Day12;
using Xunit;

namespace AocTest
{
    public class Day12Test
    {
        [Fact]
        public void Part1()
        {
            // arrange
            var input = new string[] { "F10",
"N3",
"F7",
"R90",
"F11",
            };

            // act
            var result = Program.Part1Solution(input);

            // assert
            Assert.Equal(25, result);
        }
        [Fact]
        public void Part2()
        {
            // arrange
            var input = new string[] { "F10",
"N3",
"F7",
"R90",
"F11",
            };

            // act
            var result = Program.Part2Solution(input);

            // assert
            Assert.Equal(286, result);
        }
    }
}
