using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Challenges
{
    public class Challenge3 : IChallenge
    {
        public string ChallengePart1(string[] input)
        {
            
            //make a regex
            //https://regex-generator.olafneumann.org
            //https://stackoverflow.com/questions/7407099/regex-match-numbers-of-variable-length
            
            var regex = new Regex(@"mul\(\d+,\d+\)", RegexOptions.IgnoreCase);

            var searchString = string.Join("", input);
            var allCommmands = regex.Matches(searchString);

            int total = 0; 
            foreach (var commmand in allCommmands)
            {
                Console.WriteLine($"Accepting {commmand.ToString()}");
                total += ParseAndMultiplyCommand(commmand.ToString()!);
            }
            return total.ToString();
        }

        public string ChallengePart2(string[] input)
        {
            //match dos and donts
            var regex = new Regex(@"(mul\(\d+,\d+\))|(do\(\))|(don't\(\))", RegexOptions.IgnoreCase);

            var searchString = string.Join("", input);
            var allCommmands = regex.Matches(searchString);

            int total = 0;
            bool active = true; 
            foreach (var command in allCommmands)
            {
                if (command.ToString()!.Equals("do()"))
                {
                    active = true;
                }
                else if (command.ToString()!.Equals("don't()"))
                {
                    active = false;
                } 
                else
                {
                    Console.WriteLine($"Accepting {command.ToString()}");
                    if (active)
                    {
                        total += ParseAndMultiplyCommand(command.ToString()!);
                    }
                }
            }
            return total.ToString();
        }


        private int ParseAndMultiplyCommand(string command)
        {
            var splitCommand = command.Replace("mul","").Replace("(", "").Replace(")", "").Split(",");
            var operator1 = int.Parse(splitCommand[0]);
            var operator2 = int.Parse(splitCommand[1]);
            return operator1 * operator2;
        }
    }
}
