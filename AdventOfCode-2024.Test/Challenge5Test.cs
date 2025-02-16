﻿using AdventOfCode_2024.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Test
{
    public class Challenge5Test
    {
        string[] input;
        public Challenge5Test()
        {
            input = new string[]
            {
                "47|53",
                "97|13",
                "97|61",
                "97|47",
                "75|29",
                "61|13",
                "75|53",
                "29|13",
                "97|29",
                "53|29",
                "61|53",
                "97|53",
                "61|29",
                "47|13",
                "75|47",
                "97|75",
                "47|61",
                "75|61",
                "47|29",
                "75|13",
                "53|13",

                "75,47,61,53,29",
                "97,61,53,29,13",
                "75,29,13",
                "75,97,47,61,53",
                "61,13,29",
                "97,13,75,29,47",
            };
        }

        [Test]
        public void Challenge5_Part1()
        {
            Challenge5 challenge = new Challenge5();
            var result = challenge.ChallengePart1(input);
            Assert.That(result, Is.EqualTo("143"));
        }

        [Test]
        public void Challenge5_Part2()
        {
            Challenge5 challenge = new Challenge5();
            var result = challenge.ChallengePart2(input);
            Assert.That(result == "123");
        }
    }
}
