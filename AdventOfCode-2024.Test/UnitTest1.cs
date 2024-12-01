using AdventOfCode_2024.Challenges;

namespace AdventOfCode_2024.Test
{
    public class Tests
    {
        string[] input;
        [SetUp]
        public void Setup()
        {
            input = new string[]
            {
                "3   4",
                "4   3",
                "2   5",
                "1   3",
                "3   9",
                "3   3",
            };
        }

        [Test]
        public void Challenge1_Part1()
        {
            Challenge1 challenge = new Challenge1();
            var result = challenge.ChallengePart1(input);
            Assert.That(result == "11");
        }

        [Test]
        public void Challenge1_Part2()
        {
            Challenge1 challenge = new Challenge1();
            var result = challenge.ChallengePart2(input);
            Assert.That(result == "31");
        }
    }
}