using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Challenges
{
    public interface IChallenge
    {
        public string ChallengePart1(string[] input);
        public string ChallengePart2(string[] input);
    }
}
