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

        public static Dictionary<Point, char> ParseStringsIntoGridDictionary(string[] lines)
        {
            Dictionary<Point, char> dict = new Dictionary<Point, char>();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                for (int j = 0; j < line.Length; j++)
                {
                    // I know weird but i is the Y because its the line number, sue me. 
                    dict.Add(new Point(j, i), line[j]);
                }
            }
            return dict;
        }
    }
}
