using Day11;
using Xunit;

namespace AocTest
{
    public class Day11Test
    {
        [Fact]
        public void Part1()
        {
            // arrange
            var input = new string[] { "L.LL.LL.LL",
"LLLLLLL.LL",
"L.L.L..L..",
"LLLL.LL.LL",
"L.LL.LL.LL",
"L.LLLLL.LL",
"..L.L.....",
"LLLLLLLLLL",
"L.LLLLLL.L",
"L.LLLLL.LL",
            };

            // act
            var result = Program.Part2Solution(input, 4, Program.SetSeatRefs);

            // assert
            Assert.Equal(37, result);
        }

        [Fact]
        public void Part2()
        {
            // arrange
            var input = new string[] { "L.LL.LL.LL",
"LLLLLLL.LL",
"L.L.L..L..",
"LLLL.LL.LL",
"L.LL.LL.LL",
"L.LLLLL.LL",
"..L.L.....",
"LLLLLLLLLL",
"L.LLLLLL.L",
"L.LLLLL.LL",
            };

            // act
            var result = Program.Part2Solution(input, 5, Program.SetSeatRefs2);

            // assert
            Assert.Equal(26, result);
        }
    }
}
