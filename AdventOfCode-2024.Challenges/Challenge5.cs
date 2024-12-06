using AdventOfCode_2024.Challenges.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Challenges
{
    public class Challenge5 : IChallenge
    {
        public string ChallengePart1(string[] input)
        {
            var inputList = input.Where(x => x != "").ToList();
            // first we have to split instructions and updates
            var instructions = inputList.Where(x => x.Contains("|")).ToList();
            var pages = inputList.Except(instructions).ToList();
            var pagePairInstructions = GetPagePairs(instructions);

            int total = 0;

            foreach (var p in pages)
            {
                if (IsPageInOrder(p, pagePairInstructions))
                    total += GetMiddlePageNumber(p);
            }

            return total.ToString();
        }

        public string ChallengePart2(string[] input)
        {
            throw new NotImplementedException();
        }

        public List<PagePair> GetPagePairs(List<string> input)
        {
            List<PagePair> pairList = new List<PagePair>();
            foreach (var pair in input) 
            {
                var splitPair = pair.Split("|");
                pairList.Add(new PagePair(int.Parse(splitPair[0]), int.Parse(splitPair[1])));
            }
            return pairList;
        }

        public int GetMiddlePageNumber(string page)
        {
            var convertedList = page.Split(',').Select(x => int.Parse(x)).ToList();
            int middlePageNumber = convertedList[convertedList.Count / 2];
            return middlePageNumber;
        }


        public bool IsPageInOrder(string page, List<PagePair> instructions)
        {
            var convertedList = page.Split(',').Select(x => int.Parse(x)).ToList();
            bool valid = true;
            for (int i = 0; i < convertedList.Count();i++)
            {
                // we have to check the numbers against all other numbers except itself. 
                // with I we know the location against all others 
                for (int j = 0; j < convertedList.Count(); j++)
                {
                    if (j == i)
                        continue;
                    else if (j < i) // it has to be before so i has to be on the right side
                    {
                        valid = instructions.Where(x => x.PageNumber1 == convertedList[j] && x.PageNumber2 == convertedList[i]).Any();
                    }
                    else if (j > i) // it has to be after so i has to be on the right side 
                    {
                        valid = instructions.Where(x => x.PageNumber1 == convertedList[i] && x.PageNumber2 == convertedList[j]).Any();
                    }
                    if (!valid)
                        return false;
                }
            }
            return valid;
        }
    }
}
