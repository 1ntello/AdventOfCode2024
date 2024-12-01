using AdventOfCode_2024.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024
{
    public static class ChallengeRunner
    {
        public static void RunChallenge(int challengeNo)
        {
            // Read input
            var input = File.ReadAllLines($"Inputs/Challenge{challengeNo}.txt");

            IChallenge? challenge = default;

            switch (challengeNo)
            {
                case 1:
                    challenge = new Challenge1();
                    break;
                default:
                    break;

            };

            Console.WriteLine(challenge?.ChallengePart1(input));
            Console.WriteLine(challenge?.ChallengePart2(input));
        }

    }
}
