using Day10;
using Xunit;

namespace AocTest
{
    public class Day10Test
    {
        [Fact]
        public void Part1()
        {
            // arrange
            var input = new int[] { 28,
33,
18,
42,
31,
14,
46,
20,
48,
47,
24,
23,
49,
45,
19,
38,
39,
11,
1,
32,
25,
35,
8,
17,
7,
9,
4,
2,
34,
10,
3
            };

            // act
            var result = Program.Part1Solution(input);

            // assert
            Assert.Equal(220, result);
        }

        [Fact]
        public void Part2()
        {
            // arrange
            var input = new int[] { 28,
33,
18,
42,
31,
14,
46,
20,
48,
47,
24,
23,
49,
45,
19,
38,
39,
11,
1,
32,
25,
35,
8,
17,
7,
9,
4,
2,
34,
10,
3
            };

            // act
            var result = Program.Part2Solution(input);

            // assert
            Assert.Equal(19208, result);
        }

        [Fact]
        public void Part2_2()
        {
            // arrange
            var input = new int[] { 16,
                10,
                15,
                5,
                1,
                11,
                7,
                19,
                6,
                12,
                4
            };

            // act
            var result = Program.Part2Solution(input);

            // assert
            Assert.Equal(8, result);
        }
    }
}
