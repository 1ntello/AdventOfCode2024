using AdventOfCode_2024.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Test
{
    [TestFixture]
    public class Challenge3Test
    {
        string[] input;

        public Challenge3Test()
        {
            input = ["xmul(2,4) % &mul[3,7]!@^do_not_mul(5,5) + mul(32,64]then(mul(11,8)mul(8,5))"]; 
        }

        [Test]
        public void Challenge3_Part1()
        {
            Challenge3 challenge = new Challenge3();
            var result = challenge.ChallengePart1(input);
            Assert.That(result == "161");
        }

        [Test]
        public void Challenge3_Part2()
        {
            input = ["xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"];
            Challenge3 challenge = new Challenge3();
            var result = challenge.ChallengePart2(input);
            Assert.That(result == "48");
        }
    }
}
