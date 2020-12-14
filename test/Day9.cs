using Day9;
using Xunit;

namespace AocTest
{
    public class Day9Test
    {
        [Fact]
        public void Part1()
        {
            // arrange
            var input = new long[] { 35,
20,
15,
25,
47,
40,
62,
55,
65,
95,
102,
117,
150,
182,
127,
219,
299,
277,
309,
576
            };

            // act
            var result = Program.Part1Solution(input, 5);

            // assert
            Assert.Equal(127, result);
        }

        [Fact]
        public void Part2()
        {
            // arrange
            var input = new long[] { 35,
20,
15,
25,
47,
40,
62,
55,
65,
95,
102,
117,
150,
182,
127,
219,
299,
277,
309,
576
            };

            // act
            var result = Program.Part2Solution(input, 127);

            // assert
            Assert.Equal(62, result);
        }
    }
}
