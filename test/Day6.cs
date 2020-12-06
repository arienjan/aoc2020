using Day6;
using Xunit;

namespace AocTest
{
    public class Day6Test
    {
        [Fact]
        public void Part1()
        {
            // arrange
            var input = new[] { "abc",
                                "",
                                "a",
                                "b",
                                "c",
                                "",
                                "ab",
                                "ac",
                                "",
                                "a",
                                "a",
                                "a",
                                "a",
                                "",
                                "b",
            };

            // act
            var result = Program.Part1Solution(input);

            // assert
            Assert.Equal(11, result);
        }

        [Fact]
        public void Part2()
        {
            // arrange
            var input = new[] { "abc",
                                "",
                                "a",
                                "b",
                                "c",
                                "",
                                "ab",
                                "ac",
                                "",
                                "a",
                                "a",
                                "a",
                                "a",
                                "",
                                "b",
            };

            // act
            var result = Program.Part2Solution(input);

            // assert
            Assert.Equal(6, result);
        }
    }
}
