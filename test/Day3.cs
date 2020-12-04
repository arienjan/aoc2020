using Day3;
using Xunit;

namespace AocTest
{
    public class Day3Test
    {
        [Fact]
        public void Part1()
        {
            // arrange
            var input = new[] { "..##.......",
                                "#...#...#..",
                                ".#....#..#.",
                                "..#.#...#.#",
                                ".#...##..#.",
                                "..#.##.....",
                                ".#.#.#....#",
                                ".#........#",
                                "#.##...#...",
                                "#...##....#",
                                ".#..#...#.#",};

            // act
            var result = Program.Part1Solution(input);

            // assert
            Assert.Equal(7, result);
        }

        [Fact]
        public void Part2()
        {
            // arrange
            var input = new[] { "..##.......",
                                "#...#...#..",
                                ".#....#..#.",
                                "..#.#...#.#",
                                ".#...##..#.",
                                "..#.##.....",
                                ".#.#.#....#",
                                ".#........#",
                                "#.##...#...",
                                "#...##....#",
                                ".#..#...#.#",};

            // act
            var result = Program.Part2Solution(input);

            // assert
            Assert.Equal(336, result);
        }
    }
}
