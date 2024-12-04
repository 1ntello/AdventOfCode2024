using AdventOfCode_2024.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Test
{
    internal class Challenge2Test
    {
        string[] input;
        [SetUp]
        public void Setup()
        {
            input = new string[]
            {
                "7 6 4 2 1",
                "1 2 7 8 9",
                "9 7 6 2 1",
                "1 3 2 4 5",
                "8 6 4 4 1",
                "1 3 6 7 9",
            };
        }


        [Test]
        public void Challenge2_Part1()
        {
            Challenge2 challenge = new Challenge2();
            var result = challenge.ChallengePart1(input);
            Assert.That(result == "2");
        }

        [Test]
        public void Challenge2_Part2()
        {
            Challenge2 challenge = new Challenge2();
            var result = challenge.ChallengePart2(input);
            Assert.That(result == "4");
        }

    }
}
