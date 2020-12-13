using Day8;
using Xunit;

namespace AocTest
{
    public class Day8Test
    {
        [Fact]
        public void Part1()
        {
            // arrange
            var input = new[] { "nop +0",
"acc +1",
"jmp +4",
"acc +3",
"jmp -3",
"acc -99",
"acc +1",
"jmp -4",
"acc +6",
            };

            // act
            var result = Program.Part1Solution(input);

            // assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Part2()
        {
            // arrange
            var input = new[] { "nop +0",
"acc +1",
"jmp +4",
"acc +3",
"jmp -3",
"acc -99",
"acc +1",
"jmp -4",
"acc +6",
            };

            // act
            var result = Program.Part2Solution(input);

            // assert
            Assert.Equal(8, result);
        }
    }
}
