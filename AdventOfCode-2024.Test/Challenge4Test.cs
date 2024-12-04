using AdventOfCode_2024.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Test
{
    public class Challenge4Test
    {
        string[] input;
        public Challenge4Test()
        {
            input = new string[]
            {
                "MMMSXXMASM",
                "MSAMXMSMSA",
                "AMXSXMAAMM",
                "MSAMASMSMX",
                "XMASAMXAMM",
                "XXAMMXXAMA",
                "SMSMSASXSS",
                "SAXAMASAAA",
                "MAMMMXMMMM",
                "MXMXAXMASX",
            };
        }

        [Test]
        public void Challenge4_Part1()
        {
            Challenge4 challenge = new Challenge4();
            var result = challenge.ChallengePart1(input);
            Assert.That(result == "18");
        }

        [Test]
        public void Challenge4_Part2()
        {
            Challenge4 challenge = new Challenge4();
            var result = challenge.ChallengePart2(input);
            Assert.That(result == "9");
        }
    }
}
