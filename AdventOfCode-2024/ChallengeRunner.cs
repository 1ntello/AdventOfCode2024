﻿using AdventOfCode_2024.Challenges;
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
                case 2:
                    challenge = new Challenge2();
                    break;
                case 3:
                    challenge = new Challenge3();
                    break;
                case 4:
                    challenge = new Challenge4();
                    break;
                case 5:
                    challenge = new Challenge5();
                    break;
                case 6:
                    challenge = new Challenge6();
                    break;
                default:
                    break;

            };

            Console.WriteLine($"Running Challenge {challenge.GetType().ToString()} part 1");
            Console.WriteLine($"---------------------------------------------------------");
            Console.WriteLine(challenge?.ChallengePart1(input));
            Console.WriteLine($"---------------------------------------------------------");
            Console.WriteLine($"Running Challenge {challenge.GetType().ToString()} part 2");
            Console.WriteLine(challenge?.ChallengePart2(input));
            Console.WriteLine($"---------------------------------------------------------");
        }

    }
}
