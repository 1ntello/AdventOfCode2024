using AdventOfCode.CrossCuttingConcerns;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Challenges
{
    public class Challenge4 : IChallenge
    {
        public string ChallengePart1(string[] input)
        {
            var grid = StringHelpers.ParseStringsIntoGridDictionary(input);

            // now we find all x's and then we check if we want to go horizontally, vertically, or diagonally
            int totalCounts = 0;
            var points = grid.Where(x => x.Value == 'X');
            foreach (var point in points)
            {
                totalCounts += CountHorizontalOccurrences(grid, "XMAS", point.Key);
                totalCounts += CountVerticalOccurrences(grid, "XMAS", point.Key);
                totalCounts += CountDiagonalOccurrences(grid, "XMAS", point.Key);
            }
            return totalCounts.ToString();
        }

        public string ChallengePart2(string[] input)
        {
            var grid = StringHelpers.ParseStringsIntoGridDictionary(input);

            // now we find all x's and then we check if we want to go horizontally, vertically, or diagonally
            int totalCounts = 0;
            var points = grid.Where(x => x.Value == 'A');
            foreach (var point in points)
            {
                // its killing me but its only diagonal.
                // we just check each A, and see if the top left is either M or S, and then the other side should be opposite.
                if (TheElfIsALiarAndHeIsWrongAndThisIsInsane(grid, point.Key))
                    totalCounts += 1;
            }
            return totalCounts.ToString();
        }


        private bool TheElfIsALiarAndHeIsWrongAndThisIsInsane(Dictionary<Point, char> grid, Point startingPoint)
        {
            var topleft = grid.ContainsKey(new Point(startingPoint.X - 1, startingPoint.Y - 1)) ? grid[new Point(startingPoint.X - 1, startingPoint.Y - 1)] : 'o';
            var topright = grid.ContainsKey(new Point(startingPoint.X + 1, startingPoint.Y - 1)) ? grid[new Point(startingPoint.X + 1, startingPoint.Y - 1)] : 'o';
            var bottomleft = grid.ContainsKey(new Point(startingPoint.X - 1, startingPoint.Y + 1)) ? grid[new Point(startingPoint.X - 1, startingPoint.Y + 1)] : 'o';
            var bottomright = grid.ContainsKey(new Point(startingPoint.X + 1, startingPoint.Y + 1)) ? grid[new Point(startingPoint.X + 1, startingPoint.Y + 1)] : 'o';

            // first we do some quick checks. 
            var quickChecks = new char[] { topleft, topright, bottomleft, bottomright }.ToList();
            if (quickChecks.Any(x => x != 'S' && x != 'M'))
                return false;
            if (quickChecks.Count(x => x == 'S') != 2)
                return false;
            if (quickChecks.Count(x => x == 'M') != 2)
                return false;
            // we have now deterred there are two m's and two s's, we only now have to confirm they are opposite each other (so they dont spell mam or sas)
            if (topleft == bottomright || topright == bottomleft)
                return false;

            return true;
        }

        private int CountHorizontalOccurrences(Dictionary<Point, char> grid, string searchterm, Point startingPoint)
        {
            int counts = 0;
            // check right
            string word = "";
            for (int i = 0; i < searchterm.Length; i++)
            {
                word += grid.ContainsKey(new Point(startingPoint.X + i, startingPoint.Y)) ? grid[new Point(startingPoint.X + i, startingPoint.Y)] : "";
            }
            if (word == searchterm)
            {
                Console.WriteLine($"From {startingPoint.X} , {startingPoint.Y} found {word} horizontal1");
                counts++;
            }
            // check left
            word = "";
            for (int i = 0; i < searchterm.Length; i++)
            {
                word += grid.ContainsKey(new Point(startingPoint.X - i, startingPoint.Y)) ? grid[new Point(startingPoint.X - i, startingPoint.Y)] : "";
            }
            if (word == searchterm)
            {
                Console.WriteLine($"From {startingPoint.X} , {startingPoint.Y} found {word} horizontal2");
                counts++;
            }

            return counts;
        }
        private int CountVerticalOccurrences(Dictionary<Point, char> grid, string searchterm, Point startingPoint)
        {
            int counts = 0;
            // check right
            string word = "";
            for (int i = 0; i < searchterm.Length; i++)
            {
                word += grid.ContainsKey(new Point(startingPoint.X, startingPoint.Y + i)) ? grid[new Point(startingPoint.X, startingPoint.Y + i)] : "";
            }
            if (word == searchterm)
            {
                Console.WriteLine($"From {startingPoint.X} , {startingPoint.Y} found {word} vertical1");
                counts++;
            }
            // check left
            word = "";
            for (int i = 0; i < searchterm.Length; i++)
            {
                word += grid.ContainsKey(new Point(startingPoint.X, startingPoint.Y - i)) ? grid[new Point(startingPoint.X, startingPoint.Y - i)] : "";
            }
            if (word == searchterm)
            {
                Console.WriteLine($"From {startingPoint.X} , {startingPoint.Y} found {word} vertical2");
                counts++;
            }
            return counts;
        }

        private int CountDiagonalOccurrences(Dictionary<Point, char> grid, string searchterm, Point startingPoint)
        {
            int counts = 0;
            // check right
            string word = "";
            for (int i = 0; i < searchterm.Length; i++)
            {
                word += grid.ContainsKey(new Point(startingPoint.X - i, startingPoint.Y - i)) ? grid[new Point(startingPoint.X - i, startingPoint.Y - i)] : "";
            }
            if (word == searchterm)
            {
                Console.WriteLine($"From {startingPoint.X} , {startingPoint.Y} found {word} diagonal1");
                counts++;
            }
            // check left
            word = "";
            for (int i = 0; i < searchterm.Length; i++)
            {
                word += grid.ContainsKey(new Point(startingPoint.X + i, startingPoint.Y + i)) ? grid[new Point(startingPoint.X + i, startingPoint.Y + i)] : "";
            }
            if (word == searchterm)
            {
                Console.WriteLine($"From {startingPoint.X} , {startingPoint.Y} found {word} diagonal2");
                counts++;
            }

            word = "";
            for (int i = 0; i < searchterm.Length; i++)
            {
                word += grid.ContainsKey(new Point(startingPoint.X - i, startingPoint.Y + i)) ? grid[new Point(startingPoint.X - i, startingPoint.Y + i)] : "";
            }
            if (word == searchterm)
            {
                Console.WriteLine($"From {startingPoint.X} , {startingPoint.Y} found {word} diagonal3");
                counts++;
            }
            // check left
            word = "";
            for (int i = 0; i < searchterm.Length; i++)
            {
                word += grid.ContainsKey(new Point(startingPoint.X + i, startingPoint.Y - i)) ? grid[new Point(startingPoint.X + i, startingPoint.Y - i)] : "";
            }
            if (word == searchterm)
            {
                Console.WriteLine($"From {startingPoint.X} , {startingPoint.Y} found {word} diagonal4");
                counts++;
            }

            return counts;
        }
    }
}
