using AdventOfCode.CrossCuttingConcerns;

namespace AdventOfCode_2024.Challenges
{
    public class Challenge1 : IChallenge
    {
        public string ChallengePart1(string[] input)
        {
            var leftNumbers = new List<int>();
            var rightNumbers = new List<int>();

            foreach (var i in input)
            {
                var values = i.Split("  ");
                leftNumbers.Add(int.Parse(values[0]));
                rightNumbers.Add(int.Parse(values[1]));
            }
            leftNumbers = leftNumbers.OrderByDescending(x => x).ToList();
            rightNumbers = rightNumbers.OrderByDescending(x => x).ToList();

            int totalDistances = 0;
            for(int i = 0; i < leftNumbers.Count; i++)
            {
                totalDistances += NumberHelpers.DifferenceBetweenNumbers(leftNumbers[i], rightNumbers[i]);
            }
            return totalDistances.ToString();
        }

        public string ChallengePart2(string[] input)
        {
            var leftNumbers = new List<int>();
            var rightNumbers = new List<int>();

            foreach (var i in input)
            {
                var values = i.Split("  ");
                leftNumbers.Add(int.Parse(values[0]));
                rightNumbers.Add(int.Parse(values[1]));
            }

            int total = 0; 
            for (int i = 0; i < leftNumbers.Count; i++)
            {
                int searchValue = leftNumbers[i];
                // amount of times it appears in the right
                int rightCount = rightNumbers.Where(x => x == searchValue).Count();
                total += (searchValue * rightCount);
            }
            return total.ToString();
        }
    }
}
