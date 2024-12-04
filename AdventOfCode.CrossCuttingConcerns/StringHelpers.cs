using System.Drawing;

namespace AdventOfCode.CrossCuttingConcerns
{
    public static class StringHelpers
    {
        public static List<int> ParseLineToListOfInts(string line)
        {
            List<int> result = new List<int>();
            var split = line.Split(' ');
            foreach (var s in split)
            {
                result.Add(int.Parse(s));
            }
            return result;
        }

        public static List<List<int>> StringArrayToIntListArray(string[] lines)
        {
            List<List<int>> result = new List<List<int>>();
            foreach (var l in lines)
            {
                result.Add(ParseLineToListOfInts(l));
            }
            return result;
        }

        public static void PrintColoredLine(string line, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
