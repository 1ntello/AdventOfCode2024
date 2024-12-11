using AdventOfCode_2024.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Test
{
    internal class Challenge6Test
    {

        string[] input;
        public Challenge6Test()
        {
            input = new string[]
            {
                "....#.....",
                ".........#",
                "..........",
                "..#.......",
                ".......#..",
                "..........",
                ".#..^.....",
                "........#.",
                "#.........",
                "......#..."
            };
        }

        [Test]
        public void Challenge6_Part1()
        {
            Challenge6 challenge = new Challenge6();
            var result = challenge.ChallengePart1(input);
            Assert.That(result, Is.EqualTo("41"));
        }

        [Test]
        public void Challenge6_Part2()
        {
            Challenge6 challenge = new Challenge6();
            var result = challenge.ChallengePart2(input);
            Assert.That(result, Is.EqualTo("6"));
        }
    }
}
